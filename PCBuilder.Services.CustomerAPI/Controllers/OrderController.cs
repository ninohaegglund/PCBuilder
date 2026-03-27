using Microsoft.AspNetCore.Mvc;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.Response;

namespace PCBuilder.Services.CustomerAPI.Controllers;

[Route("api/orders")]
[ApiController]
public class OrderController
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
    public async Task<ResponseDTO> AcceptOrder(int orderId)
    {
        return await _service.AcceptOrder(orderId);
    }
    [HttpPut("{orderId:int}/reject")]
    public async Task<ResponseDTO> RejectOrder(int orderId)
    {
        return await _service.RejectOrder(orderId);
    }
    [HttpPut("{orderId:int}/complete")]
    public async Task<ResponseDTO> CompleteOrder(int orderId)
    {
        return await _service.CompleteOrder(orderId);
    }
}
