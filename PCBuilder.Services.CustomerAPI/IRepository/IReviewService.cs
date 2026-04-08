using PCBuilder.Services.CustomerAPI.Models;

namespace PCBuilder.Services.CustomerAPI.IRepository;

public interface IReviewRepository
{
    Task<List<Review>> GetAllReviews();
    Task<Review?> GetReviewById(int id);
}