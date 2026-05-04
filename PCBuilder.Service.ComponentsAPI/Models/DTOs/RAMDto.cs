namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;

public class RAMDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; set; } = null!;
    public int? CapacityPerModuleGB { get; set; } 

    public int TotalCapacityGB { get; set; }
    public int ModulesCount { get; set; }
    public int SpeedMTs { get; set; }
    public int? CasLatency { get; set; }
    public decimal? Price { get; set; }
}