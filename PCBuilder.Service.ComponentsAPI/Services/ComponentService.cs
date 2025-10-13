using AutoMapper;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Service.ComponentsAPI.IRepositories;
using PCBuilder.Service.ComponentsAPI.Models.DTO;
using PCBuilder.Service.ComponentsAPI.Repositories;

namespace PCBuilder.Service.ComponentsAPI.Services;

public class ComponentService : IComponentService
{
    private readonly IComponentRepository _repository;
    private readonly IMapper _mapper;

    public ComponentService(IComponentRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CPUDto>> GetAllCPUsAsync()
    {
        var cpus = await _repository.GetAllCPUsAsync();
        return _mapper.Map<IEnumerable<CPUDto>>(cpus);
    }

    public async Task<IEnumerable<PSUDTO>> GetAllPSUsAsync()
    {
        var psus = await _repository.GetAllPSUsAsync();
        return _mapper.Map<IEnumerable<PSUDTO>>(psus);
    }

    public async Task<IEnumerable<MotherboardDTO>> GetAllMotherboardsAsync()
    {
        var motherboards = await _repository.GetAllMotherboardsAsync();
        return _mapper.Map<IEnumerable<MotherboardDTO>>(motherboards);
    }

    public async Task<IEnumerable<ChassiDTO>> GetAllCasesAsync()
    {
        var cases = await _repository.GetAllCasesAsync();
        return _mapper.Map<IEnumerable<ChassiDTO>>(cases);
    }

    public async Task<IEnumerable<KeyboardDTO>> GetAllKeyboardsAsync()
    {
        var keyboards = await _repository.GetAllKeyboardsAsync();
        return _mapper.Map<IEnumerable<KeyboardDTO>>(keyboards);
    }

    public async Task<IEnumerable<MouseDTO>> GetAllMiceAsync()
    {
        var mice = await _repository.GetAllMiceAsync();
        return _mapper.Map<IEnumerable<MouseDTO>>(mice);
    }

    public async Task<IEnumerable<HeadsetDTO>> GetAllHeadsetsAsync()
    {
        var headsets = await _repository.GetAllHeadsetsAsync();
        return _mapper.Map<IEnumerable<HeadsetDTO>>(headsets);
    }

    public async Task<IEnumerable<GPUDto>> GetAllGPUsAsync()
    {
        var gpus = await _repository.GetAllGPUsAsync();
        return _mapper.Map<IEnumerable<GPUDto>>(gpus);
    }

    public async Task<IEnumerable<RAMDTO>> GetAllRAMModulesAsync()
    {
        var ramModules = await _repository.GetAllRAMModulesAsync();
        return _mapper.Map<IEnumerable<RAMDTO>>(ramModules);
    }

    public async Task<IEnumerable<StorageDTO>> GetAllStorageDevicesAsync()
    {
        var storages = await _repository.GetAllStorageDevicesAsync();
        return _mapper.Map<IEnumerable<StorageDTO>>(storages);
    }

    public async Task<IEnumerable<CPUCoolingDTO>> GetAllCPUCoolersAsync()
    {
        var cpuCoolers = await _repository.GetAllCPUCoolersAsync();
        return _mapper.Map<IEnumerable<CPUCoolingDTO>>(cpuCoolers);
    }

    public async Task<IEnumerable<ChassiCoolingDTO>> GetAllChassiCoolersAsync()
    {
        var chassiCoolers = await _repository.GetAllChassiCoolersAsync();
        return _mapper.Map<IEnumerable<ChassiCoolingDTO>>(chassiCoolers);
    }

    public async Task<IEnumerable<MonitorDTO>> GetAllMonitorsAsync()
    {
        var monitors = await _repository.GetAllMonitorsAsync();
        return _mapper.Map<IEnumerable<MonitorDTO>>(monitors);
    }

    public async Task<IEnumerable<SpeakerDTO>> GetAllSpeakersAsync()
    {
        var speakers = await _repository.GetAllSpeakersAsync();
        return _mapper.Map<IEnumerable<SpeakerDTO>>(speakers);
    }
}