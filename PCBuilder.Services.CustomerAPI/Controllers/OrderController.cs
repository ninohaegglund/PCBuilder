using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.Response;

namespace PCBuilder.Services.CustomerAPI.Controllers;

[Route("api/orders")]
[ApiController]
[Authorize]
public class OrderController : ControllerBase
{
    private readonly IOrderService _service;
    public OrderController(IOrderService orderService)
    {
        _service = orderService;
    }

    [HttpGet]
    public async Task<ResponseDTO> Get()
    {
        return await _service.GetAllOrdersAsync();
    }

    [HttpGet]
    [Route("{id:int}")]
    public async Task<ResponseDTO> GetById(int id)
    {
        return await _service.GetOrderByIdAsync(id);
    }

    [HttpPut("{orderId:int}/accept")]
    [Authorize(Roles = "Admin,User,Customer")]
    public async Task<ResponseDTO> AcceptOrder(int orderId)
    {
        return await _service.AcceptOrderAsync(orderId);
    }

    [HttpPut("{orderId:int}/reject")]
    [Authorize(Roles = "Admin,User,Customer")]
    public async Task<ResponseDTO> RejectOrder(int orderId)
    {
        return await _service.RejectOrderAsync(orderId);
    }

    [HttpPut("{orderId:int}/complete")]
    [Authorize(Roles = "Admin,User,Customer")]
    public async Task<ResponseDTO> CompleteOrder(int orderId)
    {
        return await _service.CompleteOrderAsync(orderId);
    }
}
