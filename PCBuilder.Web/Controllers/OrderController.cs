using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.IServices;
using Contracts;
using PCBuilder.Web.ViewModels.Computer;
using PCBuilder.Services.InventoryAPI.DTO;
using PCBuilder.Services.InventoryAPI.IServices;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;

namespace PCBuilder.Web.Controllers;

[Authorize]
public class OrderController : Controller
{
    private const decimal CustomerRefusalBudgetMultiplier = 1.15m;

    private readonly IOrderService _orderService;
    private readonly IComputerService _computerService;
    private readonly ICustomerService _customerService;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IInventoryService _inventoryService;
    private readonly IWalletService _walletService;
    private string? _lastOrderMessage;

    public OrderController(
        IOrderService orderService,
        IComputerService computerService,
        ICustomerService customerService,
        IHttpClientFactory httpClientFactory,
        IHttpContextAccessor httpContextAccessor,
        IInventoryService inventoryService,
        IWalletService walletService)
    {
        _orderService = orderService;
        _computerService = computerService;
        _customerService = customerService;
        _httpClientFactory = httpClientFactory;
        _httpContextAccessor = httpContextAccessor;
        _inventoryService = inventoryService;
        _walletService = walletService;
    }

    public async Task<IActionResult> OrderIndex()
    {
        var orders = await LoadOrdersAsync();
        var historyOrders = orders
            .Where(IsHistoryOrder)
            .ToList();

        ViewBag.HistoryCount = historyOrders.Count;
        ViewBag.CompletedCount = historyOrders.Count(x => x.Status == OrderStatus.Completed);
        ViewBag.RejectedCount = historyOrders.Count(x => x.Status == OrderStatus.Rejected);
        ViewBag.IsGameOver = string.Equals(_lastOrderMessage, "GAME_OVER", StringComparison.OrdinalIgnoreCase);

        return View(orders
            .Where(x => !IsHistoryOrder(x))
            .OrderBy(x => x.Status == OrderStatus.InProgress ? 0 : x.Status == OrderStatus.Pending ? 1 : 2)
            .ThenBy(x => x.Status == OrderStatus.InProgress ? 0 : x.Budget)
            .ThenByDescending(x => x.CreatedAt)
            .ToList());
    }

