using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Service.ComponentsAPI.Models;
using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Web.ViewModels.Computer;
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
            PCBuilder.Services.CustomerAPI.Response.ResponseDTO? orderResponse = await _orderService.GetOrderByIdAsync(orderId.Value);

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

        var allComponents = await _componentService.GetAllComponentsAsync();

        ViewBag.CPUs = allComponents.Cpus.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = $"{c.Name} - {c.Price:N2} kr"
        }).ToList();

        ViewBag.GPUs = allComponents.Gpus.Select(g => new SelectListItem
        {
            Value = g.Id.ToString(),
            Text = $"{g.Name} - {g.Price:N2} kr"
        }).ToList();

        ViewBag.RAMs = allComponents.Rams.Select(r => new SelectListItem
        {
            Value = r.Id.ToString(),
            Text = $"{r.Name} - {r.Price:N2} kr"
        }).ToList();

        ViewBag.Motherboards = allComponents.Motherboards.Select(m => new SelectListItem
        {
            Value = m.Id.ToString(),
            Text = $"{m.Name} - {m.Price:N2} kr"
        }).ToList();

        ViewBag.Cases = allComponents.Cases.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = $"{c.Name} - {c.Price:N2} kr"
        }).ToList();

        ViewBag.PSUs = allComponents.Psus.Select(p => new SelectListItem
        {
            Value = p.Id.ToString(),
            Text = $"{p.Name} - {p.Price:N2} kr"
        }).ToList();

        ViewBag.CPUCoolers = allComponents.CpuCoolers.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = $"{c.Name} - {c.Price:N2} kr"
        }).ToList();

        ViewBag.CaseFans = allComponents.CaseFans.Select(c => new SelectListItem
        {
            Value = c.Id.ToString(),
            Text = $"{c.Name} - {c.Price:N2} kr"
        }).ToList();

        ViewBag.Monitors = allComponents.Monitors.Select(m => new SelectListItem
        {
            Value = m.Id.ToString(),
            Text = $"{m.Name} - {m.Price:N2} kr"
        }).ToList();

        ViewBag.Keyboards = allComponents.Keyboards.Select(k => new SelectListItem
        {
            Value = k.Id.ToString(),
            Text = $"{k.Name} - {k.Price:N2} kr"
        }).ToList();

        ViewBag.Mice = allComponents.Mice.Select(m => new SelectListItem
        {
            Value = m.Id.ToString(),
            Text = $"{m.Name} - {m.Price:N2} kr"
        }).ToList();

        ViewBag.Headsets = allComponents.Headphones.Select(h => new SelectListItem
        {
            Value = h.Id.ToString(),
            Text = $"{h.Name} - {h.Price:N2} kr"
        }).ToList();

        ViewBag.Speakers = allComponents.Speakers.Select(s => new SelectListItem
        {
            Value = s.Id.ToString(),
            Text = $"{s.Name} - {s.Price:N2} kr"
        }).ToList();
        ViewBag.Storages = allComponents.InternalStorages
        .Select(s => new SelectListItem
        {
            Value = s.Id.ToString(),
            Text = $"{s.Name} - {s.Price:N2} kr"
        })
        .Concat(allComponents.ExternalStorages.Select(s => new SelectListItem
        {
            Value = s.Id.ToString(),
            Text = $"{s.Name} - {s.Price:N2} kr"
        }))
        .ToList();
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateComputerIndex(ComputerCreateDTO computer, int? orderId)
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
                ViewBag.AcceptedOrderCustomerName = order.CustomerName;
                ViewBag.AcceptedOrderCustomerImageUrl = order.CustomerImageUrl;

                computer.CustomerId = order.CustomerId;
                if (order.ComputerId.HasValue && computer.Id <= 0)
                {
                    computer.Id = order.ComputerId.Value;
                }
            }
        }

        if (!ModelState.IsValid)
        {
            var allComponentsInvalid = await _componentService.GetAllComponentsAsync();
            ViewBag.CPUs = allComponentsInvalid.Cpus.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Name} - {c.Price:N2} kr"
            }).ToList();

            ViewBag.GPUs = allComponentsInvalid.Gpus.Select(g => new SelectListItem
            {
                Value = g.Id.ToString(),
                Text = $"{g.Name} - {g.Price:N2} kr"
            }).ToList();

            ViewBag.RAMs = allComponentsInvalid.Rams.Select(r => new SelectListItem
            {
                Value = r.Id.ToString(),
                Text = $"{r.Name} - {r.Price:N2} kr"
            }).ToList();

            ViewBag.Motherboards = allComponentsInvalid.Motherboards.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = $"{m.Name} - {m.Price:N2} kr"
            }).ToList();

            ViewBag.Cases = allComponentsInvalid.Cases.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Name} - {c.Price:N2} kr"
            }).ToList();

            ViewBag.PSUs = allComponentsInvalid.Psus.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = $"{p.Name} - {p.Price:N2} kr"
            }).ToList();

            ViewBag.CPUCoolers = allComponentsInvalid.CpuCoolers.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Name} - {c.Price:N2} kr"
            }).ToList();

            ViewBag.CaseFans = allComponentsInvalid.CaseFans.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Name} - {c.Price:N2} kr"
            }).ToList();

            ViewBag.Monitors = allComponentsInvalid.Monitors.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = $"{m.Name} - {m.Price:N2} kr"
            }).ToList();

            ViewBag.Keyboards = allComponentsInvalid.Keyboards.Select(k => new SelectListItem
            {
                Value = k.Id.ToString(),
                Text = $"{k.Name} - {k.Price:N2} kr"
            }).ToList();

            ViewBag.Mice = allComponentsInvalid.Mice.Select(m => new SelectListItem
            {
                Value = m.Id.ToString(),
                Text = $"{m.Name} - {m.Price:N2} kr"
            }).ToList();

            ViewBag.Headsets = allComponentsInvalid.Headphones.Select(h => new SelectListItem
            {
                Value = h.Id.ToString(),
                Text = $"{h.Name} - {h.Price:N2} kr"
            }).ToList();

            ViewBag.Speakers = allComponentsInvalid.Speakers.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = $"{s.Name} - {s.Price:N2} kr"
            }).ToList();
            ViewBag.Storages = allComponentsInvalid.InternalStorages
            .Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = $"{s.Name} - {s.Price:N2} kr"
            })
            .Concat(allComponentsInvalid.ExternalStorages.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = $"{s.Name} - {s.Price:N2} kr"
            }))
            .ToList();
            return View(computer);
        }

        var response = computer.Id > 0
            ? await _computerService.UpdateComputerAsync(computer.Id, computer)
            : await _computerService.CreateComputerAsync(computer);

        if (response != null && response.IsSuccess)
        {
            TempData["success"] = computer.Id > 0 ? "Computer updated successfully" : "Computer created successfully";
            return RedirectToAction("ComputerIndex");
        }
        else
        {
            TempData["error"] = response?.Result?.ToString() ?? "Unknown error";
        }

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

        ComputerDTO computer = null;
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
    public async Task<IActionResult> PriceSummaryIndex(
    int id,
    int computerId)
    {
        var vm = new PriceSummaryVM();
        var orderResponse = await _orderService.GetOrderByIdAsync(id);
        if (orderResponse != null && orderResponse.IsSuccess)
        {
            vm.Order = JsonConvert.DeserializeObject<OrderDTO>(
                JsonConvert.SerializeObject(orderResponse.Result));
        }

        var computerResponse = await _computerService.GetComputerByIdAsync(computerId);
        if (computerResponse != null && computerResponse.IsSuccess)
        {
            vm.Computer = JsonConvert.DeserializeObject<ComputerDTO>(
                JsonConvert.SerializeObject(computerResponse.Result));
        }

        vm.Computer.TotalPrice = vm.Computer.TotalPrice;

        return View(vm);
    }
}

