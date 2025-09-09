namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Chassi;

public class Chassi
{
    public int Id { get; set; }
    public string Brand { get; set; } = null!;
    public string ModelName { get; set; } = null!;
    public string Material { get; set; } = null!;
    public int MaxGpuLengthMm { get; set; }
}
