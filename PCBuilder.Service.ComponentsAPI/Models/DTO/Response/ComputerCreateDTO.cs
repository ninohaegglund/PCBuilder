namespace PCBuilder.Service.ComponentsAPI.Models.DTO.Response;

public class ComputerCreateDTO
{
    public int Id { get; set; }
    public string? Name { get; set; } 
    public int CPUId { get; set; }
    public int PSUId { get; set; }
    public int MotherboardId { get; set; }
    public int CaseId { get; set; }
    public int CpuCoolerId { get; set; }
    public int KeyboardId { get; set; }
    public int MouseId { get; set; }
    public int HeadsetId { get; set; }
    public List<int> GPUIds { get; set; }
    public List<int> RAMIds { get; set; }
    public List<int> StorageIds { get; set; }
    public List<int> CaseFanIds { get; set; }
    public List<int> PCIeCableIds { get; set; }
    public List<int> PowerCableIds { get; set; }
    public List<int> SataCableIds { get; set; }
    public List<int> MonitorIds { get; set; }
    public List<int> SpeakerIds { get; set; }
}