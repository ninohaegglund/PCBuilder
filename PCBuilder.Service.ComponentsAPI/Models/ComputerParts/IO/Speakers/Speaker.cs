namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Speakers;

public class Speaker
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public decimal Price { get; set; }

    public int? ComputerId { get; set; }
    public int Watt { get; set; }
    public bool IsWireless { get; set; }
}
