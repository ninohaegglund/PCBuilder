using AutoMapper;
using PCBuilder.Services.CustomerAPI.IRepository;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.Response;


namespace PCBuilder.Services.CustomerAPI.Services;

public class ReviewService : IReviewService 
{
    private readonly IMapper _mapper;
    private readonly IReviewRepository _reviewRepository;

    public ReviewService(IMapper mapper, IReviewRepository reviewRepository)
    {
        _mapper = mapper;
        _reviewRepository = reviewRepository;
    }

    public async Task<ResponseDTO> GetAllReviews()
    {
        var reviews = await _reviewRepository.GetAllReviews();
        return new ResponseDTO
        {
            IsSuccess = true,
            Result = reviews,
            Message = "Reviews retrieved successfully"
        };
    }
    public async Task<ResponseDTO> GetReviewsByCustomerId(int id)
    {
        try
        {
            var reviews = await _reviewRepository.GetReviewById(id);
            return new ResponseDTO
            {
                IsSuccess = true,
                Result = reviews,
            };
        }

        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = $"An error occurred: {ex.Message}"
            };
        }
    }
}
