using PCBuilder.Services.ComponentsAPI.Models.Components;
using ComponentParent = PCBuilder.Service.ComponentsAPI.Models.Components;

namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cooling;

public  class GPUCooling : ComponentParent
{
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public decimal Price { get; set; }
    public string Description { get; set; } = null!;

    public int ComputerId { get; set; }
    public CoolingType CoolerType { get; set; }
    public int CoolingCapacityW { get; set; }
    public int NoiseLevelDb { get; set; }
    public int PowerConsumptionW { get; set; }
}
public class AirGpuCooler : GPUCooling
{
    public int FanCount { get; set; }
    public int FanSizeMm { get; set; }
    public int MaxRpm { get; set; }
}
public class WaterGpuCooler : GPUCooling
{
    public int RadiatorSizeMm { get; set; }
    public int PumpPowerW { get; set; }
    public int FanCount { get; set; }
}   
