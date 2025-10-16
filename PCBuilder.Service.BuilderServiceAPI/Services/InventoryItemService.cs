using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.IRepository;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.BuilderServiceAPI.Models;
using PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCBuilder.Service.BuilderServiceAPI.Services;

public class InventoryItemService : IInventoryItemService
{
    private readonly IRepository<InventoryItem> _repository;
    public InventoryItemService(IRepository<InventoryItem> repository)
    {
        _repository = repository;
    }

    public async Task<ResponseDTO> CreateInventoryItemAsync(InventoryItemDTO inventoryItemDTO)
    {
        var item = new InventoryItem
        {
            Id = inventoryItemDTO.Id,
            Quantity = inventoryItemDTO.Quantity
        };
        await _repository.AddAsync(item);
        return new ResponseDTO
        {
            IsSuccess = true,
            Result = item
        };
    }


    public async Task<ResponseDTO> GetAllInventoryItemsAsync()
    {
        var items = await _repository.GetAllAsync();
        if (items == null || !items.Any())
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = "No items were found",
                Result = null
            };
        }

        return new ResponseDTO
        {
            IsSuccess = true,
            Result = items
        };
    }

    public async Task<ResponseDTO> GetInventoryItemByIdAsync(int id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = $"No item with the id {id} was found.",
                Result = null
            };
        }

        return new ResponseDTO
        {
            IsSuccess = true,
            Result = item
        };
    }

    public async Task<ResponseDTO> DeleteInventoryItemAsync(int id)
    {
        var item = await _repository.GetByIdAsync(id);
        if (item == null)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = $"No item with the id {id} was found",
                Result = null
            };
        }
        await _repository.DeleteAsync(item);
        return new ResponseDTO
        {
            IsSuccess = true,
            Result = null
        };
    }
    public async Task<ResponseDTO?> GetAllItemsAsync()
    {
        var items = await _repository.GetAllAsync();
        if (items == null || !items.Any())
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = "No inventory items found.",
                Result = null
            };
        }
        return new ResponseDTO
        {
            IsSuccess = true,
            Result = items
        };
    }

    /*public async Task<List<string>> GetInventoryNamesByNameAsync(string partialName)
    {
        var allItems = await _repository.GetAllAsync();
        var matchingItems = allItems.Where(x => x.Id != null).ToList();

        var names = new List<string>();
        foreach (var item in matchingItems)
        {
            string name = await _componentsApiService.GetNameByIdAsync(item.ComponentId);
            if (name != null && name.Contains(partialName, StringComparison.OrdinalIgnoreCase))
            {
                names.Add(name);
            }
        }
        return names;
    }*/
}   