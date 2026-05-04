namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;

public class GPUDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; set; } = null!;

    public string? Chipset { get; set; }
    public int? MemoryGB { get; set; }
    public int? CoreClock { get; set; }
    public int? BoostClock { get; set; }
    public int? LengthMM { get; set; }
    public decimal? Price { get; set; }
}