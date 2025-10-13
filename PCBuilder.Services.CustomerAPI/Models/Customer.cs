namespace PCBuilder.Services.CustomerAPI.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Review? Review { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
