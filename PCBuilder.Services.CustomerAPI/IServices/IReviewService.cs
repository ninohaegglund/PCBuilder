using PCBuilder.Service.BuilderServiceAPI.DTO;
using Contracts;

namespace PCBuilder.Services.CustomerAPI.IServices
{
    public interface IReviewService
    {
        Task<ResponseDTO> GetAllReviewsAsync();
        Task<ResponseDTO> GetReviewsByCustomerIdAsync(int id);
        Task<ResponseDTO> GenerateReviewAsync(int orderId);
    }
}