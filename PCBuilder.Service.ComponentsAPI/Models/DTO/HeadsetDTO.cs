namespace PCBuilder.Service.ComponentsAPI.Models.DTO;

public class HeadsetDTO
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public bool IsWireless { get; set; }
    public bool HasMicrophone { get; set; }
}
