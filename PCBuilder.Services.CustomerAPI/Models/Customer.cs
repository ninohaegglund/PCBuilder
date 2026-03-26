namespace PCBuilder.Services.CustomerAPI.Models;

public class Customer
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}
