using AutoMapper;
using Contracts;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.IRepository;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.Models;
using Newtonsoft.Json;

namespace PCBuilder.Services.CustomerAPI.Services;

public class ReviewService : IReviewService
{
    private readonly IMapper _mapper;
    private readonly IReviewRepository _reviewRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IComputerValidationService _computerValidationService;
    private readonly IOrderService _orderService;
    private readonly IComputerService _computerService;

    public ReviewService(
        IMapper mapper,
        IReviewRepository reviewRepository,
        IOrderRepository orderRepository,
        IComputerValidationService computerValidationService,
        IOrderService orderService,
        IComputerService computerService)
    {
        _mapper = mapper;
        _reviewRepository = reviewRepository;
        _orderRepository = orderRepository;
        _computerValidationService = computerValidationService;
        _orderService = orderService;
        _computerService = computerService;
    }

    public async Task<ResponseDTO> GetAllReviewsAsync()
    {
        try
        {
            var reviews = await _reviewRepository.GetAllReviews();
            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Reviews retrieved successfully", 
                Result = reviews
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = $"Error retrieving reviews: {ex.Message}",
                Result = null
            };
        }
    }

    public async Task<ResponseDTO> GetReviewsByCustomerIdAsync(int id)
    {
        try
        {
            var reviews = await _reviewRepository.GetReviewById(id);
            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Reviews retrieved successfully",
                Result = reviews
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = $"Error retrieving reviews: {ex.Message}",
                Result = null
            };
        }
    }

    public async Task<ResponseDTO> GenerateReviewAsync(int orderId)
    {
        try
        {
            var orderResult = await _orderService.GetOrderByIdAsync(orderId);

            if (!orderResult.IsSuccess)
            {
                return orderResult;
            }

            var orderDto = ToTypedResult<OrderDTO>(orderResult.Result);
            if (orderDto == null)
            {
                var orderList = ToTypedResult<OrderListDTO>(orderResult.Result);
                if (orderList != null)
                {
                    orderDto = new OrderDTO
                    {
                        Id = orderList.Id,
                        CustomerId = orderList.CustomerId,
                        UserId = orderList.UserId,
                        ReviewId = orderList.ReviewId,
                        ComputerId = orderList.ComputerId,
                        Budget = orderList.Budget,
                        SellingPrice = orderList.SellingPrice,
                        Description = orderList.Description,
                        DetailedDescription = orderList.DetailedDescription,
                        Status = orderList.Status,
                        CreatedAt = orderList.CreatedAt
                    };
                }
            }

            if (orderDto == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Order data was not in the expected format.",
                    Result = null
                };
            }

            Review? existingBrokenReview = null;
            if (orderDto.ReviewId > 0)
            {
                var existingReview = await _reviewRepository.GetReviewById(orderDto.ReviewId);
                if (existingReview != null)
                {
                    if (IsTechnicalReviewText(existingReview.Comment) || IsTechnicalReviewText(existingReview.Title))
                    {
                        existingBrokenReview = existingReview;
                    }
                    else
                    {
                        return new ResponseDTO
                        {
                            IsSuccess = existingReview.Rating >= 4,
                            Message = "Review already completed.",
                            Result = existingReview.Comment ?? existingReview.Title
                        };
                    }
                }
            }

            if (!orderDto.ComputerId.HasValue)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Order does not have a connected computer.",
                    Result = null
                };
            }

            var order = new Order
            {
                Id = orderDto.Id,
                CustomerId = orderDto.CustomerId,
                UserId = orderDto.UserId,
                ReviewId = orderDto.ReviewId,
                ComputerId = orderDto.ComputerId,
                Budget = orderDto.Budget,
                SellingPrice = orderDto.SellingPrice,
                Description = orderDto.Description,
                DetailedDescription = orderDto.DetailedDescription,
                Status = (Models.OrderStatus)orderDto.Status,
                CreatedAt = orderDto.CreatedAt
            };

            var computerResult = await _computerService.GetComputerByIdAsync(orderDto.ComputerId.Value);

            if (!computerResult.IsSuccess)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = computerResult.Message ?? "The customer review could not inspect the finished computer.",
                    Result = null
                };
            }

            var computer = ToTypedResult<ComputerDTO>(computerResult.Result);
            if (computer == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Computer data was not in the expected format.",
                    Result = null
                };
            }

            var gpuFitsResult = await _computerValidationService.CheckIfGpuFitsInCaseAsync(order, computer);
            var coolingResult = await _computerValidationService.CheckCoolingIsSufficientAsync(order, computer);
            var psuResult = await _computerValidationService.CheckPsuCanPowerAsync(order, computer);
            var efficiencyResult = await _computerValidationService.CheckEfficiencyIsGoodAsync(order, computer);
            var priceResult = await _computerValidationService.CheckPriceIsWithinBudgetAsync(order, computer);
            var peripheralsResult = await _computerValidationService.CheckRequestedPeripheralsAsync(order, computer);

            var checks = new[]
            {
                gpuFitsResult,
                coolingResult,
                psuResult,
                efficiencyResult,
                priceResult,
                peripheralsResult
            };
            var allPassed = checks.All(x => x.IsSuccess);
            var failedChecks = checks.Count(x => !x.IsSuccess);
            var rating = Math.Clamp(5 - failedChecks, 1, 5);
            var budgetOverRatio = order.Budget > 0
                ? (order.SellingPrice - order.Budget) / order.Budget
                : 0m;

            if (budgetOverRatio > 0.15m)
            {
                rating = Math.Min(rating, 2);
            }
            else if (budgetOverRatio > 0.05m)
            {
                rating = Math.Min(rating, 3);
            }

            var reviewComment = allPassed
                ? "The customer is very happy with the build and would recommend your workshop."
                : checks.FirstOrDefault(x => !x.IsSuccess && !string.IsNullOrWhiteSpace(x.Message))?.Message
                    ?? "The customer had some concerns about the finished build.";

            var savedReview = existingBrokenReview ?? new Review();
            savedReview.Title = $"{rating}-star customer review";
            savedReview.Comment = reviewComment;
            savedReview.CreatedDate = DateTime.UtcNow;
            savedReview.Rating = rating;

            if (existingBrokenReview != null)
            {
                await _reviewRepository.UpdateReview(savedReview);
            }
            else
            {
                await _reviewRepository.AddReview(savedReview);
            }

            var storedOrder = await _orderRepository.GetOrderById(orderDto.Id);
            if (storedOrder != null && storedOrder.ReviewId == 0)
            {
                storedOrder.ReviewId = savedReview.Id;
                await _orderRepository.UpdateOrder(storedOrder);
            }

            return new ResponseDTO
            {
                IsSuccess = allPassed,
                Message = allPassed
                    ? "Review completed successfully."
                    : "One or more checks failed.",
                Result = new
                {
                    Rating = rating,
                    GPUFit = new { gpuFitsResult.IsSuccess, gpuFitsResult.Message },
                    Cooling = new { coolingResult.IsSuccess, coolingResult.Message },
                    PSU = new { psuResult.IsSuccess, psuResult.Message },
                    Efficiency = new { efficiencyResult.IsSuccess, efficiencyResult.Message },
                    Budget = new { priceResult.IsSuccess, priceResult.Message },
                    PeripheralRequirements = new { peripheralsResult.IsSuccess, peripheralsResult.Message }
                }
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = $"Error during review: {ex.Message}",
                Result = null
            };
        }
    }

    private static T? ToTypedResult<T>(object? result)
    {
        if (result is T typed)
        {
            return typed;
        }

        if (result == null)
        {
            return default;
        }

        return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(result));
    }

    private static bool IsTechnicalReviewText(string? text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return false;
        }

        return text.Contains("Error mapping types", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("Missing type map configuration", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("Object serialized", StringComparison.OrdinalIgnoreCase) ||
               text.Contains("Exception", StringComparison.OrdinalIgnoreCase);
    }
}
