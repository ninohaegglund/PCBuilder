using PCBuilder.Services.ComponentsAPI.Models.Components;

namespace PCBuilder.Service.ComponentsAPI.Models.DTO
{
    public class GPUDto
    {
        public int Id { get; set; }
        public string ModelName { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public int VramGb { get; set; }
        public VRAMType VramType { get; set; }
        public int LengthMm { get; set; }
        public int PowerConsumptionW { get; set; }
        public int TDP { get; set; }
        public GPUInterface Interface { get; set; }
    }

    public class NvidiaGpuDTO : GPUDto
    {
        public int CudaCores { get; set; }
        public int TensorCores { get; set; }
    }

    public class AmdGpuDTO : GPUDto
    {
        public int StreamProcessors { get; set; }
        public bool InfinityCache { get; set; }
    }

}
