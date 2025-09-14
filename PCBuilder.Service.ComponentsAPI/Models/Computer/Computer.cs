using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cables;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cables.PCIe;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Chassi;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cooling;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Headsets;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Keyboards;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Mice;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Speakers;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Motherboards;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.PSUs;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.RAM;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.StorageDevice;

namespace PCBuilder.Services.ComponentsAPI.Models;

public class Computer
{
    public int Id { get; set; }

    // 1-1 relationer
    public int? CPUId { get; set; }
    public CPU? Cpu { get; set; }

    public int? PSUId { get; set; }
    public PSU? PSU { get; set; }

    public int? MotherboardId { get; set; }
    public Motherboard? Motherboard { get; set; }

    public int? CaseId { get; set; }
    public Chassi? Case { get; set; }

    public int? CpuCoolerId { get; set; }
    public CPUCooling? CPUCooler { get; set; }

    public int? KeyboardId { get; set; }
    public Keyboard? Keyboard { get; set; }

    public int? MouseId { get; set; }
    public Mouse? Mouse { get; set; }

    public int? HeadsetId { get; set; }
    public Headset? Headset { get; set; }

    // 1-many relationer
    public List<GPU> GPU { get; set; } = new();
    public List<RAM> RamModules { get; set; } = new();
    public List<StorageDevice> Storage { get; set; } = new();
    public List<ChassiCooling> CaseFans { get; set; } = new();
    public List<PCIeCable> PCIeCables { get; set; } = new();
    public List<PowerCable> PowerCables { get; set; } = new();
    public List<SataCable> SataCables { get; set; } = new();
    public List<DisplayMonitor> Monitor { get; set; } = new();
    public List<Speaker> Speakers { get; set; } = new();
}