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

    public async Task<IEnumerable<MotherboardDTO>> GetAllMotherboardsAsync()
    {
        var motherboards = await _context.Motherboards.ToListAsync();
        return _mapper.Map<IEnumerable<MotherboardDTO>>(motherboards);
    }

    public async Task<IEnumerable<ChassiDTO>> GetAllCasesAsync()
    {
        var cases = await _context.Cases.ToListAsync();
        return _mapper.Map<IEnumerable<ChassiDTO>>(cases);
    }

    public async Task<IEnumerable<KeyboardDTO>> GetAllKeyboardsAsync()
    {
        var keyboards = await _context.Keyboards.ToListAsync();
        return _mapper.Map<IEnumerable<KeyboardDTO>>(keyboards);
    }

    public async Task<IEnumerable<MouseDTO>> GetAllMiceAsync()
    {
        var mice = await _context.Mice.ToListAsync();
        return _mapper.Map<IEnumerable<MouseDTO>>(mice);
    }

    public async Task<IEnumerable<HeadsetDTO>> GetAllHeadsetsAsync()
    {
        var headsets = await _context.Headsets.ToListAsync();
        return _mapper.Map<IEnumerable<HeadsetDTO>>(headsets);
    }

    public async Task<IEnumerable<GPUDto>> GetAllGPUsAsync()
    {
        var gpus = await _context.GPUs.ToListAsync();
        return _mapper.Map<IEnumerable<GPUDto>>(gpus);
    }

    public async Task<IEnumerable<RAMDTO>> GetAllRAMModulesAsync()
    {
        var ramModules = await _context.RAMModules.ToListAsync();
        return _mapper.Map<IEnumerable<RAMDTO>>(ramModules);
    }

    public async Task<IEnumerable<StorageDTO>> GetAllStorageDevicesAsync()
    {
        var storages = await _context.Storages.ToListAsync();
        return _mapper.Map<IEnumerable<StorageDTO>>(storages);
    }

    public async Task<IEnumerable<CPUCoolingDTO>> GetAllCPUCoolersAsync()
    {
        var cpuCoolers = await _context.CPUCoolers.ToListAsync();
        return _mapper.Map<IEnumerable<CPUCoolingDTO>>(cpuCoolers);
    }

    public async Task<IEnumerable<ChassiCoolingDTO>> GetAllChassiCoolersAsync()
    {
        var chassiCoolers = await _context.ChassiCooling.ToListAsync();
        return _mapper.Map<IEnumerable<ChassiCoolingDTO>>(chassiCoolers);
    }

    public async Task<IEnumerable<PCIeCableDTO>> GetAllPCIeCablesAsync()
    {
        var pcieCables = await _context.PCIeCables.ToListAsync();
        return _mapper.Map<IEnumerable<PCIeCableDTO>>(pcieCables);
    }

    public async Task<IEnumerable<PowerCableDTO>> GetAllPowerCablesAsync()
    {
        var powerCables = await _context.PowerCables.ToListAsync();
        return _mapper.Map<IEnumerable<PowerCableDTO>>(powerCables);
    }

    public async Task<IEnumerable<SataCableDTO>> GetAllSataCablesAsync()
    {
        var sataCables = await _context.SataCables.ToListAsync();
        return _mapper.Map<IEnumerable<SataCableDTO>>(sataCables);
    }

    public async Task<IEnumerable<MonitorDTO>> GetAllMonitorsAsync()
    {
        var monitors = await _context.Monitors.ToListAsync();
        return _mapper.Map<IEnumerable<MonitorDTO>>(monitors);
    }

    public async Task<IEnumerable<SpeakerDTO>> GetAllSpeakersAsync()
    {
        var speakers = await _context.Speakers.ToListAsync();
        return _mapper.Map<IEnumerable<SpeakerDTO>>(speakers);
    }

}
