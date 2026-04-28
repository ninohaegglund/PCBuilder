using PCBuilder.Services.IdentityAPI.DTOs;

namespace PCBuilder.Services.IdentityAPI.Interfaces;

public interface IAuthService
{
    Task<AuthResponseDto> RegisterAsync(RegisterRequestDto request);
    Task<AuthResponseDto> LoginAsync(LoginRequestDto request);
    Task<CurrentUserResponseDto> GetCurrentUserAsync(string userId);
}
