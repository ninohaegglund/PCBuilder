using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Services.InventoryAPI.IServices;
using PCBuilder.Web.ViewModels.Inventory;

namespace PCBuilder.Web.Controllers;

public class InventoryController : Controller
{
    private readonly IInventoryService _inventoryService;
    private readonly IComponentService _componentService;

    public InventoryController(IInventoryService inventoryService, IComponentService componentService)
    {
        _inventoryService = inventoryService;
        _componentService = componentService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (!Guid.TryParse(userIdClaim, out var userId))
        {
            TempData["error"] = "You must be logged in to view inventory.";
            return RedirectToAction("Index", "Home");
        }

        var inventoryItems = await _inventoryService.GetInventoryAsync(userId);
        var components = await _componentService.GetAllComponentsAsync();

        var viewModel = new InventoryViewModel
        {
            Items = inventoryItems.Select(item => new InventoryItemViewModel
            {
                Id = item.Id,
                ComponentType = item.ComponentType,
                ComponentId = item.ComponentId,
                DisplayName = ResolveDisplayName(components, item.ComponentType, item.ComponentId),
                Quantity = item.Quantity,
                PurchasePrice = item.PurchasePrice,
                PurchasedAt = item.PurchasedAt
            }).ToList()
        };

        return View(viewModel);
    }

    private static string ResolveDisplayName(dynamic components, string componentType, int componentId)
    {
        return componentType switch
        {
            "CPU" => components.Cpus.FirstOrDefault(x => x.Id == componentId)?.Name,
            "GPU" => components.Gpus.FirstOrDefault(x => x.Id == componentId)?.Name,
            "RAM" => components.Rams.FirstOrDefault(x => x.Id == componentId)?.Name,
            "Motherboard" => components.Motherboards.FirstOrDefault(x => x.Id == componentId)?.Name,
            "Case" => components.Cases.FirstOrDefault(x => x.Id == componentId)?.Name,
            "PSU" => components.Psus.FirstOrDefault(x => x.Id == componentId)?.Name,
            "CPUCooler" => components.CpuCoolers.FirstOrDefault(x => x.Id == componentId)?.Name,
            "CaseFan" => components.CaseFans.FirstOrDefault(x => x.Id == componentId)?.Name,
            "InternalStorage" => components.InternalStorages.FirstOrDefault(x => x.Id == componentId)?.Name,
            "ExternalStorage" => components.ExternalStorages.FirstOrDefault(x => x.Id == componentId)?.Name,
            "Monitor" => components.Monitors.FirstOrDefault(x => x.Id == componentId)?.Name,
            "Keyboard" => components.Keyboards.FirstOrDefault(x => x.Id == componentId)?.Name,
            "Mouse" => components.Mice.FirstOrDefault(x => x.Id == componentId)?.Name,
            "Headphones" => components.Headphones.FirstOrDefault(x => x.Id == componentId)?.Name,
            "Speakers" => components.Speakers.FirstOrDefault(x => x.Id == componentId)?.Name,
            _ => null
        } ?? $"{componentType} #{componentId}";
    }
}
