using PCBuilder.Services.ComponentsAPI.Models.Components;

public class DisplayMonitor
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public double SizeInches { get; set; }
    public RefreshRate Hz { get; set; }
    public MonitorResolution Resolution { get; set; }
}