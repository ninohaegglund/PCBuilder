namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;

public class InternalStorageDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public long CapacityGB { get; set; }
    public string Type { get; set; } = null!;
    public string? FormFactor { get; set; }
    public string? Interface { get; set; }
    public int? CacheMB { get; set; }
    public decimal? Price { get; set; }
    public decimal? PricePerGB { get; set; }
}