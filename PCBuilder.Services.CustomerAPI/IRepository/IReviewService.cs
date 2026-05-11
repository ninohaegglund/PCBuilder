using PCBuilder.Services.CustomerAPI.Models;

namespace PCBuilder.Services.CustomerAPI.IRepository;

public interface IReviewRepository
{
    Task<List<Review>> GetAllReviews();
    Task<Review?> GetReviewById(int id);
    Task<List<Review>> GetReviewsByIds(IEnumerable<int> ids);
    Task AddReview(Review review);
    Task UpdateReview(Review review);
}
