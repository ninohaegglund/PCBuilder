using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.ComponentsAPI.Models.DTO.Response;
using PCBuilder.Service.ComponentsAPI.Services.IService;
using PCBuilder.Services.ComponentsAPI.DTOs;

namespace PCBuilder.Web.Controllers;

public class ComponentController : Controller
{
    private readonly IComputerService _computerService;
    public ComponentController(IComputerService computerService)
    {
        _computerService = computerService;
    }
    public async Task<IActionResult> ComputerIndex()
    {
        List<ComputerDTO>? list = new();

        ResponseDTO? response = await _computerService.GetAllComputersAsync();

        return View(list);
    }
}

