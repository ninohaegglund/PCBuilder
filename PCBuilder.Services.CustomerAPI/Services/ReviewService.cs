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
    private readonly IComputerValidationService _computerValidationService;
    private readonly IOrderService _orderService;
    private readonly IComputerService _computerService;
    public ReviewService(IMapper mapper, IReviewRepository reviewRepository, IComputerValidationService computerValidationService, IOrderService orderService, IComputerService computerService)
    {
        _mapper = mapper;
        _reviewRepository = reviewRepository;
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
                return computerResult;
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

            var allPassed = gpuFitsResult.IsSuccess &&       
                            coolingResult.IsSuccess &&
                            psuResult.IsSuccess &&
                            efficiencyResult.IsSuccess &&
                            priceResult.IsSuccess;

            return new ResponseDTO
            {
                IsSuccess = allPassed,
                Message = allPassed
                    ? "Review completed successfully."
                    : "One or more checks failed.",
                Result = new
                {
                    GPUFit = new { gpuFitsResult.IsSuccess, gpuFitsResult.Message },
                    Cooling = new { coolingResult.IsSuccess, coolingResult.Message },
                    PSU = new { psuResult.IsSuccess, psuResult.Message },
                    Efficiency = new { efficiencyResult.IsSuccess, efficiencyResult.Message },
                    Budget = new { priceResult.IsSuccess, priceResult.Message }
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
}
