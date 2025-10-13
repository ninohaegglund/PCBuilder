using PCBuilder.Services.CustomerAPI.Models;

namespace PCBuilder.Services.CustomerAPI.IRepository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer?> GetCustomerById(int id);
    }
}