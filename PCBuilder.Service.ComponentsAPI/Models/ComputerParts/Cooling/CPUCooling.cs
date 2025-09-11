using PCBuilder.Services.ComponentsAPI.Models.Components;

public class CPUCooling
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public int CoolingCapacityW { get; set; }
    public int NoiseLevelDb { get; set; }
    public CoolingType Type { get; set; }
    public List<CPUSocket> CompatibleSockets { get; set; } = new();
}

public class AirCooler : CPUCooling
{
    public int FanSizeMm { get; set; }
    public int Rpm { get; set; }
}

public class WaterCooler : CPUCooling
{
    public int RadiatorSizeMm { get; set; }
}