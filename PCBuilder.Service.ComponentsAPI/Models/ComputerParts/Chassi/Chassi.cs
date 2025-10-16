using PCBuilder.Services.ComponentsAPI.Models.Components;
using ComponentParent = PCBuilder.Service.ComponentsAPI.Models.Components;


namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Chassi;

public class Chassi : ComponentParent
{
    public string Manufacturer { get; set; } = null!;
    public string ModelName { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }

    public CaseFormFactor FormFactor { get; set; }
    public ChassiMaterial ChassiMaterial { get; set; }
    public int MaxGpuLengthMm { get; set; }
}
