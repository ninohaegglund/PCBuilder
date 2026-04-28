using PCBuilder.Services.IdentityAPI.Models;

namespace PCBuilder.Services.IdentityAPI.JWT;

public interface IJwtTokenGenerator
{
    string GenerateToken(IdentityUser user, IList<string> roles);
}
