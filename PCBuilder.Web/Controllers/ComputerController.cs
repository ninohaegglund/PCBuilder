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
        ViewBag.CPUs = new SelectList(cpus, "Id", "ModelName");
        ViewBag.PSUs = new SelectList(psus, "Id", "ModelName");
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

