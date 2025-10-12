using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;

namespace PCBuilder.Service.BuilderServiceAPI.IService
{
    public interface IInventoryService
    {
        Task<ResponseDTO?> CreateInventoryAsync(InventoryDTO inventoryDto);
        Task DeleteInventoryItemAsync(int id);
        Task GetAllInventoriesAsync();
        Task GetInventoryByIdAsync(int id);
        Task UpdateInventoryItemAsync(int id, InventoryDTO inventoryDto);
    }
}