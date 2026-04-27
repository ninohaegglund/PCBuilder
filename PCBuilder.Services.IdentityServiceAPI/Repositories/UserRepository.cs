
using PCBuilder.Services.IdentityServiceAPI.Interfaces;
using PCBuilder.Services.IdentityServiceAPI.Models;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Services.IdentityServiceAPI.Data;

namespace PCBuilder.Services.IdentityServiceAPI.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IdentityDbContext _context;

    public UserRepository(IdentityDbContext context)
    {
        _context = context;
    }

    public async Task<IdentityUser?> GetByEmailAsync(string email)
    {
        return await _context.IdentityUsers
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<IdentityUser?> GetByIdAsync(Guid id)
    {
        return await _context.IdentityUsers
            .Include(u => u.UserRoles)
            .ThenInclude(ur => ur.Role)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task AddAsync(IdentityUser user)
    {
        await _context.IdentityUsers.AddAsync(user);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
