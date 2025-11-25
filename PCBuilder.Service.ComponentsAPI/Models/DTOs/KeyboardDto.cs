namespace PCBuilder.Service.ComponentsAPI.Models.DTOs;

public class KeyboardDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Style { get; set; }
    public string? Switches { get; set; }
    public string? Backlit { get; set; }
    public bool Tenkeyless { get; set; }
    public string? Connection { get; set; }
    public string? Color { get; set; }
    public decimal? Price { get; set; }
}