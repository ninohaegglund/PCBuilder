using AutoMapper;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Services.CustomerAPI.IRepository;
using PCBuilder.Services.CustomerAPI.Response;

namespace PCBuilder.Services.CustomerAPI.Services;

public class ReviewService
{
    private readonly IMapper _mapper;
    private readonly IReviewRepository _reviewRepository;
    private readonly IComputerValidationService _computerValidationService;
    public ReviewService(IMapper mapper, IReviewRepository reviewRepository, IComputerValidationService computerValidationService)
    {
        _mapper = mapper;
        _reviewRepository = reviewRepository;
        _computerValidationService = computerValidationService;
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

    public async Task<ResponseDTO> GenerateReviewAsync(BuildReviewRequestDto info)
    {
        try
        {
            if (info.GpuIds != null && info.CaseId != null)
            {
                var gpuCheck = await _computerValidationService.CheckGpuFitsInCaseAsync(info.GpuIds, info.CaseId.Value);

                if (!gpuCheck.IsSuccess)
                {
                    return gpuCheck;
                }
            }

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Review completed successfully."
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

    //psu can power everything

    //cooling is enough

    //efficiency is good

    //price is within budget
}
