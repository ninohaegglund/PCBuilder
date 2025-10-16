namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Headsets;
using ComponentParent = PCBuilder.Service.ComponentsAPI.Models.Components;

public class Headset : ComponentParent
{
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }

    public bool IsWireless { get; set; }
    public bool HasMicrophone { get; set; }
}
