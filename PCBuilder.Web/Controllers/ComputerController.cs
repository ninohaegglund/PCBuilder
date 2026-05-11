using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.IService;
using Contracts;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Services.InventoryAPI.IServices;
using PCBuilder.Web.ViewModels.Inventory;
using PCBuilder.Service.ComponentsAPI.Models.DTOs;
using System.Security.Claims;
using System.Text.Json;
using NewtonsoftJson = Newtonsoft.Json;

namespace PCBuilder.Web.Controllers;

public class ComputerController : Controller
{
    private readonly IComputerService _computerService;
    private readonly IComponentService _componentService;
    private readonly IOrderService _orderService;
    private readonly IInventoryService _inventoryService;
    public ComputerController(
        IComputerService computerService,
        IComponentService componentService,
        IOrderService orderService,
        IInventoryService inventoryService)
    {
        _computerService = computerService;
        _componentService = componentService;
        _orderService = orderService;
        _inventoryService = inventoryService;
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
                                    StorageIds = (existingComputer.InternalStorageIds ?? new List<int>())
                                        .Concat((existingComputer.ExternalStorageIds ?? new List<int>()).Select(id => -id))
                                        .ToList(),
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

        var components = await _componentService.GetAllComponentsAsync();
        var inventoryItems = await GetCurrentInventoryAsync();
        PopulateBuildPageData(components, inventoryItems);
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
            var components = await _componentService.GetAllComponentsAsync();
            var inventoryItems = await GetCurrentInventoryAsync();
            PopulateBuildPageData(components, inventoryItems);
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

            return orderId.HasValue
                ? RedirectToAction("ComputerIndex", new { orderId = orderId.Value })
                : RedirectToAction("ComputerIndex");
        }
        else
        {
            TempData["error"] = response?.Message ?? response?.Result?.ToString() ?? "Unknown error";
        }

