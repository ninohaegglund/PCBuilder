namespace PCBuilder.Service.ComponentsAPI.Models;

public class Motherboard
{
    public string name { get; set; } = null!;
    public decimal price { get; set; }
    public string socket { get; set; } = null!;
    public string form_factor { get; set; } = null!;
    public int max_memory { get; set; }
    public int memory_slots { get; set; }
    public string color { get; set; } = null!;
}
