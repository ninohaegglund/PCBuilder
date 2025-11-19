namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;

public class CaseFanDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public int SizeMM { get; set; }
    public string? Color { get; set; }
    public int? RpmMin { get; set; }
    public int? RpmMax { get; set; }
    public decimal? AirflowMin { get; set; }
    public decimal? AirflowMax { get; set; }
    public decimal? NoiseLevelMin { get; set; }
    public decimal? NoiseLevelMax { get; set; }
    public bool Pwm { get; set; }
    public decimal? Price { get; set; }
}