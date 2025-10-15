using PCBuilder.Services.ComponentsAPI.Models.Components;

namespace PCBuilder.Service.ComponentsAPI.Models.DTO
{
    public class StorageDTO
    {
        public int Id { get; set; }
        public string ModelName { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public decimal Price { get; set; }

        public int CapacityGb { get; set; }
        public StorageInterface Interface { get; set; }
        public int PowerConsumptionW { get; set; }
        public int ReadSpeedMb { get; set; }
        public int WriteSpeedMb { get; set; }
    }

    public class SSDDTO : StorageDTO
    {
        public SSDFormFactor FormFactor { get; set; }
        public string NandType { get; set; } = null!;
    }

    public class HDDDTO : StorageDTO
    {
        public int Rpm { get; set; }
        public int CacheMb { get; set; }
    }
}
