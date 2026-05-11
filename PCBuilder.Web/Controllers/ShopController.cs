using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Services.InventoryAPI.DTO;
using PCBuilder.Services.InventoryAPI.IServices;
using PCBuilder.Web.ViewModels.Shop;
using System.Text.Json;

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
    public async Task<IActionResult> Buy(string componentType, int componentId, decimal purchasePrice, int quantity, string? returnUrl = null)
    {
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdClaim, out var userId))
        {
            TempData["error"] = "You must be logged in to buy components.";
            return RedirectToShopOrReturn(returnUrl);
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

        return RedirectToShopOrReturn(returnUrl);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> BuyCart(string cartJson, string? returnUrl = null)
    {
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdClaim, out var userId))
        {
            TempData["error"] = "You must be logged in to buy components.";
            return RedirectToShopOrReturn(returnUrl);
        }

        var cartItems = string.IsNullOrWhiteSpace(cartJson)
            ? new List<CartItemDto>()
            : JsonSerializer.Deserialize<List<CartItemDto>>(
                cartJson,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CartItemDto>();

        cartItems = cartItems
            .Where(x => x.ComponentId > 0 && x.Quantity > 0 && x.PurchasePrice > 0 && !string.IsNullOrWhiteSpace(x.ComponentType))
            .ToList();

        if (!cartItems.Any())
        {
            TempData["error"] = "Your cart is empty.";
            return RedirectToShopOrReturn(returnUrl);
        }

        var totalCost = cartItems.Sum(x => x.PurchasePrice * x.Quantity);
        if (!await _walletService.HasEnoughFundsAsync(userId, totalCost))
        {
            TempData["error"] = "Not enough funds in wallet for the full cart.";
            return RedirectToShopOrReturn(returnUrl);
        }

        try
        {
            foreach (var item in cartItems)
            {
                await _inventoryService.BuyComponentAsync(userId, new BuyComponentDto
                {
                    ComponentType = item.ComponentType,
                    ComponentId = item.ComponentId,
                    PurchasePrice = item.PurchasePrice,
                    Quantity = item.Quantity
                });
            }

            TempData["success"] = $"Purchased {cartItems.Sum(x => x.Quantity)} components and added them to inventory.";
            TempData["ClearShopCart"] = true;
        }
        catch (ArgumentException ex)
        {
            TempData["error"] = ex.Message;
        }
        catch (InvalidOperationException ex)
        {
            TempData["error"] = ex.Message;
        }

        return RedirectToShopOrReturn(returnUrl);
    }

    private IActionResult RedirectToShopOrReturn(string? returnUrl)
    {
        return !string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl)
            ? Redirect(returnUrl)
            : RedirectToAction(nameof(Index));
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

    private sealed class CartItemDto
    {
        public string ComponentType { get; set; } = string.Empty;
        public int ComponentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal PurchasePrice { get; set; }
        public int Quantity { get; set; }
    }
}
