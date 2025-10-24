using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.ComponentsAPI.IRepositories;
using PCBuilder.Service.ComponentsAPI.Models;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Chassi;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cooling;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Headsets;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Keyboards;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Mice;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Speakers;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Motherboards;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.PSUs;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.RAM;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.StorageDevice;

namespace PCBuilder.Service.ComponentsAPI.Repositories
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly DataContext _context;

        public ComponentRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<CPU>> GetAllCPUsAsync() => await _context.CPUs.AsNoTracking().ToListAsync();
        public async Task<List<PSU>> GetAllPSUsAsync() => await _context.PSUs.AsNoTracking().ToListAsync();
        public async Task<List<Motherboard>> GetAllMotherboardsAsync() => await _context.Motherboards.AsNoTracking().ToListAsync();
        public async Task<List<Chassi>> GetAllCasesAsync() => await _context.Cases.AsNoTracking().ToListAsync();
        public async Task<List<Keyboard>> GetAllKeyboardsAsync() => await _context.Keyboards.AsNoTracking().ToListAsync();
        public async Task<List<Mouse>> GetAllMiceAsync() => await _context.Mice.AsNoTracking().ToListAsync();
        public async Task<List<Headset>> GetAllHeadsetsAsync() => await _context.Headsets.AsNoTracking().ToListAsync();
        public async Task<List<GPU>> GetAllGPUsAsync() => await _context.GPUs.AsNoTracking().ToListAsync();
        public async Task<List<RAM>> GetAllRAMModulesAsync() => await _context.RAMModules.AsNoTracking().ToListAsync();
        public async Task<List<StorageDevice>> GetAllStorageDevicesAsync() => await _context.Storages.AsNoTracking().ToListAsync();
        public async Task<List<CPUCooling>> GetAllCPUCoolersAsync() => await _context.CPUCoolers.AsNoTracking().ToListAsync();
        public async Task<List<ChassiCooling>> GetAllChassiCoolersAsync() => await _context.ChassiCooling.AsNoTracking().ToListAsync();
        public async Task<List<DisplayMonitor>> GetAllMonitorsAsync() => await _context.Monitors.AsNoTracking().ToListAsync();
        public async Task<List<Speaker>> GetAllSpeakersAsync() => await _context.Speakers.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Components>> GetComponentsAsync(IEnumerable<int> ids)
        {
            if (ids == null)
                return new List<Components>();

            var idList = ids as IList<int> ?? ids.ToList();
            if (!idList.Any())
                return new List<Components>();

           var components = await _context.Components
                .AsNoTracking()
                .Where(c => idList.Contains(c.Id))
                .ToListAsync();

            return components;
        }
    }
}