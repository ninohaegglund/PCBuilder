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

    [HttpGet]
    [Route("order/accept/{orderId:int}", Name = "AcceptOrderWeb")]
    public async Task<IActionResult> AcceptOrder(int orderId)
    {
        ResponseDTO? response = await _orderService.AcceptOrderAsync(orderId);

        if (response != null && response.IsSuccess)
        {
            TempData["success"] = "Order accepted successfully.";
            return RedirectToAction("CreateComputerIndex", "Computer", new { orderId = orderId });
        }

        TempData["error"] = response?.Message ?? "Failed to accept order.";
        return RedirectToAction(nameof(OrderIndex));
    }

    [HttpGet]
    [Route("order/reject/{orderId:int}", Name = "RejectOrderWeb")]
    public async Task<IActionResult> RejectOrder(int orderId)
    {
        ResponseDTO? response = await _orderService.RejectOrderAsync(orderId);

        if (response != null && response.IsSuccess)
        {
            TempData["success"] = "Order rejected successfully.";
        }
        else
        {
            TempData["error"] = response?.Message ?? "Failed to reject order.";
        }

        return RedirectToAction(nameof(OrderIndex));
    }

    [HttpGet]
    [Route("order/complete/{orderId:int}", Name = "CompleteOrderWeb")]
    public async Task<IActionResult> CompleteOrder(int orderId)
    {
        ResponseDTO? response = await _orderService.CompleteOrderAsync(orderId);

        if (response != null && response.IsSuccess)
        {
            TempData["success"] = "Order completed successfully.";
        }
        else
        {
            TempData["error"] = response?.Message ?? "Failed to complete order.";
        }

        return RedirectToAction(nameof(OrderIndex));
    }
}
