using Microsoft.EntityFrameworkCore;
using PCBuilder.Services.InventoryAPI.Data;
using PCBuilder.Services.InventoryAPI.IRepository;
using PCBuilder.Services.InventoryAPI.Models;

namespace PCBuilder.Services.InventoryAPI.Repositories;

public class InventoryRepository : IInventoryRepository
{
    private readonly InventoryDbContext _context;

    public InventoryRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<List<InventoryItem>> GetByUserIdAsync(Guid userId)
    {
        return await _context.InventoryItems
            .Where(x => x.UserId == userId)
            .ToListAsync();
    }

    public async Task<InventoryItem?> GetByComponentAsync(Guid userId, string componentType, int componentId)
    {
        return await _context.InventoryItems
            .FirstOrDefaultAsync(x => x.UserId == userId && x.ComponentType == componentType && x.ComponentId == componentId);
    }

    public async Task AddAsync(InventoryItem item)
    {
        await _context.InventoryItems.AddAsync(item);
    }

    public Task UpdateAsync(InventoryItem item)
    {
        _context.InventoryItems.Update(item);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
