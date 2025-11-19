namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;
public class CPUCoolerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsAio { get; set; }
    public int? RadiatorSize { get; set; }
    public int? RpmMin { get; set; }
    public int? RpmMax { get; set; }
    public decimal? NoiseLevelMin { get; set; }
    public decimal? NoiseLevelMax { get; set; }
    public string? Color { get; set; }
    public decimal? Price { get; set; }
}