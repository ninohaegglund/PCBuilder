namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;
public class HeadphonesDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Type { get; set; }
    public int? FrequencyMinHz { get; set; }
    public int? FrequencyMaxKhz { get; set; }
    public bool Microphone { get; set; }
    public bool Wireless { get; set; }
    public string? EnclosureType { get; set; }
    public string? Color { get; set; }
    public decimal? Price { get; set; }
}