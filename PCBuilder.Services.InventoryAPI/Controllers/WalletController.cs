using Microsoft.AspNetCore.Mvc;
using PCBuilder.Services.InventoryAPI.DTO;
using PCBuilder.Services.InventoryAPI.IRepository;
using PCBuilder.Services.InventoryAPI.IServices;

namespace PCBuilder.Services.InventoryAPI.Controllers;

public class WalletController : ControllerBase
{
    private readonly IWalletService _walletService;

    public WalletController(IWalletService walletService)
    {
        _walletService = walletService;
    }
    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<WalletDto>> GetWallet(Guid userId)
    {
        var wallet = await _walletService.GetWalletAsync(userId);
        return Ok(wallet);
    }

    [HttpPost("{userId:guid}/add-funds")]
    public async Task<ActionResult<WalletDto>> AddFunds(Guid userId, AddFundsDto dto)
    {
        var wallet = await _walletService.AddFundsAsync(userId, dto);
        return Ok(wallet);
    }

}
