using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.ComponentsAPI.Models.DTO.Response;
using PCBuilder.Service.ComponentsAPI.Services.IService;
namespace PCBuilder.Service.ComponentsAPI.Controllers
{
    [Route("api/component")]
    [ApiController]
    public class ComputerAPIController : ControllerBase
    {
        private readonly IComputerService _service;
        public ComputerAPIController(DataContext db, IMapper mapper, IComputerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ResponseDTO> Get()
        {
            return await _service.GetAllComputersAsync();
        }
        [HttpGet("{id:int}")]
        public async Task<ResponseDTO> Get(int id)
        {
            return await _service.GetComputerByIdAsync(id);
        }

        [HttpGet("GetByName/{name}")]
        public async Task<ResponseDTO> GetByName(string name)
        {
            return await _service.GetComputerByNameAsync(name);
        }

        [HttpPost]
        public async Task<ResponseDTO> CreateComputer([FromBody] ComputerCreateDTO computerDTO)
        {
            return await _service.CreateComputerAsync(computerDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ResponseDTO> UpdateComputer(int id, [FromBody] ComputerCreateDTO computerDTO)
        {
            return await _service.UpdateComputerAsync(id, computerDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ResponseDTO> DeleteComputer(int id)
        {
            return await _service.DeleteComputerAsync(id);
        }
    }
}
