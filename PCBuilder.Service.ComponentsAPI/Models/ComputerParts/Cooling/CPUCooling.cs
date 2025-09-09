namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cooling;



public class CPUCooling
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public int CoolingCapacityW { get; set; } // how much heat the cooler can dissipate
    public int NoiseLevelDb { get; set; } // noise level in decibels
    public string SocketType { get; set; } = null!; 
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
