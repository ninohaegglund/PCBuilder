using AutoMapper;
using PCBuilder.Service.ComponentsAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.ComponentsAPI.Services.IService;

namespace PCBuilder.Service.ComponentsAPI.Services;

public class ComponentService : IComponentService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ComponentService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CPUDto>> GetAllCPUsAsync()
    {
        var cpus = await _context.CPUs.ToListAsync();
        return _mapper.Map<IEnumerable<CPUDto>>(cpus);
    }

    public async Task<IEnumerable<PSUDTO>> GetAllPSUsAsync()
    {
        var psus = await _context.PSUs.ToListAsync();
        return _mapper.Map<IEnumerable<PSUDTO>>(psus);
    }
}
