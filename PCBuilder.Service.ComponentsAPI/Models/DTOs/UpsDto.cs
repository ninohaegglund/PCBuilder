namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;
public class UpsDto
{
    public int Id { get; set; }
    public int ManufacturerId { get; set; }
    public string ManufacturerName { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int? CapacityWatts { get; set; }
    public int? CapacityVa { get; set; }
    public decimal? Price { get; set; }
}
