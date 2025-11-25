namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;

public class MotherboardDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Manufacturer { get; set; }
    public string Socket { get; set; } = null!;
    public string? FormFactor { get; set; }
    public int? MaxMemoryGB { get; set; }
    public int? MemorySlots { get; set; }
    public string? Color { get; set; }
    public bool? HasWiFi { get; set; }
    public decimal? Price { get; set; }
}