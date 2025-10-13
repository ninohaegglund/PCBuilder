using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.BuilderServiceAPI.Data;
using PCBuilder.Service.BuilderServiceAPI.IRepository;
using PCBuilder.Service.BuilderServiceAPI.Models;

namespace PCBuilder.Service.BuilderServiceAPI.Repository;

public class ComputersRepository : IBuiltComputersRepository
{
    private readonly PcDataContext _context;
    public ComputersRepository(PcDataContext context)
    {
        _context = context;
    }

    public async Task<List<Computer>> GetAllAsync()
    {
        return await _context.Computers.ToListAsync();
    }

    public async Task<Computer?> GetByIdAsync(int id)
    {
        return await _context.Computers.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task AddAsync(Computer computer)
    {
        _context.Computers.Add(computer);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Computer computer)
    {
        _context.Computers.Update(computer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Computer computer)
    {
        _context.Computers.Remove(computer);
        await _context.SaveChangesAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _context.Computers.CountAsync();
    }
}