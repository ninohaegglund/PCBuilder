using AutoMapper;
using PCBuilder.Service.BuilderServiceAPI.Enums;
using BuilderComputerCreateDTO = PCBuilder.Service.BuilderServiceAPI.DTO.Response.ComputerCreateDTO;
using BuilderResponseDTO = PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response.ResponseDTO;
using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.IRepository;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.Response;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;

namespace PCBuilder.Services.CustomerAPI.Services;

public class OrderService : IOrderService
{

    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository, IMapper mapper, IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
    {
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
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
            if (!IsCurrentUserAdmin())
            {
                orders = orders.Where(x => x.UserId == userId).ToList();
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
                    CustomerName = customer?.Name ?? "Unknown customer",
                    CustomerImageUrl = customer?.ImageUrl ?? string.Empty,
                    ComputerId = order.ComputerId,
                    Budget = order.Budget,
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
                Result = orderDTOs
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
                CustomerName = customer?.Name ?? "Unknown customer",
                CustomerImageUrl = customer?.ImageUrl ?? string.Empty,
                ComputerId = order.ComputerId,
                Budget = order.Budget,
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

            var builderResponse = JsonSerializer.Deserialize<BuilderResponseDTO>(
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
}
