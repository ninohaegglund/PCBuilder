namespace PCBuilder.Service.ComponentsAPI.Models;

public class Case
{
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public string Type { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string Psu { get; set; } = null!;
    public string SidePanel { get; set; } = null!;
    public int ExternalVolume { get; set; }
    public int Internal35Bays { get; set; }
}
