using PCBuilder.Services.ComponentsAPI.Models.Components;

namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.RAM;

public class RAM
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public int? ComputerId { get; set; }
    public int CapacityGb { get; set; }
    public int SpeedMHz { get; set; }
    public RAMType Type { get; set; }
}
