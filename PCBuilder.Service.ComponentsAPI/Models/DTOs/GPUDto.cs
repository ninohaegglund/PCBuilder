namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;

public class GPUDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Manufacturer { get; set; }
    public string? Chipset { get; set; }
    public int? MemoryGB { get; set; }
    public int? CoreClock { get; set; }
    public int? BoostClock { get; set; }
    public int? LengthMM { get; set; }
    public string? Color { get; set; }
    public decimal? Price { get; set; }
}