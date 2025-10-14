using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;

namespace PCBuilder.Service.BuilderServiceAPI.IService
{
    public interface IInventoryItemService
    {
        Task<ResponseDTO?> CreateInventoryItemAsync(InventoryItemDTO inventoryItemDTO);
        Task<ResponseDTO?> DeleteInventoryItemAsync(int id);
        Task<ResponseDTO?> GetAllInventoryItemsAsync();
        Task<ResponseDTO?> GetInventoryItemByIdAsync(int id);
        Task<ResponseDTO?> GetInventoryByNameAsync(string name);
    }
}