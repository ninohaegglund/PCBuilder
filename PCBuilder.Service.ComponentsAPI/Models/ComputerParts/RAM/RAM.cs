using PCBuilder.Services.ComponentsAPI.Models.Components;
using ComponentParent = PCBuilder.Service.ComponentsAPI.Models.Components;

namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.RAM;

public class RAM : ComponentParent
{
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }

    public int? ComputerId { get; set; }
    public int CapacityGb { get; set; }
    public int SpeedMHz { get; set; }
    public RAMType Type { get; set; }
}
