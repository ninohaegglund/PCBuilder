namespace PCBuilder.Service.ComponentsAPI.Models;

public class Speaker
{
    public string name { get; set; } = null!;
    public decimal price { get; set; }
    public double configuration { get; set; }
    public double wattage { get; set; }
    public int[] frequency_response { get; set; }
    public string color { get; set; } = null!;
}
