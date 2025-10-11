using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;


namespace PCBuilder.Service.BuilderServiceAPI.Controllers;

[Route("api/computer")]
[ApiController]
public class BuiltComputersController : ControllerBase
{
    private readonly IComputerService _service;
    public BuiltComputersController(DataContext db, IMapper mapper, IComputerService service)
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

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ResponseDTO> DeleteComputer(int id)
    {
        return await _service.DeleteComputerAsync(id);
    }
}
