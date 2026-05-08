namespace PCBuilder.Services.InventoryAPI.Models;

public class InventoryItem
{
    public int Id { get; set; }

    public Guid UserId { get; set; }

    public string ComponentType { get; set; } = string.Empty;
    public int ComponentId { get; set; }

    public int Quantity { get; set; }

    public decimal PurchasePrice { get; set; }

    public DateTime PurchasedAt { get; set; } = DateTime.UtcNow;
}
