namespace PCBuilder.Services.CustomerAPI.DTO;

public class BuildReviewRequestDto
{
    public int OrderId { get; set; }
    public int Budget { get; set; }

    public int? CpuId { get; set; }
    public int? MotherboardId { get; set; }
    public int? CaseId { get; set; }
    public int? PowerSupplyId { get; set; }
    public int? CpuCoolerId { get; set; }
    public int? KeyboardId { get; set; }
    public int? MouseId { get; set; }
    public int? HeadphonesId { get; set; }
    public int? OperatingSystemId { get; set; }

    public List<int> GpuIds { get; set; } = new();
    public List<int> RamIds { get; set; } = new();
    public List<int> InternalStorageIds { get; set; } = new();
    public List<int> ExternalStorageIds { get; set; } = new();
    public List<int> CaseFanIds { get; set; } = new();
    public List<int> MonitorIds { get; set; } = new();
    public List<int> SpeakerIds { get; set; } = new();
}
