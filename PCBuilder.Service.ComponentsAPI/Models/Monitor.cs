namespace PCBuilder.Service.ComponentsAPI.Models;

public class Monitor
{
    public string Name { get; set; } = null!;
    public double Price { get; set; }
    public int ScreenSize { get; set; }
    public int[] Resolution { get; set; } = null!;
    public int RefreshRate { get; set; }
    public int ResponseTime { get; set; }
    public string PanelType { get; set; } = null!;
    public string AspectRatio { get; set; } = null!;
}
