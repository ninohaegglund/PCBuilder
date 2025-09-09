namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Monitors;

public class DisplayMonitor
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public double SizeInches { get; set; }
    public int RefreshRateHz { get; set; }
    public string Resolution { get; set; } = null!; 
}
