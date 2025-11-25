namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;
public class SoundCardDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Channels { get; set; }
    public int? DigitalAudioBits { get; set; }
    public int? SnrDb { get; set; }
    public int? SampleRateKhz { get; set; }
    public string? Chipset { get; set; }
    public string? Interface { get; set; }
    public decimal? Price { get; set; }
}