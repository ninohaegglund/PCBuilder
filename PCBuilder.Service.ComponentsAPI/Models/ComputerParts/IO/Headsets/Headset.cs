namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Headsets;

public class Headset
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public bool IsWireless { get; set; }
    public bool HasMicrophone { get; set; }
}
