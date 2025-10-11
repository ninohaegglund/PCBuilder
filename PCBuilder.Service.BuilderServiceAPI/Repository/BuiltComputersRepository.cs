using PCBuilder.Service.BuilderServiceAPI.Data;
using PCBuilder.Service.BuilderServiceAPI.Models;

namespace PCBuilder.Service.BuilderServiceAPI.Repository;

public class BuiltComputersRepository
{
    public readonly PcDataContext _context;
    public BuiltComputersRepository(PcDataContext context)
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
