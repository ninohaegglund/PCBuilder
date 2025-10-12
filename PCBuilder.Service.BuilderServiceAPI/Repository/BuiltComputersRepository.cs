using PCBuilder.Service.BuilderServiceAPI.Data;
using PCBuilder.Service.BuilderServiceAPI.Models;
using PCBuilder.Service.BuilderServiceAPI.Repository.IRepository;

namespace PCBuilder.Service.BuilderServiceAPI.Repository;

public class BuiltComputersRepository : IBuiltComputersRepository
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
