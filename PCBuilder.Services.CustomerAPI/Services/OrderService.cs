using AutoMapper;
using BuilderComputerCreateDTO = PCBuilder.Service.BuilderServiceAPI.DTO.Response.ComputerCreateDTO;
using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.IRepository;
using PCBuilder.Services.CustomerAPI.IServices;
using Contracts;
using System.Security.Claims;
using System.Text.Json;

namespace PCBuilder.Services.CustomerAPI.Services;

public class OrderService : IOrderService
{
    private const decimal CustomerRefusalBudgetMultiplier = 1.15m;

    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IReviewRepository _reviewRepository;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public OrderService(
        IOrderRepository orderRepository,
        ICustomerRepository customerRepository,
        IReviewRepository reviewRepository,
        IMapper mapper,
        IHttpClientFactory httpClientFactory,
        IHttpContextAccessor httpContextAccessor)
    {
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
        _reviewRepository = reviewRepository;
        _mapper = mapper;
        _httpClientFactory = httpClientFactory;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<ResponseDTO> GetAllOrdersAsync()
    {
        try
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "User is not authenticated."
                };
            }

            var orders = await _orderRepository.GetAllOrders();
            var message = string.Empty;
            if (!IsCurrentUserAdmin())
            {
                var reviewStats = await GetReviewStatsAsync(orders, userId.Value);
                var isGameOver = IsGameOver(reviewStats);

                var unlockedBudgetCap = GetUnlockedBudgetCap(reviewStats);
                var pendingLimit = GetVisiblePendingLimit(reviewStats);

                var assignedOrders = orders
                    .Where(x => x.UserId == userId)
                    .ToList();

                var visibleOpenOrders = isGameOver
                    ? new List<Models.Order>()
                    : orders
                        .Where(x =>
                            !x.UserId.HasValue &&
                            x.Status == Models.OrderStatus.Pending &&
                            x.Budget <= unlockedBudgetCap)
                        .OrderBy(x => x.Budget)
                        .ThenBy(x => x.CreatedAt)
                        .Take(pendingLimit)
                        .ToList();

                if (isGameOver && assignedOrders.All(x => x.Status != Models.OrderStatus.InProgress))
                {
                    message = "GAME_OVER";
                }

                orders = assignedOrders
                    .Concat(visibleOpenOrders)
                    .DistinctBy(x => x.Id)
                    .OrderBy(x => x.Status == Models.OrderStatus.InProgress ? 0 : x.Status == Models.OrderStatus.Pending ? 1 : 2)
                    .ThenBy(x => x.Budget)
                    .ThenByDescending(x => x.CreatedAt)
                    .ToList();
            }

            var orderDTOs = new List<OrderListDTO>();

            foreach (var order in orders)
            {
                var customer = await _customerRepository.GetCustomerById(order.CustomerId);

                var dto = new OrderListDTO
                {
                    Id = order.Id,
                    CustomerId = order.CustomerId,
                    UserId = order.UserId,
                    ReviewId = order.ReviewId,
                    CustomerName = customer?.Name ?? "Unknown customer",
                    CustomerImageUrl = customer?.ImageUrl ?? string.Empty,
                    ComputerId = order.ComputerId,
                    Budget = order.Budget,
                    SellingPrice = order.SellingPrice,
                    Description = order.Description,
                    DetailedDescription = order.DetailedDescription,
                    Status = (OrderStatus)order.Status,
                    CreatedAt = order.CreatedAt
                };

                orderDTOs.Add(dto);
            }

