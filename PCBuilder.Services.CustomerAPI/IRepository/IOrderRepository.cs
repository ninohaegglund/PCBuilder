using PCBuilder.Services.CustomerAPI.Models;

namespace PCBuilder.Services.CustomerAPI.IRepositories;

public interface IOrderRepository
{
    Task<List<Order>> GetAllOrders();
    Task<Order?> GetOrderById(int id);
}
