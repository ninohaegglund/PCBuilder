namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;

public class CaseAccessoryDto
{
    public int Id { get; set; }
    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string? Type { get; set; }
    public string? FormFactor { get; set; }
    public decimal? Price { get; set; }
}