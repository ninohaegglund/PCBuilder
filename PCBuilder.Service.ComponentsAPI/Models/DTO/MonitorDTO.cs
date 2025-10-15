using PCBuilder.Services.ComponentsAPI.Models.Components;

namespace PCBuilder.Service.ComponentsAPI.Models.DTO; 

public class MonitorDTO
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public decimal Price { get; set; }
    public double SizeInches { get; set; }
    public RefreshRate Hz { get; set; }
    public MonitorResolution Resolution { get; set; }
}
