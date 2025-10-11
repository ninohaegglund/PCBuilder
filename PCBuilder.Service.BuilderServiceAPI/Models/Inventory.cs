namespace PCBuilder.Service.BuilderServiceAPI.Models;

public class Inventory
{
    public int Id { get; set; }
    public string InventoryName { get; set; } = null!;
    public int ComponentId { get; set; }
    public int Quantity { get; set; }
}