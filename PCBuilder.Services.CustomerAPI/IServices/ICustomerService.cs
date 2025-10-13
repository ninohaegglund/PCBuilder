using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.Response;

namespace PCBuilder.Services.CustomerAPI.IServices
{
    public interface ICustomerService
    {
        Task<ResponseDTO> GetAllCustomersAsync();
        Task<ResponseDTO> GetCustomerByIdAsync(int id);
    }
}