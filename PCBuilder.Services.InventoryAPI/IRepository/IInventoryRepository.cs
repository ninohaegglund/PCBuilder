using PCBuilder.Services.InventoryAPI.Models;

namespace PCBuilder.Services.InventoryAPI.IRepository;

public interface IInventoryRepository
{
    Task<List<InventoryItem>> GetByUserIdAsync(Guid userId);
    Task<InventoryItem?> GetByComponentAsync(Guid userId, string componentType, int componentId);
    Task AddAsync(InventoryItem item);
    Task UpdateAsync(InventoryItem item);
    Task SaveChangesAsync();
}
