using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.Response;

namespace PCBuilder.Services.CustomerAPI.IServices
{
    public interface IReviewService
    {
        Task<ResponseDTO> GetAllReviewsAsync();
        Task<ResponseDTO> GetReviewsByCustomerIdAsync(int id);
    }
}