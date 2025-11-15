namespace PCBuilder.Service.ComponentsAPI.Models;

public class Keyboard
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Style { get; set; }
    public string? Switches { get; set; }
    public string Backlit { get; set; }
    public bool Tenkeyless { get; set; }
    public string Connection_Type { get; set; }
    public string Color { get; set; }
}
