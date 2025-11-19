namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;
public class WebcamDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Resolutions { get; set; }
    public string? Connection { get; set; }
    public string? FocusType { get; set; }
    public string? SupportedOs { get; set; }
    public int? FovDegrees { get; set; }
    public decimal? Price { get; set; }
}