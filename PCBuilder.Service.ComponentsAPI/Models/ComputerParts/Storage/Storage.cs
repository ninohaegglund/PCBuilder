namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Storage
{
    public abstract class Storage
    {
        public int Id { get; set; }
        public string ModelName { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public int CapacityGb { get; set; }
        public string Interface { get; set; } = null!;
        public int PowerConsumptionW { get; set; }
        public int ReadSpeedMb { get; set; }
        public int WriteSpeedMb { get; set; }
    }

    public class SSD : Storage
    {
        public string FormFactor { get; set; } = null!;
        public string NandType { get; set; } = null!;
    }

    public class HDD : Storage
    {
        public int Rpm { get; set; }
        public int CacheMb { get; set; }
    }
}
