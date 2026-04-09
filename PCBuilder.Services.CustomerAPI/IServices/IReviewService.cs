using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.Response;

namespace PCBuilder.Services.CustomerAPI.IServices
{
    public interface IReviewService
    {
        Task<ResponseDTO> GetAllReviews();
        Task<ResponseDTO> GetReviewsByCustomerId(int id);
    }
}