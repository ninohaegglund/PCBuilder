namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;

public class SpeakersDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Configuration { get; set; }
    public decimal? Wattage { get; set; }
    public int? FrequencyMinHz { get; set; }
    public int? FrequencyMaxKhz { get; set; }
    public string? Color { get; set; }
    public decimal? Price { get; set; }
}