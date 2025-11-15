namespace PCBuilder.Service.ComponentsAPI.Models;

public class PowerSupply
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public string Type { get; set; } = null!;
    public string Efficiency { get; set; } = null!;
    public int Wattage { get; set; }
    public string Modular { get; set; } = null!;
    public string Color { get; set; } = null!;
}
