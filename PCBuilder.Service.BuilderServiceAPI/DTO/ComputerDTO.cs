using PCBuilder.Service.ComponentsAPI.Models.DTOs;

namespace PCBuilder.Service.BuilderServiceAPI.DTO
{
    public class ComputerDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CustomerId { get; set; }

        // ─────────────── 1:1 RELATIONER ───────────────
        public int? CpuId { get; set; }
        public CPUDto? Cpu { get; set; }

        public int? GpuId { get; set; }           
        public GPUDto? Gpu { get; set; }

        public int? MotherboardId { get; set; }
        public MotherboardDto? Motherboard { get; set; }

        public int? CaseId { get; set; }
        public CaseDto? Case { get; set; }

        public int? PowerSupplyId { get; set; }
        public PSUDto? PowerSupply { get; set; }

        public int? CpuCoolerId { get; set; }
        public CPUCoolerDto? CpuCooler { get; set; }

        public int? KeyboardId { get; set; }
        public KeyboardDto? Keyboard { get; set; }

        public int? MouseId { get; set; }
        public MouseDto? Mouse { get; set; }

        public int? HeadphonesId { get; set; }
        public HeadphonesDto? Headphones { get; set; }

        public List<int>? GpuIds { get; set; } = new();
        public List<GPUDto>? Gpus { get; set; } = new();

        public List<int>? RamIds { get; set; } = new();
        public List<RAMDto>? Rams { get; set; } = new();

        public List<int>? InternalStorageIds { get; set; } = new();
        public List<InternalStorageDto>? InternalStorages { get; set; } = new();

        public List<int>? ExternalStorageIds { get; set; } = new();
        public List<ExternalStorageDto>? ExternalStorages { get; set; } = new();

        public List<int>? CaseFanIds { get; set; } = new();
        public List<CaseFanDto>? CaseFans { get; set; } = new();

        public List<int>? MonitorIds { get; set; } = new();
        public List<MonitorDto>? Monitors { get; set; } = new();

        public List<int>? SpeakerIds { get; set; } = new();
        public List<SpeakersDto>? Speakers { get; set; } = new();

        public int? OperatingSystemId { get; set; }
        public OperatingSystemDto? OperatingSystem { get; set; }

        public decimal TotalPrice { get; set; }
        public int TotalWattage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}