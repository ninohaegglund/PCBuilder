namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;

public class CaseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Type { get; set; }
    public string? Color { get; set; }
    public int? IncludedPowerSupplyWatts { get; set; }
    public string? SidePanel { get; set; }
    public decimal? ExternalVolumeLiters { get; set; }
    public int? Internal35Bays { get; set; }
    public decimal? Price { get; set; }
}
