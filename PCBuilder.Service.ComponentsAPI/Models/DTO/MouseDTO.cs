namespace PCBuilder.Service.ComponentsAPI.Models.DTO;

public class MouseDTO
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public decimal Price { get; set; }
    public int Dpi { get; set; }
    public bool IsWireless { get; set; }
    public int NumberOfButtons { get; set; }
}
