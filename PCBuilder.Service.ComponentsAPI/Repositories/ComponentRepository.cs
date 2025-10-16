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
using System.ComponentModel;

namespace PCBuilder.Service.ComponentsAPI.Repositories;

public class ComponentRepository : IComponentRepository
{
    private readonly DataContext _context;

    public ComponentRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<List<CPU>> GetAllCPUsAsync() => await _context.CPUs.ToListAsync();
    public async Task<List<PSU>> GetAllPSUsAsync() => await _context.PSUs.ToListAsync();
    public async Task<List<Motherboard>> GetAllMotherboardsAsync() => await _context.Motherboards.ToListAsync();
    public async Task<List<Chassi>> GetAllCasesAsync() => await _context.Cases.ToListAsync();
    public async Task<List<Keyboard>> GetAllKeyboardsAsync() => await _context.Keyboards.ToListAsync();
    public async Task<List<Mouse>> GetAllMiceAsync() => await _context.Mice.ToListAsync();
    public async Task<List<Headset>> GetAllHeadsetsAsync() => await _context.Headsets.ToListAsync();
    public async Task<List<GPU>> GetAllGPUsAsync() => await _context.GPUs.ToListAsync();
    public async Task<List<RAM>> GetAllRAMModulesAsync() => await _context.RAMModules.ToListAsync();
    public async Task<List<StorageDevice>> GetAllStorageDevicesAsync() => await _context.Storages.ToListAsync();
    public async Task<List<CPUCooling>> GetAllCPUCoolersAsync() => await _context.CPUCoolers.ToListAsync();
    public async Task<List<ChassiCooling>> GetAllChassiCoolersAsync() => await _context.ChassiCooling.ToListAsync();
    public async Task<List<DisplayMonitor>> GetAllMonitorsAsync() => await _context.Monitors.ToListAsync();
    public async Task<List<Speaker>> GetAllSpeakersAsync() => await _context.Speakers.ToListAsync();
    public async Task<List<Components>> GetComponentsAsync(int id) => await _context.Components.ToListAsync();
}