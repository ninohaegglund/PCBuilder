namespace PCBuilder.Service.BuilderServiceAPI.DTO;

public class InventoryDTO
{
    public int Id { get; set; }
    public string InventoryName { get; set; } = null!;
    public int ComponentId { get; set; }
    public int Quantity { get; set; }
}
