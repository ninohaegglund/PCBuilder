namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Motherboards
{
    public abstract class Motherboard
    {
        public int Id { get; set; }
        public string ModelName { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public string Socket { get; set; } = null!;
        public string Chipset { get; set; } = null!;
        public int RamSlots { get; set; }
        public string SupportedRamType { get; set; } = null!;
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
}
