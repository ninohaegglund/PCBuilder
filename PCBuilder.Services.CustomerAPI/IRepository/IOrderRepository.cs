using PCBuilder.Services.CustomerAPI.Models;

namespace PCBuilder.Services.CustomerAPI.IRepository;

public interface IOrderRepository
{
    Task<List<Order>> GetAllOrders();
    Task<Order?> GetOrderById(int id);
    Task UpdateOrder(Order order);
}
