namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;

public class FanControllerDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int? Channels { get; set; }
    public int? ChannelWattage { get; set; }
    public bool Pwm { get; set; }
    public string? FormFactor { get; set; }
    public string? Color { get; set; }
    public decimal? Price { get; set; }
}