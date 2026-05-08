namespace PCBuilder.Web.ViewModels.Inventory;

public class InventoryViewModel
{
    public List<InventoryItemViewModel> Items { get; set; } = new();
    public decimal? WalletBalance { get; set; }
}
