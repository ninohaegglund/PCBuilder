using PCBuilder.Services.ComponentsAPI.Models.Components;

namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Chassi;

    public class Chassi
    {
        public int CaseId { get; set; }
        public string Manufacturer { get; set; } = null!;
        public string ModelName { get; set; } = null!;


        public int? ComputerId { get; set; }
        public Computer? Computer { get; set; }


        public ChassiMaterial ChassiMaterial { get; set; }
        public int MaxGpuLengthMm { get; set; }
    }