    public async Task<IActionResult> OrderHistory()
    {
        var orders = await LoadOrdersAsync();
        return View(orders
            .Where(IsHistoryOrder)
            .OrderByDescending(x => x.CreatedAt)
            .ToList());
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

        var customerResponse = await _customerService.GetCustomerByIdAsync(vm.Order.CustomerId);

        if (customerResponse != null && customerResponse.IsSuccess && customerResponse.Result != null)
        {
            vm.Customer = JsonConvert.DeserializeObject<CustomerDTO>(
                JsonConvert.SerializeObject(customerResponse.Result));
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

        if (vm.Order.Status == OrderStatus.Completed && !TempData.ContainsKey("ReviewResponse"))
        {
            vm.ReviewResponse = await GenerateReviewAsync(id);
        }

        return View(vm);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> FinishBuild(int orderId, decimal sellingPrice)
    {
        if (!TryGetCurrentUserId(out var userId))
        {
            TempData["error"] = "You must be logged in to finish a build.";
            return RedirectToAction(nameof(PriceSummaryIndex), new { id = orderId });
        }

        var orderResponse = await _orderService.GetOrderByIdAsync(orderId);
        var order = orderResponse != null && orderResponse.IsSuccess && orderResponse.Result != null
            ? JsonConvert.DeserializeObject<OrderDTO>(JsonConvert.SerializeObject(orderResponse.Result))
            : null;

        if (order == null)
        {
            TempData["error"] = orderResponse?.Message ?? "Order could not be found.";
            return RedirectToAction(nameof(OrderIndex));
        }

        if (order.Status == OrderStatus.Completed)
        {
            TempData["error"] = "This order is already completed.";
            return RedirectToAction(nameof(PriceSummaryIndex), new { id = orderId });
        }

        if (sellingPrice <= 0)
        {
            TempData["error"] = "Sale price must be greater than 0 kr.";
            return RedirectToAction(nameof(PriceSummaryIndex), new { id = orderId });
        }

        var refusalLimit = order.Budget * CustomerRefusalBudgetMultiplier;
        if (order.Budget > 0 && sellingPrice > refusalLimit)
        {
            TempData["error"] = $"The customer refuses to pay {sellingPrice:N0} kr. Their absolute limit is about {refusalLimit:N0} kr.";
            return RedirectToAction(nameof(PriceSummaryIndex), new { id = orderId });
        }

        if (!order.ComputerId.HasValue)
        {
            TempData["error"] = "Cannot finish an order without a connected computer.";
            return RedirectToAction(nameof(PriceSummaryIndex), new { id = orderId });
        }

        var computerResponse = await _computerService.GetComputerByIdAsync(order.ComputerId.Value);
        var computer = computerResponse != null && computerResponse.IsSuccess && computerResponse.Result != null
            ? JsonConvert.DeserializeObject<ComputerDTO>(JsonConvert.SerializeObject(computerResponse.Result))
            : null;

        if (computer == null)
        {
            TempData["error"] = computerResponse?.Message ?? "Computer could not be loaded.";
            return RedirectToAction(nameof(PriceSummaryIndex), new { id = orderId });
        }

        var usedItems = GetUsedInventoryItems(computer);

        try
        {
            await _inventoryService.EnsureInventoryItemsAsync(userId, usedItems);
        }
        catch (InvalidOperationException ex)
        {
            TempData["error"] = $"Inventory is missing parts for this build: {ex.Message}";
            return RedirectToAction(nameof(PriceSummaryIndex), new { id = orderId });
        }
        catch (ArgumentException ex)
        {
            TempData["error"] = ex.Message;
            return RedirectToAction(nameof(PriceSummaryIndex), new { id = orderId });
        }

        var response = await _orderService.UpdateSellingPriceAsync(orderId, sellingPrice);

        if (response != null && response.IsSuccess)
        {
            await _inventoryService.UseInventoryItemsAsync(userId, usedItems);
            await _walletService.AddFundsAsync(userId, new AddFundsDto { Amount = sellingPrice });
            var reviewResponse = await GenerateReviewAsync(orderId);

            TempData["success"] = "Build finished and selling price saved.";
            TempData["ShowReview"] = true;
            TempData["ReviewResponse"] = JsonConvert.SerializeObject(reviewResponse);

            return RedirectToAction(nameof(PriceSummaryIndex), new { id = orderId, review = true });
        }

        TempData["error"] = response?.Message ?? "Failed to save selling price.";
        return RedirectToAction(nameof(PriceSummaryIndex), new { id = orderId });
    }

    private bool TryGetCurrentUserId(out Guid userId)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(userIdClaim, out userId);
    }

    private async Task<List<OrderListDTO>> LoadOrdersAsync()
    {
        ResponseDTO? response = await _orderService.GetAllOrdersAsync();
        _lastOrderMessage = response?.Message;

        if (response != null && response.IsSuccess)
        {
            return JsonConvert.DeserializeObject<List<OrderListDTO>>(
                JsonConvert.SerializeObject(response.Result)) ?? new List<OrderListDTO>();
        }

        TempData["error"] = response?.Message;
        return new List<OrderListDTO>();
    }

    private static bool IsHistoryOrder(OrderListDTO order)
    {
        return order.Status is OrderStatus.Completed or OrderStatus.Rejected;
    }

    private static List<UseInventoryItemDto> GetUsedInventoryItems(ComputerDTO computer)
    {
        var items = new List<UseInventoryItemDto>();

        AddSingle(items, "CPU", computer.CpuId);
        AddSingle(items, "Motherboard", computer.MotherboardId);
        AddSingle(items, "Case", computer.CaseId);
        AddSingle(items, "PSU", computer.PowerSupplyId);
        AddSingle(items, "CPUCooler", computer.CpuCoolerId);
        AddSingle(items, "Keyboard", computer.KeyboardId);
        AddSingle(items, "Mouse", computer.MouseId);
        AddSingle(items, "Headphones", computer.HeadphonesId);

        AddMany(items, "GPU", computer.GpuIds);
        AddMany(items, "RAM", computer.RamIds);
        AddMany(items, "InternalStorage", computer.InternalStorageIds ?? computer.InternalStorages?.Select(x => x.Id));
        AddMany(items, "ExternalStorage", computer.ExternalStorageIds ?? computer.ExternalStorages?.Select(x => x.Id));
        AddMany(items, "CaseFan", computer.CaseFanIds);
        AddMany(items, "Monitor", computer.MonitorIds);
        AddMany(items, "Speakers", computer.SpeakerIds);

        return items
            .GroupBy(x => new { x.ComponentType, x.ComponentId })
            .Select(x => new UseInventoryItemDto
            {
                ComponentType = x.Key.ComponentType,
                ComponentId = x.Key.ComponentId,
                Quantity = x.Sum(item => item.Quantity)
            })
            .ToList();
    }

    private static void AddSingle(List<UseInventoryItemDto> items, string componentType, int? componentId)
    {
        if (componentId.HasValue)
        {
            items.Add(new UseInventoryItemDto
            {
                ComponentType = componentType,
                ComponentId = componentId.Value,
                Quantity = 1
            });
        }
    }

    private static void AddMany(List<UseInventoryItemDto> items, string componentType, IEnumerable<int>? componentIds)
    {
        if (componentIds == null)
        {
            return;
        }

        foreach (var componentId in componentIds)
        {
            items.Add(new UseInventoryItemDto
            {
                ComponentType = componentType,
                ComponentId = componentId,
                Quantity = 1
            });
        }
    }

    private async Task<ResponseDTO> GenerateReviewAsync(int orderId)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("CustomerAPI");
            using var request = new HttpRequestMessage(HttpMethod.Post, "api/reviews");

            var token = _httpContextAccessor.HttpContext?.Session.GetString("AuthToken");
            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            request.Content = new StringContent(JsonConvert.SerializeObject(orderId), Encoding.UTF8, "application/json");

            using var response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Session expired before the customer review could be generated."
                };
            }

            var content = await response.Content.ReadAsStringAsync();
            var dto = JsonConvert.DeserializeObject<ResponseDTO>(content);

            return dto ?? new ResponseDTO
            {
                IsSuccess = false,
                Message = "Customer review could not be read."
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }

}
