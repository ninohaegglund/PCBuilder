using PCBuilder.Services.InventoryAPI.DTO;

namespace PCBuilder.Services.InventoryAPI.IServices;

public interface IInventoryService
{
    Task<List<InventoryItemDto>> GetInventoryAsync(Guid userId);

    Task<InventoryItemDto> BuyComponentAsync(Guid userId, BuyComponentDto dto);

    Task UseInventoryItemAsync(Guid userId, UseInventoryItemDto dto);
}
