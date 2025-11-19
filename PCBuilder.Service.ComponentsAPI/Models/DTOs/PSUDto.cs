namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;

public class PSUDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Type { get; set; }
    public string? EfficiencyRating { get; set; }
    public int Wattage { get; set; }
    public string? Modular { get; set; }
    public string? Color { get; set; }
    public decimal? Price { get; set; }
}