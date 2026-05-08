using PCBuilder.Services.InventoryAPI.DTO;
using PCBuilder.Services.InventoryAPI.IRepository;
using PCBuilder.Services.InventoryAPI.IServices;
using PCBuilder.Services.InventoryAPI.Models;

namespace PCBuilder.Services.InventoryAPI.Services;

public class WalletService : IWalletService
{
    private const decimal DefaultStartingBalance = 10000m;

    private readonly IWalletRepository _walletRepository;

    public WalletService(IWalletRepository walletRepository)
    {
        _walletRepository = walletRepository;
    }

    public async Task<WalletDto> GetWalletAsync(Guid userId)
    {
        var wallet = await GetOrCreateWalletAsync(userId);

        return MapToDto(wallet);
    }

    public async Task<WalletDto> AddFundsAsync(Guid userId, AddFundsDto dto)
    {
        if (dto.Amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        var wallet = await GetOrCreateWalletAsync(userId);

        wallet.Balance += dto.Amount;
        wallet.UpdatedAt = DateTime.UtcNow;

        await _walletRepository.UpdateAsync(wallet);
        await _walletRepository.SaveChangesAsync();

        return MapToDto(wallet);
    }

    public async Task<bool> HasEnoughFundsAsync(Guid userId, decimal amount)
    {
        if (amount < 0)
        {
            return false;
        }

        var wallet = await GetOrCreateWalletAsync(userId);

        return wallet.Balance >= amount;
    }

    public async Task WithdrawAsync(Guid userId, decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Amount must be greater than zero.");
        }

        var wallet = await GetOrCreateWalletAsync(userId);

        if (wallet.Balance < amount)
        {
            throw new InvalidOperationException("Not enough funds in wallet.");
        }

        wallet.Balance -= amount;
        wallet.UpdatedAt = DateTime.UtcNow;

        await _walletRepository.UpdateAsync(wallet);
        await _walletRepository.SaveChangesAsync();
    }

    private async Task<Wallet> GetOrCreateWalletAsync(Guid userId)
    {
        var wallet = await _walletRepository.GetByUserIdAsync(userId);

        if (wallet != null)
        {
            return wallet;
        }

        wallet = new Wallet
        {
            UserId = userId,
            Balance = DefaultStartingBalance,
            CreatedAt = DateTime.UtcNow
        };

        await _walletRepository.AddAsync(wallet);
        await _walletRepository.SaveChangesAsync();

        return wallet;
    }

    private static WalletDto MapToDto(Wallet wallet)
    {
        return new WalletDto
        {
            Id = wallet.Id,
            UserId = wallet.UserId,
            Balance = wallet.Balance
        };
    }
}