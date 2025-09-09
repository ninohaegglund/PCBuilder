public class CPU
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public int Cores { get; set; }
    public int Threads { get; set; }
    public double BaseClockGhz { get; set; }
    public double BoostClockGhz { get; set; }
    public int TdpW { get; set; } 
    public int PowerConsumptionW { get; set; }
    public string Socket { get; set; } = null!;
}

public class IntelCpu : CPU
{
    public bool HyperThreading { get; set; }
    public string Generation { get; set; } = null!;
    public string IntegratedGraphics { get; set; } = null!;
}

public class AmdCpu : CPU
{
    public bool SimultaneousMultithreading { get; set; }
    public string Architecture { get; set; } = null!;
    public bool HasIntegratedGraphics { get; set; }
}
