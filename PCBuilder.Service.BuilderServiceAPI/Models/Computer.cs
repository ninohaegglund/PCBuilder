namespace PCBuilder.Service.BuilderServiceAPI.Models;

public class Computer
{
    public int Id { get; set; }
    public string? Name { get; set; }

    public int? CPUId { get; set; }
    public int? PSUId { get; set; }
    public int? MotherboardId { get; set; }
    public int? CaseId { get; set; }
    public int? CpuCoolerId { get; set; }
    public int? KeyboardId { get; set; }
    public int? MouseId { get; set; }
    public int? HeadsetId { get; set; }

    public List<int> GPUIds { get; set; } = new();
    public List<int> RAMIds { get; set; } = new();
    public List<int> StorageIds { get; set; } = new();
    public List<int> CaseFanIds { get; set; } = new();
    public List<int> MonitorIds { get; set; } = new();
    public List<int> SpeakerIds { get; set; } = new();
}