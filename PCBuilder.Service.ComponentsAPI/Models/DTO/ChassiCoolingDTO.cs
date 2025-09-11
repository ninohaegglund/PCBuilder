namespace PCBuilder.Service.ComponentsAPI.Models.DTO;

public class ChassiCoolingDTO
{
    public int Id { get; set; }
    public string ModelName { get; set; } = null!;
    public string Manufacturer { get; set; } = null!;

    public int FanSizeMm { get; set; }
    public int Rpm { get; set; }

    public int CoolingCapacityW { get; set; }
}
