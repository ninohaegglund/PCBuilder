namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;

public class MonitorDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal ScreenSizeInches { get; set; }
    public int ResolutionWidth { get; set; }
    public int ResolutionHeight { get; set; }
    public int RefreshRateHz { get; set; }
    public decimal? ResponseTimeMs { get; set; }
    public string? PanelType { get; set; }
    public string? AspectRatio { get; set; }
    public decimal? Price { get; set; }
}