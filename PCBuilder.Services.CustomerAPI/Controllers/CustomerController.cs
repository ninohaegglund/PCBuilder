using Microsoft.AspNetCore.Mvc;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.Response;

namespace PCBuilder.Services.CustomerAPI.Controllers;


[Route("api/customer")]
[ApiController]
public class CustomerController
{
    private readonly ICustomerService _service;
    public CustomerController(ICustomerService customerService)
    {
        _service = customerService;
    }

    [HttpGet]
    public async Task<ResponseDTO> Get()
    {
        return await _service.GetAllCustomersAsync();
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ResponseDTO> GetById(int id)
    {
        return await _service.GetCustomerByIdAsync(id);
    }
}
