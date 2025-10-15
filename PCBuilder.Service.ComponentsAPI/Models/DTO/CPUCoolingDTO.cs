using PCBuilder.Services.ComponentsAPI.Models.Components;

namespace PCBuilder.Service.ComponentsAPI.Models.DTO;

public class CPUCoolingDTO
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public decimal Price { get; set; }

    public int CoolingCapacityW { get; set; }
    public int NoiseLevelDb { get; set; }
    public CoolingType Type { get; set; }
    public List<CPUSocket> CompatibleSockets { get; set; } = new();
}

public class AirCooler : CPUCoolingDTO
{
    public int FanSizeMm { get; set; }
    public int Rpm { get; set; }
}

public class WaterCooler : CPUCoolingDTO
{
    public int RadiatorSizeMm { get; set; }
}
