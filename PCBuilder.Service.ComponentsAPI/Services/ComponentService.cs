using AutoMapper;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Service.ComponentsAPI.IRepositories;
using PCBuilder.Service.ComponentsAPI.Models;
using Monitor = PCBuilder.Service.ComponentsAPI.Models.Monitor;
using OperatingSystem = PCBuilder.Service.ComponentsAPI.Models.OperatingSystem;

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

        // Lookups
        public Task<List<Manufacturer>> GetAllManufacturersAsync() =>
            _repository.GetAllManufacturersAsync();

        public Task<List<Color>> GetAllColorsAsync() =>
            _repository.GetAllColorsAsync();

        public Task<List<FormFactor>> GetAllFormFactorsAsync() =>
            _repository.GetAllFormFactorsAsync();

        // Core components
        public Task<List<Cpu>> GetAllCPUsAsync() =>
            _repository.GetAllCPUsAsync();

        public Task<List<VideoCard>> GetAllGPUsAsync() =>
            _repository.GetAllGPUsAsync();

        public Task<List<MemoryKit>> GetAllRAMModulesAsync() =>
            _repository.GetAllRAMModulesAsync();

        public Task<List<Motherboard>> GetAllMotherboardsAsync() =>
            _repository.GetAllMotherboardsAsync();

        public Task<List<Case>> GetAllCasesAsync() =>
            _repository.GetAllCasesAsync();

        public Task<List<PowerSupply>> GetAllPSUsAsync() =>
            _repository.GetAllPSUsAsync();

        public Task<List<CpuCooler>> GetAllCPUCoolersAsync() =>
            _repository.GetAllCPUCoolersAsync();

        public Task<List<CaseFan>> GetAllChassiCoolersAsync() =>
            _repository.GetAllChassiCoolersAsync();

        // Storage
        public Task<List<InternalHardDrive>> GetAllInternalStorageDevicesAsync() =>
            _repository.GetAllInternalStorageDevicesAsync();

        public Task<List<ExternalHardDrive>> GetAllExternalStorageDevicesAsync() =>
            _repository.GetAllExternalStorageDevicesAsync();

        // Peripherals
        public Task<List<Monitor>> GetAllMonitorsAsync() =>
            _repository.GetAllMonitorsAsync();

        public Task<List<Mouse>> GetAllMiceAsync() =>
            _repository.GetAllMiceAsync();

        public Task<List<Keyboard>> GetAllKeyboardsAsync() =>
            _repository.GetAllKeyboardsAsync();

        public Task<List<Headphones>> GetAllHeadsetsAsync() =>
            _repository.GetAllHeadsetsAsync();

        public Task<List<Speakers>> GetAllSpeakersAsync() =>
            _repository.GetAllSpeakersAsync();

        public Task<List<Webcam>> GetAllWebcamsAsync() =>
            _repository.GetAllWebcamsAsync();

        // Other components
        public Task<List<FanController>> GetAllFanControllersAsync() =>
            _repository.GetAllFanControllersAsync();

        public Task<List<WirelessNetworkCard>> GetAllWirelessNetworkCardsAsync() =>
            _repository.GetAllWirelessNetworkCardsAsync();

        public Task<List<WiredNetworkCard>> GetAllWiredNetworkCardsAsync() =>
            _repository.GetAllWiredNetworkCardsAsync();

        public Task<List<SoundCard>> GetAllSoundCardsAsync() =>
            _repository.GetAllSoundCardsAsync();

        public Task<List<ThermalPaste>> GetAllThermalPastesAsync() =>
            _repository.GetAllThermalPastesAsync();

        public Task<List<Ups>> GetAllUpsSystemsAsync() =>
            _repository.GetAllUpsSystemsAsync();

        public Task<List<OpticalDrive>> GetAllOpticalDrivesAsync() =>
            _repository.GetAllOpticalDrivesAsync();

        public Task<List<OperatingSystem>> GetAllOperatingSystemsAsync() =>
            _repository.GetAllOperatingSystemsAsync();

        public Task<List<CaseAccessory>> GetAllCaseAccessoriesAsync() =>
            _repository.GetAllCaseAccessoriesAsync();
    }
}