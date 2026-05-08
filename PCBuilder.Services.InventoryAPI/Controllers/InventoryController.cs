using Microsoft.AspNetCore.Mvc;
using PCBuilder.Services.InventoryAPI.DTO;
using PCBuilder.Services.InventoryAPI.IServices;

namespace PCBuilder.Services.InventoryAPI.Controllers;

[ApiController]
[Route("api/inventory")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _inventoryService;

    public InventoryController(IInventoryService inventoryService)
    {
        _inventoryService = inventoryService;
    }

    [HttpGet("{userId:guid}")]
    public async Task<ActionResult<List<InventoryItemDto>>> GetInventory(Guid userId)
    {
        var inventory = await _inventoryService.GetInventoryAsync(userId);
        return Ok(inventory);
    }

    [HttpPost("{userId:guid}/buy")]
    public async Task<ActionResult<InventoryItemDto>> BuyComponent(Guid userId, BuyComponentDto dto)
    {
        try
        {
            var item = await _inventoryService.BuyComponentAsync(userId, dto);
            return Ok(item);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("{userId:guid}/use")]
    public async Task<IActionResult> UseInventoryItem(Guid userId, UseInventoryItemDto dto)
    {
        try
        {
            await _inventoryService.UseInventoryItemAsync(userId, dto);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
