using AutoMapper;
using Contracts;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.BuilderServiceAPI.Models;
using PCBuilder.Service.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.IRepository;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.Models;

namespace PCBuilder.Services.CustomerAPI.Services;

public class ReviewService
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

            if (orderResult.Result is not Order order)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Order data was not in the expected format.",
                    Result = null
                };
            }

            var computerResult = await _computerService.GetComputerByIdAsync(order.ComputerId);

            if (!computerResult.IsSuccess)
            {
                return computerResult;
            }

            if (computerResult.Result is not ComputerDTO computer)
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
}
