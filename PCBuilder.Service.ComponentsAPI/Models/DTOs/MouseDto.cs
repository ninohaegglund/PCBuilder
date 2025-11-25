namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;

public class MouseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? TrackingMethod { get; set; }
    public string? Connection { get; set; }
    public int? MaxDpi { get; set; }
    public string? HandOrientation { get; set; }
    public string? Color { get; set; }
    public decimal? Price { get; set; }
}