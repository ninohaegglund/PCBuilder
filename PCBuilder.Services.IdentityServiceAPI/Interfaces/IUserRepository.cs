using PCBuilder.Services.IdentityServiceAPI.Models;

namespace PCBuilder.Services.IdentityServiceAPI.Interfaces;
public interface IUserRepository
{
    Task<IdentityUser?> GetByEmailAsync(string email);
    Task<IdentityUser?> GetByIdAsync(Guid id);
    Task AddAsync(IdentityUser user);
    Task SaveChangesAsync();
}

