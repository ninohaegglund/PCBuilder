using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Services.InventoryAPI.DTO;
using PCBuilder.Services.InventoryAPI.IServices;
using PCBuilder.Web.ViewModels.Shop;

namespace PCBuilder.Web.Controllers;

public class ShopController : Controller
{
    private readonly IComponentService _componentService;
    private readonly IInventoryService _inventoryService;
    private readonly IWalletService _walletService;

    public ShopController(
        IComponentService componentService,
        IInventoryService inventoryService,
        IWalletService walletService)
    {
        _componentService = componentService;
        _inventoryService = inventoryService;
        _walletService = walletService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var components = await _componentService.GetAllComponentsAsync();
        var walletBalance = await GetWalletBalanceAsync();

        var viewModel = new ShopViewModel
        {
            Components = components,
            WalletBalance = walletBalance
        };

        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Buy(string componentType, int componentId, decimal purchasePrice, int quantity)
    {
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdClaim, out var userId))
        {
            TempData["error"] = "You must be logged in to buy components.";
            return RedirectToAction(nameof(Index));
        }

        var dto = new BuyComponentDto
        {
            ComponentType = componentType,
            ComponentId = componentId,
            PurchasePrice = purchasePrice,
            Quantity = quantity
        };

        try
        {
            await _inventoryService.BuyComponentAsync(userId, dto);
            TempData["success"] = "Component purchased and added to inventory.";
        }
        catch (ArgumentException ex)
        {
            TempData["error"] = ex.Message;
        }
        catch (InvalidOperationException ex)
        {
            TempData["error"] = ex.Message;
        }

        return RedirectToAction(nameof(Index));
    }

    private async Task<decimal?> GetWalletBalanceAsync()
    {
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdClaim, out var userId))
        {
            return null;
        }

        var wallet = await _walletService.GetWalletAsync(userId);
        return wallet.Balance;
    }
}
