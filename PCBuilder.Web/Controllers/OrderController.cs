using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.Response;

namespace PCBuilder.Web.Controllers;

public class OrderController : Controller
{

    private readonly IOrderService _orderService;
    public OrderController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    public async Task<IActionResult> OrderIndex()
    {
        List<OrderListDTO>? list = new();

        ResponseDTO? response = await _orderService.GetAllOrdersAsync();

        if (response != null && response.IsSuccess)
        {
            list = JsonConvert.DeserializeObject<List<OrderListDTO>>(
                JsonConvert.SerializeObject(response.Result));
        }
        else
        {
            TempData["error"] = response?.Message;
        }

        return View(list);
    }
}
