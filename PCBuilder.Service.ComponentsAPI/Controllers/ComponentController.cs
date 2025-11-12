using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.ComponentsAPI.Interfaces;

namespace PCBuilder.Service.ComponentsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentService _componentService;
        public ComponentController(IComponentService componentService)
        {
            _componentService = componentService;
        }

        [HttpGet("GetComponents/{id}")]
        public async Task<IActionResult> GetComponents(int id)
        {
            var components = await _componentService.GetComponentsAsync(new[] { id });
            if (components == null || !components.Any())
                return NotFound();

            return Ok(components);
        }
    }
}