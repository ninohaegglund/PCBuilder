using PCBuilder.Service.ComponentsAPI.Models;
using PCBuilder.Services.ComponentsAPI.Models.Components;
public class DisplayMonitor : Components
{
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int? ComputerId { get; set; }
    public double SizeInches { get; set; }
    public RefreshRate Hz { get; set; }
    public MonitorResolution Resolution { get; set; }
}