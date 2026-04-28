namespace PCBuilder.Services.CustomerAPI.Models;

public class User
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public decimal Balance { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}