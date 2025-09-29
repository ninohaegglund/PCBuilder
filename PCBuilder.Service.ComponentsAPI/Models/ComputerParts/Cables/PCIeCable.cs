namespace PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cables.PCIe;

public class PCIeCable
{
    public int Id { get; set; }
    public int? ComputerId { get; set; }
    public Computer? Computer { get; set; }


    public string ConnectorType { get; set; } = null!;
    public int LengthCm { get; set; }
}
