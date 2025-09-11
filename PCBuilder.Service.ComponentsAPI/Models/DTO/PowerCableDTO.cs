namespace PCBuilder.Service.ComponentsAPI.Models.DTO;
public class PowerCableDTO
{
    public int Id { get; set; }
    public string ConnectorType { get; set; } = null!;
    public int LengthCm { get; set; }
}
