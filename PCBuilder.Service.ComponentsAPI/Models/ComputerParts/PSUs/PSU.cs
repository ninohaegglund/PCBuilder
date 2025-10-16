using PCBuilder.Services.ComponentsAPI.Models.Components;
using ComponentParent = PCBuilder.Service.ComponentsAPI.Models.Components;

namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.PSUs;

public class PSU : ComponentParent
{
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int Wattage { get; set; }         
    public EfficiencyRating EfficiencyRating { get; set; }
    public int PowerConsumptionW { get; set; } 
}

public class ModularPSU : PSU
{
    public bool FullyModular { get; set; }
    public int NumberOfCables { get; set; } 
}

public class NonModularPSU : PSU
{
    public int FixedCables { get; set; } 
}
