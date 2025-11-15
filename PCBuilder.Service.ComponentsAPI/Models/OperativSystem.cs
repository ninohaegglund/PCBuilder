namespace PCBuilder.Service.ComponentsAPI.Models;

public class OperativSystem
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int Mode { get; set; }
    public int MaxMemory { get; set; }
}
