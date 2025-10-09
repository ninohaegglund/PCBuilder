using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.BuilderServiceAPI.Models;

namespace PCBuilder.Service.BuilderServiceAPI.Repository;

public class ComputerRepository
{
    public readonly DataContext _context;
    public ComputerRepository(DataContext context)
    {
        _context = context;
    }

    public async Task SaveComputerAsync(Computer computer)
    {
        _context.Computers.Add(computer);
        await _context.SaveChangesAsync();
    }

    public async Task SaveUpdatesAsync(Computer computer)
    {
        _context.Computers.Update(computer);
        await _context.SaveChangesAsync();
    }
}
