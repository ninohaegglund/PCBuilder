using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Service.ComponentsAPI.Models.DTOs;

namespace PCBuilder.Service.ComponentsAPI.Controllers
{
    [ApiController]
    [Route("api/components")]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentService _componentService;

        public ComponentController(IComponentService componentService)
        {
            _componentService = componentService;
        }


        [HttpGet]
        public async Task<AllComponentsDto> GetAll()
        {
            return await _componentService.GetAllComponentsAsync();
        }

        [HttpGet]
        [Route("manufacturers")]
        public async Task<List<ManufacturerDto>> GetAllManufacturers()
        {
            return await _componentService.GetAllManufacturersAsync();
        }

        
    }
}