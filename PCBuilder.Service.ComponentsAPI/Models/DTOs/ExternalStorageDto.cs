namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;

public class ExternalStorageDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Type { get; set; }
    public string? Interface { get; set; }
    public long CapacityGB { get; set; }
    public decimal? PricePerGB { get; set; }
    public string? Color { get; set; }
    public decimal? Price { get; set; }
}