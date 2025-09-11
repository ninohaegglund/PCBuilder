using PCBuilder.Services.ComponentsAPI.Models.Components;

namespace PCBuilder.Service.ComponentsAPI.Models.DTO;

public class GPUCoolingDTO
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public CoolingType CoolerType { get; set; }
    public int CoolingCapacityW { get; set; }
    public int NoiseLevelDb { get; set; }
    public int PowerConsumptionW { get; set; }
}
public class AirGpuCooler : GPUCoolingDTO
{
    public int FanCount { get; set; }
    public int FanSizeMm { get; set; }
    public int MaxRpm { get; set; }
}
public class WaterGpuCooler : GPUCoolingDTO
{
    public int RadiatorSizeMm { get; set; }
    public int PumpPowerW { get; set; }
    public int FanCount { get; set; }
}
