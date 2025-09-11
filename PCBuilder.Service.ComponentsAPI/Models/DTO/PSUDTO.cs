using PCBuilder.Services.ComponentsAPI.Models.Components;

namespace PCBuilder.Service.ComponentsAPI.Models.DTO;

public class PSUDTO
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;
    public int Wattage { get; set; }
    public EfficiencyRating EfficiencyRating { get; set; }
    public int PowerConsumptionW { get; set; }
}

public class ModularPSU : PSUDTO
{
    public bool FullyModular { get; set; }
    public int NumberOfCables { get; set; }
}

public class NonModularPSU : PSUDTO
{
    public int FixedCables { get; set; }
}