        var componentLists = await _componentService.GetAllComponentsAsync();
        var inventory = await GetCurrentInventoryAsync();
        PopulateBuildPageData(componentLists, inventory);
        return View(computer);
    }

    public async Task<IActionResult> ComputerIndex(int? orderId)
    {
        if (!TryGetCurrentUserId(out var currentUserId))
        {
            TempData["error"] = "You must be logged in to view computers.";
            return View(new List<ComputerDTO>());
        }

        var ordersResponse = orderId.HasValue
            ? await _orderService.GetOrderByIdAsync(orderId.Value)
            : await _orderService.GetAllOrdersAsync();

        if (ordersResponse == null || !ordersResponse.IsSuccess || ordersResponse.Result == null)
        {
            TempData["error"] = ordersResponse?.Message ?? "Failed to load linked orders.";
            return View(new List<ComputerDTO>());
        }

        var linkedOrders = orderId.HasValue
            ? ToSingleOrderList(ordersResponse.Result)
            : ToOrderList(ordersResponse.Result);

        var computerIds = linkedOrders
            .Where(x => x.UserId == currentUserId && x.ComputerId.HasValue)
            .Select(x => x.ComputerId!.Value)
            .Distinct()
            .ToList();

        if (orderId.HasValue && !computerIds.Any())
        {
            TempData["error"] = "No computer is connected to this order for your user.";
            return View(new List<ComputerDTO>());
        }

        var computers = new List<ComputerDTO>();

        foreach (var computerId in computerIds)
        {
            var computerResponse = await _computerService.GetComputerByIdAsync(computerId);
            if (computerResponse == null || !computerResponse.IsSuccess || computerResponse.Result == null)
            {
                continue;
            }

            var computer = ToComputer(computerResponse.Result);
            if (computer != null)
            {
                computers.Add(computer);
            }
        }

        return View(computers);
    }

    public async Task<IActionResult> ComponentsIndex(int id)
    {
        var linkedOrder = await GetLinkedOrderByComputerIdAsync(id);
        if (linkedOrder == null)
        {
            TempData["error"] = "Computer is not connected to one of your orders.";
            return RedirectToAction(nameof(ComputerIndex));
        }

        ResponseDTO? response = await _computerService.GetComputerByIdAsync(id);

        ComputerDTO? computer = null;
        if (response != null && response.IsSuccess && response.Result != null)
        {
            computer = ToComputer(response.Result);
        }

        if (computer == null)
        {
            TempData["error"] = response?.Message ?? response?.Result?.ToString() ?? "Computer could not be loaded.";
            return RedirectToAction(nameof(ComputerIndex));
        }

        ViewBag.LinkedOrderId = linkedOrder?.Id;
        ViewBag.IsLinkedToOrder = linkedOrder != null;

        return View(computer);
    }

    public async Task<IActionResult> DeleteComputer(int id)
    {
        var linkedOrder = await GetLinkedOrderByComputerIdAsync(id);

        TempData["error"] = linkedOrder == null
            ? "Computer is not connected to one of your orders."
            : $"Computer is linked to order #{linkedOrder.Id} and cannot be deleted.";

        return linkedOrder == null
            ? RedirectToAction(nameof(ComputerIndex))
            : RedirectToAction(nameof(ComponentsIndex), new { id });
    }

    private async Task<OrderListDTO?> GetLinkedOrderByComputerIdAsync(int computerId)
    {
        var ordersResponse = await _orderService.GetAllOrdersAsync();
        if (ordersResponse == null || !ordersResponse.IsSuccess || ordersResponse.Result == null)
        {
            return null;
        }

        var orders = ToOrderList(ordersResponse.Result);

        if (!TryGetCurrentUserId(out var currentUserId))
        {
            return null;
        }

        return orders.FirstOrDefault(x => x.UserId == currentUserId && x.ComputerId == computerId);
    }

    private bool TryGetCurrentUserId(out Guid userId)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return Guid.TryParse(userIdClaim, out userId);
    }

    private static List<OrderListDTO> ToSingleOrderList(object result)
    {
        var order = NewtonsoftJson.JsonConvert.DeserializeObject<OrderListDTO>(
            NewtonsoftJson.JsonConvert.SerializeObject(result));

        return order == null
            ? new List<OrderListDTO>()
            : new List<OrderListDTO> { order };
    }

    private static List<OrderListDTO> ToOrderList(object result)
    {
        return NewtonsoftJson.JsonConvert.DeserializeObject<List<OrderListDTO>>(
            NewtonsoftJson.JsonConvert.SerializeObject(result)) ?? new List<OrderListDTO>();
    }

    private static ComputerDTO? ToComputer(object result)
    {
        return NewtonsoftJson.JsonConvert.DeserializeObject<ComputerDTO>(
            NewtonsoftJson.JsonConvert.SerializeObject(result));
    }

    private void PopulateComponentSelectLists(AllComponentsDto allComponents, List<PCBuilder.Services.InventoryAPI.DTO.InventoryItemDto> inventoryItems)
    {
        ViewBag.CPUs = ToSelectList(Owned(allComponents.Cpus, inventoryItems, "CPU"), x => x.Id, x => x.Name, x => x.Price);
        ViewBag.GPUs = ToSelectList(Owned(allComponents.Gpus, inventoryItems, "GPU"), x => x.Id, x => x.Name, x => x.Price);
        ViewBag.RAMs = ToSelectList(Owned(allComponents.Rams, inventoryItems, "RAM"), x => x.Id, x => x.Name, x => x.Price);
        ViewBag.Motherboards = ToSelectList(Owned(allComponents.Motherboards, inventoryItems, "Motherboard"), x => x.Id, x => x.Name, x => x.Price);
        ViewBag.Cases = ToSelectList(Owned(allComponents.Cases, inventoryItems, "Case"), x => x.Id, x => x.Name, x => x.Price);
        ViewBag.PSUs = ToSelectList(Owned(allComponents.Psus, inventoryItems, "PSU"), x => x.Id, x => x.Name, x => x.Price);
        ViewBag.CPUCoolers = ToSelectList(Owned(allComponents.CpuCoolers, inventoryItems, "CPUCooler"), x => x.Id, x => x.Name, x => x.Price);
        ViewBag.CaseFans = ToSelectList(Owned(allComponents.CaseFans, inventoryItems, "CaseFan"), x => x.Id, x => x.Name, x => x.Price);
        ViewBag.Monitors = ToSelectList(Owned(allComponents.Monitors, inventoryItems, "Monitor"), x => x.Id, x => x.Name, x => x.Price);
        ViewBag.Keyboards = ToSelectList(Owned(allComponents.Keyboards, inventoryItems, "Keyboard"), x => x.Id, x => x.Name, x => x.Price);
        ViewBag.Mice = ToSelectList(Owned(allComponents.Mice, inventoryItems, "Mouse"), x => x.Id, x => x.Name, x => x.Price);
        ViewBag.Headsets = ToSelectList(Owned(allComponents.Headphones, inventoryItems, "Headphones"), x => x.Id, x => x.Name, x => x.Price);
        ViewBag.Speakers = ToSelectList(Owned(allComponents.Speakers, inventoryItems, "Speakers"), x => x.Id, x => x.Name, x => x.Price);
        ViewBag.Storages = ToSelectList(Owned(allComponents.InternalStorages, inventoryItems, "InternalStorage"), x => x.Id, x => $"{x.Name} (Internal)", x => x.Price)
            .Concat(ToSelectList(Owned(allComponents.ExternalStorages, inventoryItems, "ExternalStorage"), x => -x.Id, x => $"{x.Name} (External)", x => x.Price))
            .ToList();
    }

    private void PopulateBuildPageData(AllComponentsDto components, List<PCBuilder.Services.InventoryAPI.DTO.InventoryItemDto> inventoryItems)
    {
        PopulateComponentSelectLists(components, inventoryItems);
        PopulateInventory(components, inventoryItems);
        PopulateBuildCompatibilityData(components, inventoryItems);
        ViewBag.ShopComponents = components;
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

    private async Task<List<PCBuilder.Services.InventoryAPI.DTO.InventoryItemDto>> GetCurrentInventoryAsync()
    {
        if (!TryGetCurrentUserId(out var userId))
        {
            return new List<PCBuilder.Services.InventoryAPI.DTO.InventoryItemDto>();
        }

        return await _inventoryService.GetInventoryAsync(userId);
    }

    private void PopulateInventory(AllComponentsDto components, List<PCBuilder.Services.InventoryAPI.DTO.InventoryItemDto> inventoryItems)
    {
        ViewBag.InventoryItems = inventoryItems
            .Where(x => x.Quantity > 0)
            .Select(item => new InventoryItemViewModel
            {
                Id = item.Id,
                ComponentType = item.ComponentType,
                ComponentId = item.ComponentId,
                DisplayName = ResolveDisplayName(components, item.ComponentType, item.ComponentId),
                Quantity = item.Quantity,
                PurchasePrice = item.PurchasePrice,
                PurchasedAt = item.PurchasedAt
            })
            .OrderBy(x => x.ComponentType)
            .ThenBy(x => x.DisplayName)
            .ToList();
    }

    private void PopulateBuildCompatibilityData(AllComponentsDto components, List<PCBuilder.Services.InventoryAPI.DTO.InventoryItemDto> inventoryItems)
    {
        var data = new
        {
            cpus = Owned(components.Cpus, inventoryItems, "CPU").Select(x => new
            {
                id = x.Id,
                name = x.Name,
                tdp = x.Tdp ?? 0,
                price = x.Price ?? 0m
            }),
            gpus = Owned(components.Gpus, inventoryItems, "GPU").Select(x => new
            {
                id = x.Id,
                name = x.Name,
                tdp = x.Tdp ?? 0,
                lengthMm = x.LengthMM ?? 0,
                price = x.Price ?? 0m
            }),
            rams = Owned(components.Rams, inventoryItems, "RAM").Select(x => new
            {
                id = x.Id,
                name = x.Name,
                capacityGb = x.TotalCapacityGB,
                price = x.Price ?? 0m
            }),
            motherboards = Owned(components.Motherboards, inventoryItems, "Motherboard").Select(x => new
            {
                id = x.Id,
                name = x.Name,
                price = x.Price ?? 0m
            }),
            cases = Owned(components.Cases, inventoryItems, "Case").Select(x => new
            {
                id = x.Id,
                name = x.Name,
                maxGpuLengthMm = x.MaxGpuLengthMm ?? 0,
                maxCpuCoolerHeightMm = x.MaxCpuCoolerHeightMm ?? 0,
                fanMountCount = x.FanMountCount ?? 0,
                price = x.Price ?? 0m
            }),
            psus = Owned(components.Psus, inventoryItems, "PSU").Select(x => new
            {
                id = x.Id,
                name = x.Name,
                wattage = x.Wattage,
                efficiencyRating = x.EfficiencyRating ?? string.Empty,
                price = x.Price ?? 0m
            }),
            cpuCoolers = Owned(components.CpuCoolers, inventoryItems, "CPUCooler").Select(x => new
            {
                id = x.Id,
                name = x.Name,
                maxTdpWatts = x.MaxTdpWatts ?? 0,
                heightMm = x.HeightMm ?? 0,
                price = x.Price ?? 0m
            }),
            caseFans = Owned(components.CaseFans, inventoryItems, "CaseFan").Select(x => new
            {
                id = x.Id,
                name = x.Name,
                price = x.Price ?? 0m
            }),
            storages = Owned(components.InternalStorages, inventoryItems, "InternalStorage").Select(x => new
            {
                id = x.Id,
                name = x.Name,
                price = x.Price ?? 0m
            }).Concat(Owned(components.ExternalStorages, inventoryItems, "ExternalStorage").Select(x => new
            {
                id = -x.Id,
                name = x.Name,
                price = x.Price ?? 0m
            })),
            monitors = Owned(components.Monitors, inventoryItems, "Monitor").Select(x => new
            {
                id = x.Id,
                name = x.Name,
                price = x.Price ?? 0m
            }),
            keyboards = Owned(components.Keyboards, inventoryItems, "Keyboard").Select(x => new
            {
                id = x.Id,
                name = x.Name,
                price = x.Price ?? 0m
            }),
            mice = Owned(components.Mice, inventoryItems, "Mouse").Select(x => new
            {
                id = x.Id,
                name = x.Name,
                price = x.Price ?? 0m
            }),
            headsets = Owned(components.Headphones, inventoryItems, "Headphones").Select(x => new
            {
                id = x.Id,
                name = x.Name,
                price = x.Price ?? 0m
            }),
            speakers = Owned(components.Speakers, inventoryItems, "Speakers").Select(x => new
            {
                id = x.Id,
                name = x.Name,
                price = x.Price ?? 0m
            })
        };

        ViewBag.BuildCompatibilityDataJson = JsonSerializer.Serialize(data);
    }

    private static IEnumerable<TComponent> Owned<TComponent>(
        IEnumerable<TComponent> components,
        IEnumerable<PCBuilder.Services.InventoryAPI.DTO.InventoryItemDto> inventoryItems,
        string componentType)
    {
        var ownedIds = inventoryItems
            .Where(x => x.Quantity > 0 && string.Equals(x.ComponentType, componentType, StringComparison.OrdinalIgnoreCase))
            .Select(x => x.ComponentId)
            .ToHashSet();

        return components.Where(component =>
        {
            var idProperty = component?.GetType().GetProperty("Id");
            return idProperty?.GetValue(component) is int id && ownedIds.Contains(id);
        });
    }

    private static string ResolveDisplayName(AllComponentsDto components, string componentType, int componentId)
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

