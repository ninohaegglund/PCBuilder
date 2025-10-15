using PCBuilder.Services.ComponentsAPI.Models.Components;

namespace PCBuilder.Service.ComponentsAPI.Models.DTO;

public class ChassiDTO
{
    public int Id { get; set; }
    public string Manufacturer { get; set; } = null!;
    public decimal Price { get; set; }

    public string ModelName { get; set; } = null!;
    public ChassiMaterial ChassiMaterial { get; set; }
    public int MaxGpuLengthMm { get; set; }
}
