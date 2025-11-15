namespace PCBuilder.Service.ComponentsAPI.Models;

public class Cpu
{
    public string? name { get; set; } = null;
    public decimal? price { get; set; }
    public int? core_count { get; set; }
    public double? core_clock { get; set; }
    public double? boost_clock { get; set; }
    public string? microarchitecture { get; set; } = null;
    public int? tdp { get; set; }
    public string? graphics { get; set; } = null;
}
