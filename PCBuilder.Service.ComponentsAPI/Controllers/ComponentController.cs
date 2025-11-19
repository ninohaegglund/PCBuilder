using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Service.ComponentsAPI.Models.DTOs;
using PCBuilder.Service.ComponentsAPI.Utilities;
using System;
using System.Threading.Tasks;

namespace PCBuilder.Service.ComponentsAPI.Controllers
{
    [ApiController]
    [Route("api/components")]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentService _componentService;
        private readonly IComponentTypeResolver _resolver;

        public ComponentController(IComponentService componentService, IComponentTypeResolver resolver)
        {
            _componentService = componentService;
            _resolver = resolver;
        }

        // Lista vilka kategorier som stöds (hjälp-endpoint)
        [HttpGet("categories")]
        public ActionResult GetCategories() => Ok(_resolver.Categories);

        // Hämta ALLA komponenter (full payload)
        [HttpGet("all")]
        public async Task<ActionResult<AllComponentsDto>> GetAllComponents()
        {
            var all = await _componentService.GetAllComponentsAsync();
            return Ok(all);
        }

        // Generisk list-endpoint: /api/components/{category}
        [HttpGet("{category}")]
        public async Task<ActionResult> GetAllByCategory(string category)
        {
            if (!_resolver.TryResolve(category, out var type) || type is null)
                return NotFound($"Okänd kategori: {category}");

            var result = await InvokeGenericGetAllAsync(type);
            return Ok(result);
        }

        // Generisk single-endpoint: /api/components/{category}/{id}
        [HttpGet("{category}/{id:int}")]
        public async Task<ActionResult> GetByCategoryAndId(string category, int id)
        {
            if (!_resolver.TryResolve(category, out var type) || type is null)
                return NotFound($"Okänd kategori: {category}");

            var result = await InvokeGenericGetByIdAsync(type, id);
            if (result is null)
                return NotFound($"Hittade ingen {category} med ID {id}.");

            return Ok(result);
        }

        // Hjälpmetoder för att anropa generiska metoder via reflection
        private async Task<object?> InvokeGenericGetAllAsync(Type type)
        {
            var method = typeof(IComponentService).GetMethod(nameof(IComponentService.GetAllAsync))!;
            var generic = method.MakeGenericMethod(type);
            var task = (System.Threading.Tasks.Task)generic.Invoke(_componentService, Array.Empty<object>())!;
            await task.ConfigureAwait(false);
            return task.GetType().GetProperty("Result")?.GetValue(task);
        }

        private async Task<object?> InvokeGenericGetByIdAsync(Type type, int id)
        {
            var method = typeof(IComponentService).GetMethod(nameof(IComponentService.GetByIdAsync))!;
            var generic = method.MakeGenericMethod(type);
            var task = (System.Threading.Tasks.Task)generic.Invoke(_componentService, new object[] { id })!;
            await task.ConfigureAwait(false);
            return task.GetType().GetProperty("Result")?.GetValue(task);
        }
    }
}