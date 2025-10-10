using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.ComponentsAPI.Models.DTO.Response;
using PCBuilder.Services.ComponentsAPI.DTOs;

namespace PCBuilder.Web.Controllers;

public class ComputerController : Controller
{
    private readonly IComputerService _computerService;
    public ComputerController(IComputerService computerService)
    {
        _computerService = computerService;
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

