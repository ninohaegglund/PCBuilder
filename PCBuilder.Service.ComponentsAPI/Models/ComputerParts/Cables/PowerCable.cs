namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cables;

public class PowerCable
{
    public int Id { get; set; }
    public string ConnectorType { get; set; } = null!;
    public int LengthCm { get; set; }
}