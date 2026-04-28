using PCBuilder.Services.IdentityAPI.Models;

namespace PCBuilder.Services.IdentityAPI.Interfaces;
public interface IUserRepository
{
    Task<IdentityUser?> GetByEmailAsync(string email);
    Task<IdentityUser?> GetByIdAsync(Guid id);
    Task AddAsync(IdentityUser user);
    Task SaveChangesAsync();
}

