using Microsoft.Identity.Client;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.Utility;

namespace PCBuilder.Service.BuilderServiceAPI.Services;

public class InventoryService : IInventoryService
{

    private readonly IBuilderBaseService _baseService;
    public InventoryService(IBuilderBaseService baseService)
    {
        _baseService = baseService;
    }
    //CREATE
    public async Task<ResponseDTO?> CreateInventoryAsync(InventoryDTO inventoryDto)
    {
        return await _baseService.SendAsync(new RequestDTO()
        {
            ApiType = SD.ApiType.POST,
            Data = inventoryDto,
            Url = SD.InventoryAPIBase + "/api/inventory"
        });
    }
    //READ
    public async Task GetAllInventoriesAsync()
    {
        await _baseService.SendAsync(new RequestDTO()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.InventoryAPIBase + "/api/inventory"
        });

    }
    public async Task GetInventoryByIdAsync(int id)
    {
        await _baseService.SendAsync(new RequestDTO()
        {
            ApiType = SD.ApiType.GET,
            Url = SD.InventoryAPIBase + "/api/inventory/" + id
        });

    }
    //UPDATE
    public async Task UpdateInventoryItemAsync(int id, InventoryDTO inventoryDto)
    {
        await _baseService.SendAsync(new RequestDTO()
        {
            ApiType = SD.ApiType.PUT,
            Data = inventoryDto,
            Url = SD.InventoryAPIBase + "/api/inventory/" + id
        });


    }
    //DELETE
    public async Task DeleteInventoryItemAsync(int id)
    {
        await _baseService.SendAsync(new RequestDTO()
        {
            ApiType = SD.ApiType.DELETE,
            Url = SD.InventoryAPIBase + "/api/inventory/" + id
        });

    }


}
