using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;
using PCBuilder.Service.ComponentsAPI.Interfaces;

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
    public async Task<IActionResult> CreateComputerIndex()
    {
        var allComponents = await _componentService.GetAllComponentsAsync();

        ViewBag.CPUs = new SelectList(allComponents.Cpus, "Id", "Name");
        ViewBag.GPUs = new SelectList(allComponents.Gpus, "Id", "Name");
        ViewBag.RAMs = new SelectList(allComponents.Rams, "Id", "Name");
        ViewBag.Motherboards = new SelectList(allComponents.Motherboards, "Id", "Name");
        ViewBag.Cases = new SelectList(allComponents.Cases, "Id", "Name");
        ViewBag.PSUs = new SelectList(allComponents.Psus, "Id", "Name");
        ViewBag.CPUCoolers = new SelectList(allComponents.CpuCoolers, "Id", "Name");
        ViewBag.CaseFans = new SelectList(allComponents.CaseFans, "Id", "Name");
        ViewBag.InternalStorages = new SelectList(allComponents.InternalStorages, "Id", "Name");
        ViewBag.ExternalStorages = new SelectList(allComponents.ExternalStorages, "Id", "Name");
        ViewBag.Monitors = new SelectList(allComponents.Monitors, "Id", "Name");
        ViewBag.Keyboards = new SelectList(allComponents.Keyboards, "Id", "Name");
        ViewBag.Mice = new SelectList(allComponents.Mice, "Id", "Name");
        ViewBag.Headphones = new SelectList(allComponents.Headphones, "Id", "Name");
        ViewBag.Speakers = new SelectList(allComponents.Speakers, "Id", "Name");

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

