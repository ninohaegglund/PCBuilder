using PCBuilder.Services.InventoryAPI.DTO;
using PCBuilder.Services.InventoryAPI.IRepository;
using PCBuilder.Services.InventoryAPI.IServices;
using PCBuilder.Services.InventoryAPI.Models;

namespace PCBuilder.Services.InventoryAPI.Services;

public class InventoryService : IInventoryService
{
    private readonly IInventoryRepository _inventoryRepository;
    private readonly IWalletService _walletService;

    public InventoryService(IInventoryRepository inventoryRepository, IWalletService walletService)
    {
        _inventoryRepository = inventoryRepository;
        _walletService = walletService;
    }

    public async Task<List<InventoryItemDto>> GetInventoryAsync(Guid userId)
    {
        var items = await _inventoryRepository.GetByUserIdAsync(userId);

        return items
            .OrderBy(x => x.ComponentType)
            .ThenBy(x => x.ComponentId)
            .Select(MapToDto)
            .ToList();
    }

    public async Task<InventoryItemDto> BuyComponentAsync(Guid userId, BuyComponentDto dto)
    {
        if (dto.Quantity <= 0)
        {
            throw new ArgumentException("Quantity must be greater than zero.");
        }

        if (string.IsNullOrWhiteSpace(dto.ComponentType))
        {
            throw new ArgumentException("ComponentType is required.");
        }

        if (dto.PurchasePrice <= 0)
        {
            throw new ArgumentException("PurchasePrice must be greater than zero.");
        }

        var totalCost = dto.PurchasePrice * dto.Quantity;
        var hasFunds = await _walletService.HasEnoughFundsAsync(userId, totalCost);

        if (!hasFunds)
        {
            throw new InvalidOperationException("Not enough funds in wallet.");
        }

        await _walletService.WithdrawAsync(userId, totalCost);

        var item = await _inventoryRepository.GetByComponentAsync(userId, dto.ComponentType, dto.ComponentId);

        if (item != null)
        {
            item.Quantity += dto.Quantity;
            item.PurchasePrice = dto.PurchasePrice;

            await _inventoryRepository.UpdateAsync(item);
        }
        else
        {
            item = new InventoryItem
            {
                UserId = userId,
                ComponentType = dto.ComponentType,
                ComponentId = dto.ComponentId,
                Quantity = dto.Quantity,
                PurchasePrice = dto.PurchasePrice,
                PurchasedAt = DateTime.UtcNow
            };

            await _inventoryRepository.AddAsync(item);
        }

        await _inventoryRepository.SaveChangesAsync();

        return MapToDto(item);
    }

    public async Task UseInventoryItemAsync(Guid userId, UseInventoryItemDto dto)
    {
        if (dto.Quantity <= 0)
        {
            throw new ArgumentException("Quantity must be greater than zero.");
        }

        var item = await _inventoryRepository.GetByComponentAsync(userId, dto.ComponentType, dto.ComponentId);

        if (item == null)
        {
            throw new InvalidOperationException("Inventory item not found.");
        }

        if (item.Quantity < dto.Quantity)
        {
            throw new InvalidOperationException("Not enough quantity in inventory.");
        }

        item.Quantity -= dto.Quantity;

        await _inventoryRepository.UpdateAsync(item);
        await _inventoryRepository.SaveChangesAsync();
    }

    public async Task UseInventoryItemsAsync(Guid userId, IEnumerable<UseInventoryItemDto> items)
    {
        var requestedItems = NormalizeItems(items);
        await EnsureInventoryItemsAsync(userId, requestedItems);

        foreach (var requestedItem in requestedItems)
        {
            var inventoryItem = await _inventoryRepository.GetByComponentAsync(
                userId,
                requestedItem.ComponentType,
                requestedItem.ComponentId);

            if (inventoryItem == null)
            {
                continue;
            }

            inventoryItem.Quantity -= requestedItem.Quantity;
            await _inventoryRepository.UpdateAsync(inventoryItem);
        }

        await _inventoryRepository.SaveChangesAsync();
    }

    public async Task EnsureInventoryItemsAsync(Guid userId, IEnumerable<UseInventoryItemDto> items)
    {
        var requestedItems = NormalizeItems(items);

        foreach (var requestedItem in requestedItems)
        {
            var inventoryItem = await _inventoryRepository.GetByComponentAsync(
                userId,
                requestedItem.ComponentType,
                requestedItem.ComponentId);

            if (inventoryItem == null)
            {
                throw new InvalidOperationException($"{requestedItem.ComponentType} #{requestedItem.ComponentId} is missing from inventory.");
            }

            if (inventoryItem.Quantity < requestedItem.Quantity)
            {
                throw new InvalidOperationException($"Not enough {requestedItem.ComponentType} #{requestedItem.ComponentId} in inventory.");
            }
        }
    }

    private static List<UseInventoryItemDto> NormalizeItems(IEnumerable<UseInventoryItemDto> items)
    {
        return items
            .Where(x => x.Quantity > 0 && !string.IsNullOrWhiteSpace(x.ComponentType))
            .GroupBy(x => new { x.ComponentType, x.ComponentId })
            .Select(x => new UseInventoryItemDto
            {
                ComponentType = x.Key.ComponentType,
                ComponentId = x.Key.ComponentId,
                Quantity = x.Sum(item => item.Quantity)
            })
            .ToList();
    }

    private static InventoryItemDto MapToDto(InventoryItem item)
    {
        return new InventoryItemDto
        {
            Id = item.Id,
            UserId = item.UserId,
            ComponentType = item.ComponentType,
            ComponentId = item.ComponentId,
            Quantity = item.Quantity,
            PurchasePrice = item.PurchasePrice,
            PurchasedAt = item.PurchasedAt
        };
    }
}
