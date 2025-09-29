using PCBuilder.Services.ComponentsAPI.Models.Components;

namespace PCBuilder.Service.ComponentsAPI.Models.ComputerParts.Cooling;


// / Many-to-many relationship entity between CPUCooling and CPUSocket
public class CoolerSocketCompatibility
{
    public int Id { get; set; }         
    public CPUSocket Socket { get; set; } 

    public int CPUCoolingId { get; set; }
    public CPUCooling CPUCooling { get; set; } = null!;
}
