namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;

public class OperatingSystemDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Architecture { get; set; }
    public int? MaxMemoryGB { get; set; }
    public decimal? Price { get; set; }
}