using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PCBuilder.Service.ComponentsAPI.Models.DTO.Response;
using PCBuilder.Service.ComponentsAPI.Services.IService;
using PCBuilder.Services.ComponentsAPI.DTOs;

namespace PCBuilder.Web.Controllers;

public class ComputerController : Controller
{
    private readonly IComputerService _computerService;
    private readonly IComponentService _componentService;
    public ComputerController(IComputerService computerService, IComponentService componentService)
    {
        _computerService = computerService;
        _componentService = componentService;
    }


    [HttpGet]
    public async Task <IActionResult> CreateComputerIndex()
    {
        var cpus = await _componentService.GetAllCPUsAsync();
        var psus = await _componentService.GetAllPSUsAsync();
        var motherboards = await _componentService.GetAllMotherboardsAsync();
        var cases = await _componentService.GetAllCasesAsync();
        var keyboards = await _componentService.GetAllKeyboardsAsync();
        var mice = await _componentService.GetAllMiceAsync();
        var headsets = await _componentService.GetAllHeadsetsAsync();
        var gpus = await _componentService.GetAllGPUsAsync();
        var rams = await _componentService.GetAllRAMModulesAsync();
        var storages = await _componentService.GetAllStorageDevicesAsync();
        var caseCoolers = await _componentService.GetAllChassiCoolersAsync();
        var cpuCoolers = await _componentService.GetAllCPUCoolersAsync();
        var monitors = await _componentService.GetAllMonitorsAsync();
        var speakers = await _componentService.GetAllSpeakersAsync();
        var sataCables = await _componentService.GetAllSataCablesAsync();
        var pcieCables = await _componentService.GetAllPCIeCablesAsync();
        var powerCables = await _componentService.GetAllPowerCablesAsync();

        ViewBag.CPUs = new SelectList(cpus, "Id", "ModelName");
        ViewBag.PSUs = new SelectList(psus, "Id", "ModelName");
        ViewBag.Motherboards = new SelectList(motherboards, "Id", "ModelName");
        ViewBag.Cases = new SelectList(cases, "Id", "ModelName");
        ViewBag.Keyboards = new SelectList(keyboards, "Id", "ModelName");
        ViewBag.Mice = new SelectList(mice, "Id", "ModelName");
        ViewBag.Headsets = new SelectList(headsets, "Id", "ModelName");
        ViewBag.GPUs = new SelectList(gpus, "Id", "ModelName");
        ViewBag.RAMs = new SelectList(rams, "Id", "ModelName");
        ViewBag.Storages = new SelectList(storages, "Id", "ModelName");
        ViewBag.CaseCoolers = new SelectList(caseCoolers, "Id", "ModelName");
        ViewBag.CPUCoolers = new SelectList(cpuCoolers, "Id", "ModelName");
        ViewBag.Monitors = new SelectList(monitors, "Id", "ModelName");
        ViewBag.Speakers = new SelectList(speakers, "Id", "ModelName");
        ViewBag.SataCables = new SelectList(sataCables, "Id", "LengthCm");
        ViewBag.PCIeCables = new SelectList(pcieCables, "Id", "LengthCm");
        ViewBag.PowerCables = new SelectList(powerCables, "Id", "LengthCm");

        return View(new ComputerCreateDTO());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateComputerIndex(ComputerCreateDTO computer)
    {
        if (!ModelState.IsValid)
        {
            return View(computer);
        }

        var response = await _computerService.CreateComputerAsync(computer);

        if (response != null && response.IsSuccess)
        {
            TempData["success"] = "Computer created successfully";
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
        ResponseDTO? response = await _computerService.GetAllComputersAsync();

        List<ComputerDTO>? list = null;
        if (response != null && response.Result != null)
        {
            list = response.Result as List<ComputerDTO>;
        }
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
        return View(computer);
    }

    public async Task<IActionResult> DeleteComputer(int id)
    {
        ResponseDTO? response = await _computerService.DeleteComputerAsync(id);
        return RedirectToAction("ComputerIndex");
    }
}

