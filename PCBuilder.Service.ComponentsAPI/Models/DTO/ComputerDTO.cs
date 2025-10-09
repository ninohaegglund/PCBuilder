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
        public List<int>? GPUIds { get; set; } 
        public List<string>? GPUNames { get; set; } 
        public List<int>? RAMIds { get; set; }
        public List<string>? RAMNames { get; set; } 
        public List<int>? StorageIds { get; set; }
        public List<string>? StorageNames { get; set; } 
        public List<int>? CaseFanIds { get; set; } 
        public List<string>? CaseFanNames { get; set; }
        public List<int>? PCIeCableIds { get; set; } 
        public List<int>? PowerCableIds { get; set; }
        public List<int>? SataCableIds { get; set; }
        public List<int>? MonitorIds { get; set; }
        public List<string>? MonitorNames { get; set; }
        public List<int>? SpeakerIds { get; set; }
        public List<string>? SpeakerNames { get; set; }
    }
}