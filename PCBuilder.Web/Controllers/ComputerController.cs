using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.IService;
using Contracts;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.IServices;
using System.Text.Json;
using NewtonsoftJson = Newtonsoft.Json;

namespace PCBuilder.Web.Controllers;

public class ComputerController : Controller
{
    private readonly IComputerService _computerService;
    private readonly IComponentService _componentService;
    private readonly IOrderService _orderService;
    public ComputerController(IComputerService computerService, IComponentService componentService, IOrderService orderService)
    {
        _computerService = computerService;
        _componentService = componentService;
        _orderService = orderService;
    }

    [HttpGet]
    public async Task<IActionResult> CreateComputerIndex(int? orderId)
    {
        var model = new ComputerCreateDTO();

        if (orderId.HasValue)
        {
            var orderResponse = await _orderService.GetOrderByIdAsync(orderId.Value);

            if (orderResponse != null && orderResponse.IsSuccess)
            {
                var order = NewtonsoftJson.JsonConvert.DeserializeObject<OrderListDTO>(
                    NewtonsoftJson.JsonConvert.SerializeObject(orderResponse.Result));

                ViewBag.AcceptedOrderId = order?.Id;
                ViewBag.AcceptedOrderDescription = order?.Description;
                ViewBag.AcceptedOrderDetailedDescription = order?.DetailedDescription;
                ViewBag.AcceptedOrderCustomerName = order?.CustomerName;
                ViewBag.AcceptedOrderCustomerImageUrl = order?.CustomerImageUrl;
                ViewBag.AcceptedOrderBudget = order?.Budget;

                if (order != null)
                {
                    model.CustomerId = order.CustomerId;

                    if (order.ComputerId.HasValue)
                    {
                        var computerResponse = await _computerService.GetComputerByIdAsync(order.ComputerId.Value);
                        if (computerResponse != null && computerResponse.IsSuccess)
                        {
                            var existingComputer = NewtonsoftJson.JsonConvert.DeserializeObject<ComputerDTO>(
                                NewtonsoftJson.JsonConvert.SerializeObject(computerResponse.Result));

                            if (existingComputer != null)
                            {
                                model = new ComputerCreateDTO
                                {
                                    Id = existingComputer.Id,
                                    Name = existingComputer.Name,
                                    CustomerId = existingComputer.CustomerId,
                                    CPUId = existingComputer.CpuId,
                                    PSUId = existingComputer.PowerSupplyId,
                                    MotherboardId = existingComputer.MotherboardId,
                                    CaseId = existingComputer.CaseId,
                                    CpuCoolerId = existingComputer.CpuCoolerId,
                                    KeyboardId = existingComputer.KeyboardId,
                                    MouseId = existingComputer.MouseId,
                                    HeadsetId = existingComputer.HeadphonesId,
                                    GPUIds = existingComputer.GpuIds ?? new List<int>(),
                                    RAMIds = existingComputer.RamIds ?? new List<int>(),
                                    StorageIds = existingComputer.InternalStorageIds ?? existingComputer.ExternalStorageIds ?? new List<int>(),
                                    CaseFanIds = existingComputer.CaseFanIds ?? new List<int>(),
                                    MonitorIds = existingComputer.MonitorIds ?? new List<int>(),
                                    SpeakerIds = existingComputer.SpeakerIds ?? new List<int>(),
                                    TotalPrice = existingComputer.TotalPrice
                                };
                            }
                        }
                    }
                }
            }
            else
            {
                ViewBag.OrderInfoError = orderResponse?.Message ?? "Could not load order info.";
            }
        }

        await PopulateComponentSelectListsAsync();
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateComputerIndex(ComputerCreateDTO computer, int? orderId, string submitAction = "save")
    {
        if (orderId.HasValue)
        {
            var orderResponse = await _orderService.GetOrderByIdAsync(orderId.Value);
            var order = orderResponse != null && orderResponse.IsSuccess
                ? NewtonsoftJson.JsonConvert.DeserializeObject<OrderListDTO>(NewtonsoftJson.JsonConvert.SerializeObject(orderResponse.Result))
                : null;

            if (order != null)
            {
                ViewBag.AcceptedOrderId = order.Id;
                ViewBag.AcceptedOrderDescription = order.Description;
                ViewBag.AcceptedOrderDetailedDescription = order.DetailedDescription;
                ViewBag.AcceptedOrderCustomerName = order.CustomerName;
                ViewBag.AcceptedOrderCustomerImageUrl = order.CustomerImageUrl;
                ViewBag.AcceptedOrderBudget = order.Budget;

                computer.CustomerId = order.CustomerId;
                if (order.ComputerId.HasValue && computer.Id <= 0)
                {
                    computer.Id = order.ComputerId.Value;
                }
            }
        }

        if (!ModelState.IsValid)
        {
            await PopulateComponentSelectListsAsync();
            return View(computer);
        }

        var response = computer.Id > 0
            ? await _computerService.UpdateComputerAsync(computer.Id, computer)
            : await _computerService.CreateComputerAsync(computer);

        if (response != null && response.IsSuccess)
        {
            TempData["success"] = computer.Id > 0 ? "Computer updated successfully" : "Computer created successfully";

            if (string.Equals(submitAction, "finalize", StringComparison.OrdinalIgnoreCase))
            {
                if (orderId.HasValue)
                {
                    return RedirectToAction("PriceSummaryIndex", "Order", new { id = orderId.Value });
                }

                TempData["error"] = "Build saved, but no order was connected for price summary.";
            }

            return RedirectToAction("ComputerIndex");
        }
        else
        {
            TempData["error"] = response?.Message ?? response?.Result?.ToString() ?? "Unknown error";
        }

        await PopulateComponentSelectListsAsync();
        return View(computer);
    }

    public async Task<IActionResult> ComputerIndex()
    {
        var response = await _computerService.GetAllComputersAsync();

        if (response == null || !response.IsSuccess)
        {
            TempData["error"] = response?.Result?.ToString() ?? "Failed to load computers.";
            return View(new List<ComputerDTO>());
        }

        var list = response.Result switch
        {
            List<ComputerDTO> typed => typed,
            JsonElement json => System.Text.Json.JsonSerializer.Deserialize<List<ComputerDTO>>(json.GetRawText()) ?? new List<ComputerDTO>(),
            _ => new List<ComputerDTO>()
        };

        return View(list);
    }

    public async Task<IActionResult> ComponentsIndex(int id)
    {
        ResponseDTO? response = await _computerService.GetComputerByIdAsync(id);

        ComputerDTO? computer = null;
        if (response != null && response.Result != null)
        {
            computer = response.Result as ComputerDTO;
        }

        var linkedOrder = await GetLinkedOrderByComputerIdAsync(id);
        ViewBag.LinkedOrderId = linkedOrder?.Id;
        ViewBag.IsLinkedToOrder = linkedOrder != null;

        return View(computer);
    }

    public async Task<IActionResult> DeleteComputer(int id)
    {
        var linkedOrder = await GetLinkedOrderByComputerIdAsync(id);
        if (linkedOrder != null)
        {
            TempData["error"] = $"Computer is linked to order #{linkedOrder.Id} and cannot be deleted.";
            return RedirectToAction(nameof(ComponentsIndex), new { id });
        }

        ResponseDTO? response = await _computerService.DeleteComputerAsync(id);

        if (response != null && response.IsSuccess)
        {
            TempData["success"] = "Computer deleted successfully.";
        }
        else
        {
            TempData["error"] = response?.Result?.ToString() ?? "Failed to delete computer.";
        }

        return RedirectToAction("ComputerIndex");
    }

    private async Task<OrderListDTO?> GetLinkedOrderByComputerIdAsync(int computerId)
    {
        var ordersResponse = await _orderService.GetAllOrdersAsync();
        if (ordersResponse == null || !ordersResponse.IsSuccess || ordersResponse.Result == null)
        {
            return null;
        }

        var orders = NewtonsoftJson.JsonConvert.DeserializeObject<List<OrderListDTO>>(
            NewtonsoftJson.JsonConvert.SerializeObject(ordersResponse.Result));

        return orders?.FirstOrDefault(x => x.ComputerId == computerId);
    }

    private async Task PopulateComponentSelectListsAsync()
    {
        var allComponents = await _componentService.GetAllComponentsAsync();

        ViewBag.CPUs = ToSelectList(allComponents.Cpus, x => x.Id, x => x.Name, x => x.Price);
        ViewBag.GPUs = ToSelectList(allComponents.Gpus, x => x.Id, x => x.Name, x => x.Price);
        ViewBag.RAMs = ToSelectList(allComponents.Rams, x => x.Id, x => x.Name, x => x.Price);
        ViewBag.Motherboards = ToSelectList(allComponents.Motherboards, x => x.Id, x => x.Name, x => x.Price);
        ViewBag.Cases = ToSelectList(allComponents.Cases, x => x.Id, x => x.Name, x => x.Price);
        ViewBag.PSUs = ToSelectList(allComponents.Psus, x => x.Id, x => x.Name, x => x.Price);
        ViewBag.CPUCoolers = ToSelectList(allComponents.CpuCoolers, x => x.Id, x => x.Name, x => x.Price);
        ViewBag.CaseFans = ToSelectList(allComponents.CaseFans, x => x.Id, x => x.Name, x => x.Price);
        ViewBag.Monitors = ToSelectList(allComponents.Monitors, x => x.Id, x => x.Name, x => x.Price);
        ViewBag.Keyboards = ToSelectList(allComponents.Keyboards, x => x.Id, x => x.Name, x => x.Price);
        ViewBag.Mice = ToSelectList(allComponents.Mice, x => x.Id, x => x.Name, x => x.Price);
        ViewBag.Headsets = ToSelectList(allComponents.Headphones, x => x.Id, x => x.Name, x => x.Price);
        ViewBag.Speakers = ToSelectList(allComponents.Speakers, x => x.Id, x => x.Name, x => x.Price);
        ViewBag.Storages = ToSelectList(allComponents.InternalStorages, x => x.Id, x => x.Name, x => x.Price)
            .Concat(ToSelectList(allComponents.ExternalStorages, x => x.Id, x => x.Name, x => x.Price))
            .ToList();
    }

    private static List<SelectListItem> ToSelectList<TComponent>(
        IEnumerable<TComponent> components,
        Func<TComponent, int> getId,
        Func<TComponent, string> getName,
        Func<TComponent, decimal?> getPrice)
    {
        return components.Select(component => new SelectListItem
        {
            Value = getId(component).ToString(),
            Text = $"{getName(component)} - {getPrice(component):N2} kr"
        }).ToList();
    }

}

