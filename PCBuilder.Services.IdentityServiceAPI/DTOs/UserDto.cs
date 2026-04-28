namespace PCBuilder.Services.IdentityAPI.DTOs;

public class UserDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public decimal Balance { get; set; }

    public List<string> Roles { get; set; } = new();
}
