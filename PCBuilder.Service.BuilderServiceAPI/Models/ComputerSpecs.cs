using PCBuilder.Service.BuilderServiceAPI.Enums;

namespace PCBuilder.Service.BuilderServiceAPI.Models;

public class ComputerSpecs
{
    public decimal TotalPrice { get; set; }
    public int TotalPerformanceScore { get; set; }
    public int TotalWattage { get; set; }
    public int TotalTDP { get; set; }
    public int CoolingCapacity { get; set; }
    public int MaxNoiseDb { get; set; }
    public CompabilityWarnings CompatibilityWarnings { get; set; }
}
