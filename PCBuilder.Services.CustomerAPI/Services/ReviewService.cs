using AutoMapper;
using PCBuilder.Services.CustomerAPI.IRepository;

namespace PCBuilder.Services.CustomerAPI.Services;

public class ReviewService
{
    private readonly IMapper _mapper;
    private readonly IReviewRepository _reviewRepository;
}
