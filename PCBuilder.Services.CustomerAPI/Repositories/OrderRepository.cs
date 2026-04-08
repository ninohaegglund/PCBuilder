using Microsoft.EntityFrameworkCore;
using PCBuilder.Services.CustomerAPI.Data;
using PCBuilder.Services.CustomerAPI.IRepository;
using PCBuilder.Services.CustomerAPI.Models;

namespace PCBuilder.Services.CustomerAPI.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly CustomerDbContext _context;
    public OrderRepository(CustomerDbContext context)
    {
        _context = context;
    }

    public async Task<List<Order>> GetAllOrders()
    {
        var orders = await _context.Orders.ToListAsync();
        return orders;
    }

    public async Task<Order?> GetOrderById(int id)
    {
        var order = await _context.Orders.FirstOrDefaultAsync(c => c.Id == id);
        return order;
    }

    public async Task UpdateOrder(Order order)
    {
        _context.Orders.Update(order);
        await _context.SaveChangesAsync();
    }
}
