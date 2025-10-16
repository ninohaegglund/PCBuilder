using PCBuilder.Service.ComponentsAPI.Models;
using PCBuilder.Service.ComponentsAPI.Models.ComputerParts.Cooling;
using PCBuilder.Services.ComponentsAPI.Models.Components;

public class CPUCooling : Components
{
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int CoolingCapacityW { get; set; }
    public int NoiseLevelDb { get; set; }
    public CoolingType Type { get; set; }
    public List<CoolerSocketCompatibility> CompatibleSockets { get; set; } = new();
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