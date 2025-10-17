namespace PCBuilder.Service.ComponentsAPI.Models.DTO;

public class ComponentDTO
{
    public int Id { get; set; }
    public string Type { get; set; } = null!;
    public object Data { get; set; } = null!; 
}
