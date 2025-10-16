using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.BuilderServiceAPI.Models;
using PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;

namespace PCBuilder.Service.BuilderServiceAPI.Controllers;

[Route("api/inventory")]
[ApiController]
public class InventoryItemAPIController : Controller
{
    private readonly IInventoryItemService _service;

    public InventoryItemAPIController(IInventoryItemService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ResponseDTO> GetAll()
    {
        return await _service.GetAllInventoryItemsAsync();
    }


    [HttpGet]
    [Route("{id:int}")]
    public async Task<ResponseDTO> GetById(int id)
    {
        return await _service.GetInventoryItemByIdAsync(id);
    }

    /*[HttpGet]
    [Route("GetByName/{name}")]
    public async Task<ResponseDTO> GetByName(string name)
    {
        return await _service.GetInventoryByNameAsync(name);
    }
    */
    [HttpPost]
    public async Task<ResponseDTO> CreateInventoryItem([FromBody] InventoryItemDTO inventoryItem)
    {
        return await _service.CreateInventoryItemAsync(inventoryItem);
    }

    [HttpDelete]
    [Route("{id:int}")]
    public async Task<ResponseDTO> DeleteInventoryItem(int id)
    {
        return await _service.DeleteInventoryItemAsync(id);
    }
}
