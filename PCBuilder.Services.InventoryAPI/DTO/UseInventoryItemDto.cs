namespace PCBuilder.Services.InventoryAPI.DTO;

public class UseInventoryItemDto
{
    public string ComponentType { get; set; } = string.Empty;
    public int ComponentId { get; set; }
    public int Quantity { get; set; } = 1;
}
