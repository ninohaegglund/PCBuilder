using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.Response;
using PCBuilder.Web.ViewModels.Computer;

namespace PCBuilder.Web.Controllers;

[Authorize]
public class OrderController : Controller
{

    private readonly IOrderService _orderService;
    private readonly IComputerService _computerService;

    public OrderController(IOrderService orderService, IComputerService computerService)
    {
        _orderService = orderService;
        _computerService = computerService;
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
    [Authorize(Roles = "Admin,User,Customer")]
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
    [Authorize(Roles = "Admin,User,Customer")]
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
    [Authorize(Roles = "Admin,User,Customer")]
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

    public async Task<IActionResult> PriceSummaryIndex(int id)
    {
        var vm = new PriceSummaryVM();

        var orderResponse = await _orderService.GetOrderByIdAsync(id);

        if (orderResponse == null || !orderResponse.IsSuccess || orderResponse.Result == null)
        {
            TempData["error"] = orderResponse?.Message ?? "Order could not be found.";
            return RedirectToAction(nameof(OrderIndex));
        }

        vm.Order = JsonConvert.DeserializeObject<OrderDTO>(
            JsonConvert.SerializeObject(orderResponse.Result));

        if (vm.Order == null)
        {
            TempData["error"] = "Order data could not be loaded.";
            return RedirectToAction(nameof(OrderIndex));
        }

        if (!vm.Order.ComputerId.HasValue)
        {
            TempData["error"] = "This order does not have a computer connected.";
            return RedirectToAction(nameof(OrderIndex));
        }

        var computerResponse = await _computerService.GetComputerByIdAsync(vm.Order.ComputerId.Value);

        if (computerResponse == null || !computerResponse.IsSuccess || computerResponse.Result == null)
        {
            TempData["error"] = computerResponse?.Message ?? "Computer could not be found.";
            return RedirectToAction(nameof(OrderIndex));
        }

        vm.Computer = JsonConvert.DeserializeObject<ComputerDTO>(
            JsonConvert.SerializeObject(computerResponse.Result));

        if (vm.Computer == null)
        {
            TempData["error"] = "Computer data could not be loaded.";
            return RedirectToAction(nameof(OrderIndex));
        }

        return View(vm);
    }

}
