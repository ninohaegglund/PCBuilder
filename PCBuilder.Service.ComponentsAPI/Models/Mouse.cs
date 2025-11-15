namespace PCBuilder.Service.ComponentsAPI.Models;

public class Mouse
{
    public string name { get; set; } = null!;
    public decimal? price { get; set; }
    public string tracking_method { get; set; } = null!;
    public string connection_type { get; set; } = null!;
    public int? max_dpi { get; set; }
    public string hand_orientation { get; set; } = null!;
    public string color { get; set; } = null!;
}
