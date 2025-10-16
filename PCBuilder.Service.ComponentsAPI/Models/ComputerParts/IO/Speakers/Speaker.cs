using ComponentParent = PCBuilder.Service.ComponentsAPI.Models.Components;

namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Speakers;

public class Speaker : ComponentParent
{
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }

    public int? ComputerId { get; set; }
    public int Watt { get; set; }
    public bool IsWireless { get; set; }
}
