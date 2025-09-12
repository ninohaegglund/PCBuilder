using PCBuilder.Services.ComponentsAPI.Models.Components;

namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Motherboards;

public class Motherboard
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;

    public int? ComputerId { get; set; }
    public Computer? Computer { get; set; }

    public CPUSocket Socket { get; set; }
    public string Chipset { get; set; } = null!;
    public int RamSlots { get; set; }
    public RAMType SupportedRamType { get; set; }
    public int MaxRamCapacityGb { get; set; }
    public int PcieSlots { get; set; }
}


public class AtxMotherboard : Motherboard
{
    public bool SupportsMultiGpu { get; set; }
    public int MaxPcieLengthMm { get; set; }
}

public class MicroAtxMotherboard : Motherboard
{
    public bool SupportsMultiGpu { get; set; }
    public int MaxPcieLengthMm { get; set; }
}

public class MiniItxMotherboard : Motherboard
{
   public bool SupportsMultiGpu { get; set; }
    public int MaxPcieLengthMm { get; set; }
}
