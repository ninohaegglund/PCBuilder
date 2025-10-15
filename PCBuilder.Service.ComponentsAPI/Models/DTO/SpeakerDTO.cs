namespace PCBuilder.Service.ComponentsAPI.Models.DTO;

public class SpeakerDTO
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public decimal Price { get; set; }

    public int Watt { get; set; }
    public bool IsWireless { get; set; }
}
