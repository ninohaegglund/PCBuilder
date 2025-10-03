namespace PCBuilder.Services.ComponentsAPI.DTOs
{
    public class ComputerDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }


        // 1-1 relations
        public int? CPUId { get; set; }
        public string? CPUName { get; set; }

        public int? PSUId { get; set; }
        public string? PSUName { get; set; }

        public int? MotherboardId { get; set; }
        public string? MotherboardName { get; set; }

        public int? CaseId { get; set; }
        public string? CaseName { get; set; }

        public int? CpuCoolerId { get; set; }
        public string? CPUCoolerName { get; set; }

        public int? KeyboardId { get; set; }
        public string? KeyboardName { get; set; }

        public int? MouseId { get; set; }
        public string? MouseName { get; set; }

        public int? HeadsetId { get; set; }
        public string? HeadsetName { get; set; }

        // 1-many relations
        public List<int> GPUIds { get; set; } = new();
        public List<string> GPUNames { get; set; } = new();
        public List<int> RAMIds { get; set; } = new();
        public List<string> RAMNames { get; set; } = new();
        public List<int> StorageIds { get; set; } = new();
        public List<string> StorageNames { get; set; } = new();
        public List<int> CaseFanIds { get; set; } = new();
        public List<string> CaseFanNames { get; set; } = new();
        public List<int> PCIeCableIds { get; set; } = new();
        public List<int> PowerCableIds { get; set; } = new();
        public List<int> SataCableIds { get; set; } = new();
        public List<int> MonitorIds { get; set; } = new();
        public List<string> MonitorNames { get; set; } = new();
        public List<int> SpeakerIds { get; set; } = new();
        public List<string> SpeakerNames { get; set; } = new();
    }
}