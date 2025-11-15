namespace PCBuilder.Service.ComponentsAPI.Models;

public class OpticalDrive
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int? Bd { get; set; }
    public int? Dvd { get; set; }
    public int? Cd { get; set; }
    public string BdWrite { get; set; }
    public string DvdWrite { get; set; }
    public string CdWrite { get; set; }
}
