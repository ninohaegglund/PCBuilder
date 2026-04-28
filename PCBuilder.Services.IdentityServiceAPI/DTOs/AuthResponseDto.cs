namespace PCBuilder.Services.IdentityAPI.DTOs;

public class AuthResponseDto
{
    public string Token { get; set; } = null!;
    public DateTime ExpiresAt { get; set; }

    public UserDto User { get; set; } = null!;
}
