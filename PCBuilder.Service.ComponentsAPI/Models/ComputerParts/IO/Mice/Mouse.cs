using ComponentParent = PCBuilder.Service.ComponentsAPI.Models.Components;
namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Mice;

public class Mouse : ComponentParent
{
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }

    public int Dpi { get; set; }
    public bool IsWireless { get; set; }
    public int NumberOfButtons { get; set; }
}
