namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cooling;

public  class GPUCooling
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string CoolerType { get; set; } = null!;
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
