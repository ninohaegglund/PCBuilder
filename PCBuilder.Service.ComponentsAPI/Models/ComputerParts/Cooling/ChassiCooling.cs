using ComponentParent = PCBuilder.Service.ComponentsAPI.Models.Components;

namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cooling;

public class ChassiCooling : ComponentParent
{
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int? ComputerId { get; set; }
    public int FanSizeMm { get; set; }  
    public int Rpm { get; set; }         

    public int CoolingCapacityW { get; set; }  
}
