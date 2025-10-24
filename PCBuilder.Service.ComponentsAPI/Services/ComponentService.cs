using AutoMapper;
using PCBuilder.Service.ComponentsAPI.Interfaces;
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

namespace PCBuilder.Service.ComponentsAPI.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IComponentRepository _repository;
        private readonly IMapper _mapper;

        public ComponentService(IComponentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<CPU>> GetAllCPUsAsync() => await _repository.GetAllCPUsAsync();
        public async Task<List<PSU>> GetAllPSUsAsync() => await _repository.GetAllPSUsAsync();
        public async Task<List<Motherboard>> GetAllMotherboardsAsync() => await _repository.GetAllMotherboardsAsync();
        public async Task<List<Chassi>> GetAllCasesAsync() => await _repository.GetAllCasesAsync();
        public async Task<List<Keyboard>> GetAllKeyboardsAsync() => await _repository.GetAllKeyboardsAsync();
        public async Task<List<Mouse>> GetAllMiceAsync() => await _repository.GetAllMiceAsync();
        public async Task<List<Headset>> GetAllHeadsetsAsync() => await _repository.GetAllHeadsetsAsync();
        public async Task<List<GPU>> GetAllGPUsAsync() => await _repository.GetAllGPUsAsync();
        public async Task<List<RAM>> GetAllRAMModulesAsync() => await _repository.GetAllRAMModulesAsync();
        public async Task<List<StorageDevice>> GetAllStorageDevicesAsync() => await _repository.GetAllStorageDevicesAsync();
        public async Task<List<CPUCooling>> GetAllCPUCoolersAsync() => await _repository.GetAllCPUCoolersAsync();
        public async Task<List<ChassiCooling>> GetAllChassiCoolersAsync() => await _repository.GetAllChassiCoolersAsync();
        public async Task<List<DisplayMonitor>> GetAllMonitorsAsync() => await _repository.GetAllMonitorsAsync();
        public async Task<List<Speaker>> GetAllSpeakersAsync() => await _repository.GetAllSpeakersAsync();

        public async Task<List<Components>> GetComponentsAsync(IEnumerable<int> ids)
        {
            if (ids == null || !ids.Any())
                return new List<Components>();
            var components = await _repository.GetComponentsAsync(ids);
            if (components == null || !components.Any())
                return new List<Components>();
            return components.ToList();
        }
    }
}