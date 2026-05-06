using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Web.ViewModels.Shop;

namespace PCBuilder.Web.Controllers;

public class ShopController : Controller
{
    private readonly IComponentService _componentService;

    public ShopController(IComponentService componentService)
    {
        _componentService = componentService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var components = await _componentService.GetAllComponentsAsync();

        var viewModel = new ShopViewModel
        {
            Components = components
        };

        return View(viewModel);
    }
}
