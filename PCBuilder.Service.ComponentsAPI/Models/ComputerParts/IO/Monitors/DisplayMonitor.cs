using PCBuilder.Services.ComponentsAPI.Models;
using PCBuilder.Services.ComponentsAPI.Models.Components;

public class DisplayMonitor
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public int? ComputerId { get; set; }
    public Computer? Computer { get; set; }

    public double SizeInches { get; set; }
    public RefreshRate Hz { get; set; }
    public MonitorResolution Resolution { get; set; }
}