            return new ResponseDTO
            {
                IsSuccess = true,
                Result = orderDTOs,
                Message = message
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }
    public async Task<ResponseDTO> GetOrderByIdAsync(int id)
    {
        try
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "User is not authenticated."
                };
            }

            var order = await _orderRepository.GetOrderById(id);

            if (order == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = $"Order with id {id} not found."
                };
            }

            if (!IsCurrentUserAdmin() && order.UserId != userId)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "You do not have access to this order."
                };
            }

            var customer = await _customerRepository.GetCustomerById(order.CustomerId);

            var orderDTO = new OrderListDTO
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                UserId = order.UserId,
                ReviewId = order.ReviewId,
                CustomerName = customer?.Name ?? "Unknown customer",
                CustomerImageUrl = customer?.ImageUrl ?? string.Empty,
                ComputerId = order.ComputerId,
                Budget = order.Budget,
                SellingPrice = order.SellingPrice,
                Description = order.Description,
                DetailedDescription = order.DetailedDescription,
                Status = (OrderStatus)order.Status,
                CreatedAt = order.CreatedAt
            };

            return new ResponseDTO
            {
                IsSuccess = true,
                Result = orderDTO
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }
    public async Task<ResponseDTO> AcceptOrderAsync(int orderId)
    {
        try
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "User is not authenticated."
                };
            }

            var order = await _orderRepository.GetOrderById(orderId);

            if (order == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = $"Order with id {orderId} not found."
                };
            }

            if (order.Status == Models.OrderStatus.Completed || order.Status == Models.OrderStatus.Rejected)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Only pending or active orders can be accepted."
                };
            }

            if (order.Status == Models.OrderStatus.InProgress && order.ComputerId.HasValue)
            {
                if (!IsCurrentUserAdmin() && order.UserId != userId)
                {
                    return new ResponseDTO
                    {
                        IsSuccess = false,
                        Message = "This order is already assigned to another user."
                    };
                }

                return new ResponseDTO
                {
                    IsSuccess = true,
                    Message = "Order already accepted.",
                    Result = order
                };
            }

            if (!IsCurrentUserAdmin() && order.UserId.HasValue && order.UserId != userId)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "This order is already assigned to another user."
                };
            }

            if (!order.ComputerId.HasValue)
            {
                var customer = await _customerRepository.GetCustomerById(order.CustomerId);
                var createDraftResponse = await CreateDraftComputerForOrderAsync(order, customer?.Name);
                if (!createDraftResponse.IsSuccess)
                {
                    return createDraftResponse;
                }

                order.ComputerId = (int?)createDraftResponse.Result;
            }

            order.Status = Models.OrderStatus.InProgress;
            order.UserId = userId;
            await _orderRepository.UpdateOrder(order);

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Order accepted successfully.",
                Result = order
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }
    public async Task<ResponseDTO> RejectOrderAsync(int orderId)
    {
        try
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "User is not authenticated."
                };
            }

            var order = await _orderRepository.GetOrderById(orderId);

            if (order == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = $"Order with id {orderId} not found."
                };
            }

            if (order.Status == Models.OrderStatus.Completed)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Completed orders cannot be rejected."
                };
            }

            if (!IsCurrentUserAdmin() && order.UserId != userId)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "You can only reject your own assigned orders."
                };
            }

            order.Status = Models.OrderStatus.Rejected;
            order.UserId ??= userId;
            await _orderRepository.UpdateOrder(order);

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Order rejected successfully.",
                Result = order
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }
    public async Task<ResponseDTO> CompleteOrderAsync(int orderId)
    {
        try
        {
            var userId = GetCurrentUserId();
            if (!userId.HasValue)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "User is not authenticated."
                };
            }

            var order = await _orderRepository.GetOrderById(orderId);

            if (order == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = $"Order with id {orderId} not found."
                };
            }

            if (order.Status != Models.OrderStatus.InProgress)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Only in-progress orders can be completed."
                };
            }

            if (!IsCurrentUserAdmin() && order.UserId != userId)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "You can only complete your own assigned orders."
                };
            }

            order.Status = Models.OrderStatus.Completed;
            order.UserId ??= userId;
            await _orderRepository.UpdateOrder(order);

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Order completed successfully.",
                Result = order
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }
    public async Task<ResponseDTO> UpdateSellingPriceAsync(int orderId, decimal sellingPrice)
    {
        try
        {
            var userId = GetCurrentUserId();

            if (!userId.HasValue)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "User is not authenticated."
                };
            }

            var order = await _orderRepository.GetOrderById(orderId);

            if (order == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = $"Order with id {orderId} not found."
                };
            }

            if (!IsCurrentUserAdmin() && order.UserId != userId)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "You can only update your own assigned orders."
                };
            }

            if (order.Status == Models.OrderStatus.Rejected)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Rejected orders cannot be updated."
                };
            }

            if (sellingPrice <= 0)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Sale price must be greater than 0 kr."
                };
            }

            var refusalLimit = order.Budget * CustomerRefusalBudgetMultiplier;
            if (order.Budget > 0 && sellingPrice > refusalLimit)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = $"The customer refuses to pay {sellingPrice:N0} kr. Their absolute limit is about {refusalLimit:N0} kr."
                };
            }

            if (!order.ComputerId.HasValue)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Cannot finish an order without a connected computer."
                };
            }

            order.SellingPrice = sellingPrice;
            order.Status = Models.OrderStatus.Completed;
            order.UserId ??= userId;

            await _orderRepository.UpdateOrder(order);

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Selling price updated successfully.",
                Result = order
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }

    private async Task<ResponseDTO> CreateDraftComputerForOrderAsync(Models.Order order, string? customerName)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("BuilderAPI");
            var safeCustomerName = string.IsNullOrWhiteSpace(customerName) ? "Customer" : customerName.Trim();
            var createDto = new BuilderComputerCreateDTO
            {
                Name = $"Order #{order.Id} {safeCustomerName}",
                CustomerId = order.CustomerId
            };

            var httpResponse = await client.PostAsJsonAsync("api/computer", createDto);
            var responseContent = await httpResponse.Content.ReadAsStringAsync();

            if (!httpResponse.IsSuccessStatusCode)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = $"Failed to create draft computer. HTTP {(int)httpResponse.StatusCode}."
                };
            }

            var builderResponse = JsonSerializer.Deserialize<ResponseDTO>(
                responseContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (builderResponse == null || !builderResponse.IsSuccess || builderResponse.Result == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = builderResponse?.Message ?? "Builder API returned an invalid response."
                };
            }

            var computerId = ExtractComputerId(builderResponse.Result);
            if (!computerId.HasValue)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Could not read computer id from Builder API response."
                };
            }

            return new ResponseDTO
            {
                IsSuccess = true,
                Result = computerId.Value
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }

    private static int? ExtractComputerId(object result)
    {
        if (result is JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Object)
            {
                if (element.TryGetProperty("id", out var idProp) && idProp.TryGetInt32(out var idLower))
                    return idLower;

                if (element.TryGetProperty("Id", out var idPropPascal) && idPropPascal.TryGetInt32(out var idPascal))
                    return idPascal;
            }
        }

        return null;
    }

    private Guid? GetCurrentUserId()
    {
        var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(userId, out var parsed) ? parsed : null;
    }

    private bool IsCurrentUserAdmin()
    {
        return _httpContextAccessor.HttpContext?.User.IsInRole("Admin") == true;
    }

    private async Task<ReviewStats> GetReviewStatsAsync(IEnumerable<Models.Order> orders, Guid userId)
    {
        var reviewIds = orders
            .Where(x =>
                x.UserId == userId &&
                x.Status == Models.OrderStatus.Completed &&
                x.ReviewId > 0)
            .Select(x => x.ReviewId)
            .Distinct()
            .ToList();

        if (!reviewIds.Any())
        {
            return new ReviewStats(0, 0m);
        }

        var reviews = await _reviewRepository.GetReviewsByIds(reviewIds);
        return reviews.Any()
            ? new ReviewStats(reviews.Count, (decimal)reviews.Average(x => x.Rating))
            : new ReviewStats(0, 0m);
    }

    private static decimal GetUnlockedBudgetCap(ReviewStats reviewStats)
    {
        if (reviewStats.Count == 0)
        {
            return 13000m;
        }

        if (reviewStats.Count < 3 && reviewStats.AverageRating < 2.5m)
        {
            return 13000m;
        }

        return reviewStats.AverageRating switch
        {
            < 2.5m => 0m,
            < 3.0m => 13000m,
            < 3.5m => 17500m,
            < 4.0m => 22000m,
            < 4.5m => 34000m,
            _ => decimal.MaxValue
        };
    }

    private static int GetVisiblePendingLimit(ReviewStats reviewStats)
    {
        if (reviewStats.Count == 0)
        {
            return 2;
        }

        if (reviewStats.Count < 3 && reviewStats.AverageRating < 2.5m)
        {
            return 1;
        }

        return reviewStats.AverageRating switch
        {
            < 2.5m => 0,
            < 3.0m => 1,
            < 3.5m => 2,
            < 4.0m => 3,
            < 4.5m => 5,
            _ => 8
        };
    }

    private static bool IsGameOver(ReviewStats reviewStats)
    {
        return reviewStats.Count >= 3 && reviewStats.AverageRating < 2.5m;
    }

    private sealed record ReviewStats(int Count, decimal AverageRating);
}
