using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.ComponentsAPI.Models.DTO.Response;
using PCBuilder.Service.ComponentsAPI.Services;
using PCBuilder.Services.ComponentsAPI.DTOs;

namespace PCBuilder.Service.ComponentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerAPIController : ControllerBase
    {
        private readonly DataContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;
        private ComputerService _service;

        public ComputerAPIController(DataContext db, IMapper mapper, ComputerService service)
        {
            _db = db;
            _response = new ResponseDTO();
            _mapper = mapper;
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
        public async Task<ResponseDTO> CreateComputer([FromBody] ComputerDTO computerDTO)
        {
            return await _service.CreateComputerAsync(computerDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ResponseDTO> UpdateComputer(int id, [FromBody] ComputerDTO computerDTO)
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
