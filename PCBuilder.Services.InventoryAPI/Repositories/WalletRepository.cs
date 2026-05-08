using PCBuilder.Services.InventoryAPI.Data;
using PCBuilder.Services.InventoryAPI.IRepository;
using PCBuilder.Services.InventoryAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace PCBuilder.Services.InventoryAPI.Repositories;

public class WalletRepository : IWalletRepository
{
    private readonly InventoryDbContext _context;

    public WalletRepository(InventoryDbContext context)
    {
        _context = context;
    }

    public async Task<Wallet?> GetByUserIdAsync(Guid userId)
    {
        return await _context.Wallets
            .FirstOrDefaultAsync(x => x.UserId == userId);
    }

    public async Task AddAsync(Wallet wallet)
    {
        await _context.Wallets.AddAsync(wallet);
    }

    public Task UpdateAsync(Wallet wallet)
    {
        _context.Wallets.Update(wallet);
        return Task.CompletedTask;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
