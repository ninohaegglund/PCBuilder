using PCBuilder.Services.CustomerAPI.DTO;
using Contracts;

namespace PCBuilder.Services.CustomerAPI.IServices
{
    public interface ICustomerService
    {
        Task<ResponseDTO> GetAllCustomersAsync();
        Task<ResponseDTO> GetCustomerByIdAsync(int id);
    }
}