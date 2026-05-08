namespace PCBuilder.Web.ViewModels.Inventory;

public class InventoryItemViewModel
{
    public int Id { get; set; }
    public string ComponentType { get; set; } = string.Empty;
    public int ComponentId { get; set; }
    public string DisplayName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal PurchasePrice { get; set; }
    public DateTime PurchasedAt { get; set; }
}
