using PCBuilder.Services.IdentityServiceAPI.DTOs;

namespace PCBuilder.Services.IdentityServiceAPI.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request);
    Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
    Task<CurrentUserResponseDto> GetCurrentUserAsync(string userId);
}
