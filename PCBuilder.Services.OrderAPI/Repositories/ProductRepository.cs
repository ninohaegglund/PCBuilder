using Microsoft.EntityFrameworkCore;
using PCBuilder.Services.OrderAPI.Data;
using PCBuilder.Services.OrderAPI.IRepository;
using PCBuilder.Services.OrderAPI.Models;
using System.Linq.Expressions;

namespace PCBuilder.Services.OrderAPI.Repositories;

public class ProductRepository(OrderDbContext context) : BaseRepository<Product>(context), IProductRepository
{
    public override async Task<Product?> GetAsync(Expression<Func<Product, bool>> expression)
    {
        var entity = await _context.Products
            .Include(x => x.Name)
            .FirstOrDefaultAsync(expression);
        return entity;
    }  
}
