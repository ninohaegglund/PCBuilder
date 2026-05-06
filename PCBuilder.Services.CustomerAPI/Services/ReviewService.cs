using AutoMapper;
using PCBuilder.Service.BuilderServiceAPI.Response;
using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.IRepository;

namespace PCBuilder.Services.CustomerAPI.Services;

public class ReviewService
{
    private readonly IMapper _mapper;
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IMapper mapper, IReviewRepository reviewRepository)
    {
        _mapper = mapper;
        _reviewRepository = reviewRepository;
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

        }
    }
}
