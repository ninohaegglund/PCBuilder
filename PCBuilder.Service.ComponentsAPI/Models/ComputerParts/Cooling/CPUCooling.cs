namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cooling
{
    public abstract class CPUCooling
    {
        public int Id { get; set; }
        public string ModelName { get; set; } = null!;
        public int TdpWatts { get; set; } // how much heat the cooler can dissipate
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
}
