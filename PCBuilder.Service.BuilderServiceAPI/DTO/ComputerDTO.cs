using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.PSUs;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Motherboards;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Chassi;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cooling;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Keyboards;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Mice;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Headsets;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.RAM;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.StorageDevice;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Speakers;

namespace PCBuilder.Service.BuilderServiceAPI.DTO;

public class ComputerDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public int CustomerId { get; set; }

    // 1-1 relations
    public int? CPUId { get; set; }
    public CPU? CPU { get; set; }

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

    public List<int>? GPUIds { get; set; }
    public List<GPU>? GPUs { get; set; }

    public List<int>? RAMIds { get; set; }
    public List<RAM>? RAMs { get; set; }

    public List<int>? StorageIds { get; set; }
    public List<StorageDevice>? Storages { get; set; }

    public List<int>? CaseFanIds { get; set; }
    public List<ChassiCooling>? CaseFans { get; set; }

    public List<int>? MonitorIds { get; set; }
    public List<DisplayMonitor>? Monitors { get; set; }

    public List<int>? SpeakerIds { get; set; }
    public List<Speaker>? Speakers { get; set; }
}