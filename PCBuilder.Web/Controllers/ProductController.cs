using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PCBuilder.Services.OrderAPI.IService;
using PCBuilder.Services.OrderAPI.Models.Dto;

namespace PCBuilder.Web.Controllers;

public class ProductController : Controller
{

    private readonly IProductService _productService;
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> ProductIndex()
    {
        List<ProductDto>? list = new();

        ResponseDto? response = await _productService.GetAllProductAsync();

        if (response != null && response.IsSuccess)
        {
            list = (response.Result as IEnumerable<ProductDto>)?.ToList() ?? new List<ProductDto>();

        }
        else
        {
            TempData["error"] = response?.Message;
        }

        return View(list);
    }
}
