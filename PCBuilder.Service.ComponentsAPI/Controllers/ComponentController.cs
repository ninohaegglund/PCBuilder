using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.ComponentsAPI.Interfaces;

namespace PCBuilder.Service.ComponentsAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComponentController : ControllerBase
{
    public readonly IComponentService _componentService;
    public ComponentController(IComponentService componentService)
    {
        _componentService = componentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetComponents([FromQuery] int id)
    {
        var components = await _componentService.GetComponentAsync(id);
        return Ok(components);
    }
}