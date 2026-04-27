namespace PCBuilder.Services.IdentityServiceAPI.DTOs;

public class LoginRequestDto
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
