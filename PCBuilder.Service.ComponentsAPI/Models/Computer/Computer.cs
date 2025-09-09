using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cables;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cables.PCIe;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Chassi;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cooling;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Headsets;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Keyboards;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Mice;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Monitors;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Speakers;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Motherboards;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.PSUs;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.RAM;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.StorageDevice;

namespace PCBuilder.Services.ComponentsAPI.Models
{
    public class Computer
    {
        // Single-instance components
        public CPU? Cpu { get; set; }
        public Motherboard? Motherboard { get; set; }
        public PSU? PSU { get; set; }
        public Chassi? Case { get; set; }
        public CPUCooling? CPUCooler { get; set; }
        public Keyboard? Keyboard { get; set; }
        public Mouse? Mouse { get; set; }
        public Headset? Headset { get; set; }

        // Multi-instance components
        public List<GPU> GPU { get; set; } = null!;
        public List<RAM> RamModules { get; set; } = null!;
        public List<StorageDevice> Storage { get; set; } = null!;
        public List<ChassiCooling> CaseFans { get; set; } = null!;
        public List<PCIeCable> PCIeCables { get; set; } = null!;
        public List<PowerCable> PowerCables { get; set; } = null!;
        public List<SataCable> Satacables { get; set; } = null!;
        public List<DisplayMonitor> Monitor { get; set; } = null!;
        public List<Speaker> Speakers { get; set; } = null!;  
    }
}
