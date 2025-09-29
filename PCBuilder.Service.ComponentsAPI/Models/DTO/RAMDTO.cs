using PCBuilder.Services.ComponentsAPI.Models.Components;

namespace PCBuilder.Service.ComponentsAPI.Models.DTO;

public class RAMDTO
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public int CapacityGb { get; set; }
    public int SpeedMHz { get; set; }
    public RAMType Type { get; set; }
}
