using PCBuilder.Services.InventoryAPI.Models;

namespace PCBuilder.Services.InventoryAPI.IRepository;

public interface IWalletRepository
{
    Task<Wallet?> GetByUserIdAsync(Guid userId);
    Task AddAsync(Wallet wallet);
    Task UpdateAsync(Wallet wallet);
    Task SaveChangesAsync();
}
