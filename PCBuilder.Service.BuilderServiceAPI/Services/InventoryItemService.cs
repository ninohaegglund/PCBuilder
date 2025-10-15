using Microsoft.Identity.Client;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.Utility;

namespace PCBuilder.Service.BuilderServiceAPI.Services;

public class InventoryItemService : IInventoryItemService
{

    private readonly IBuilderBaseService _baseService;
    public InventoryItemService(IBuilderBaseService baseService)
    {
        _baseService = baseService;
    }
    public async Task<ResponseDTO?> CreateInventoryItemAsync(InventoryItemDTO inventoryItemDTO)
    {
        return await _baseService.SendAsync(new RequestDTO()
        {
            ApiType = SD.ApiType.POST,
            Data = inventoryItemDTO,
            Url = SD.InventoryAPIBase + "/api/inventoryitem"
        });
    }
    public async Task<ResponseDTO?> GetAllInventoryItemsAsync()
    {
        return await _baseService.SendAsync(new RequestDTO()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.InventoryAPIBase + "/api/inventoryitem"
        });

    }
    public async Task<ResponseDTO?> GetInventoryItemByIdAsync(int id)
    {
        return await _baseService.SendAsync(new RequestDTO()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.InventoryAPIBase + "/api/inventoryitem/" + id
        });

    }

    public async Task<ResponseDTO?> DeleteInventoryItemAsync(int id)
    {
        return await _baseService.SendAsync(new RequestDTO()
        {
            ApiType = SD.ApiType.DELETE,
            Url = SD.InventoryAPIBase + "/api/inventoryitem/" + id
        });
    }

    public async Task<ResponseDTO?> GetInventoryByNameAsync(string name)
    {
        return await _baseService.SendAsync(new RequestDTO()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.InventoryAPIBase + "/api/inventoryitem/GetByName/" + name
        });
    }
}
