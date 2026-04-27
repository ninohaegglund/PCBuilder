using PCBuilder.Services.IdentityServiceAPI.Models;

namespace PCBuilder.Services.IdentityServiceAPI.JWT;

public interface IJwtTokenGenerator
{
    string GenerateToken(IdentityUser user, IList<string> roles);
}
