namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;

public class CPUDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Manufacturer { get; set; }
    public int? CoreCount { get; set; }
    public decimal? CoreClock { get; set; }
    public decimal? BoostClock { get; set; }
    public string? Microarchitecture { get; set; }
    public int? Tdp { get; set; }
    public string? IntegratedGraphics { get; set; }
    public decimal? Price { get; set; }
}