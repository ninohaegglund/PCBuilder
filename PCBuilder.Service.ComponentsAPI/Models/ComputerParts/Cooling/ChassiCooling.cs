namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cooling;

public class ChassiCooling
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public int? ComputerId { get; set; }
    public int FanSizeMm { get; set; }  
    public int Rpm { get; set; }         

    public int CoolingCapacityW { get; set; }  
}
