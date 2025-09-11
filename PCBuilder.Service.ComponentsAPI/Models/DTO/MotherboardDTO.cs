using PCBuilder.Services.ComponentsAPI.Models.Components;

namespace PCBuilder.Service.ComponentsAPI.Models.DTO
{
    public class MotherboardDTO
    {
        public int Id { get; set; }
        public string ModelName { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public CPUSocket Socket { get; set; }
        public string Chipset { get; set; } = null!;
        public int RamSlots { get; set; }
        public RAMType SupportedRamType { get; set; }
        public int MaxRamCapacityGb { get; set; }
        public int PcieSlots { get; set; }
    }


    public class AtxMotherboard : MotherboardDTO
    {
        public bool SupportsMultiGpu { get; set; }
        public int MaxPcieLengthMm { get; set; }
    }

    public class MicroAtxMotherboard : MotherboardDTO
    {
        public bool SupportsMultiGpu { get; set; }
        public int MaxPcieLengthMm { get; set; }
    }

    public class MiniItxMotherboard : MotherboardDTO
    {
        public bool SupportsMultiGpu { get; set; }
        public int MaxPcieLengthMm { get; set; }
    }

}
