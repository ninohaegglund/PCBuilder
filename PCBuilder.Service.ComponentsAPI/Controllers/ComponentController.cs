using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Service.ComponentsAPI.Models.DTO;

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

        [HttpGet("GetComponents")]
        public async Task<IActionResult> GetComponents([FromQuery] IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
                return BadRequest("No ids provided.");

            var components = await _componentService.GetComponentsAsync(ids);
            if (components == null || !components.Any())
                return NotFound();

            return Ok(components);
        }
    }
}