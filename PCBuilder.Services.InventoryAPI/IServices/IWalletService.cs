using PCBuilder.Services.InventoryAPI.DTO;

namespace PCBuilder.Services.InventoryAPI.IServices;

public interface IWalletService
{
    Task<WalletDto> GetWalletAsync(Guid userId);
    Task<WalletDto> AddFundsAsync(Guid userId, AddFundsDto dto);
    Task<bool> HasEnoughFundsAsync(Guid userId, decimal amount);
    Task WithdrawAsync(Guid userId, decimal amount);
}
