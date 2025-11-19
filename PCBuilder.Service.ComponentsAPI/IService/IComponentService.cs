using PCBuilder.Service.ComponentsAPI.Models;
using Monitor = PCBuilder.Service.ComponentsAPI.Models.Monitor;
using OperatingSystem = PCBuilder.Service.ComponentsAPI.Models.OperatingSystem;

namespace PCBuilder.Service.ComponentsAPI.Interfaces
{
    public interface IComponentService
    {
        // Lookups
        Task<List<Manufacturer>> GetAllManufacturersAsync();
        Task<List<Color>> GetAllColorsAsync();
        Task<List<FormFactor>> GetAllFormFactorsAsync();

        // Core components
        Task<List<Cpu>> GetAllCPUsAsync();
        Task<List<VideoCard>> GetAllGPUsAsync();
        Task<List<MemoryKit>> GetAllRAMModulesAsync();
        Task<List<Motherboard>> GetAllMotherboardsAsync();
        Task<List<Case>> GetAllCasesAsync();
        Task<List<PowerSupply>> GetAllPSUsAsync();
        Task<List<CpuCooler>> GetAllCPUCoolersAsync();
        Task<List<CaseFan>> GetAllChassiCoolersAsync();

        // Storage
        Task<List<InternalHardDrive>> GetAllInternalStorageDevicesAsync();
        Task<List<ExternalHardDrive>> GetAllExternalStorageDevicesAsync();

        // Peripherals
        Task<List<Monitor>> GetAllMonitorsAsync();
        Task<List<Mouse>> GetAllMiceAsync();
        Task<List<Keyboard>> GetAllKeyboardsAsync();
        Task<List<Headphones>> GetAllHeadsetsAsync();
        Task<List<Speakers>> GetAllSpeakersAsync();
        Task<List<Webcam>> GetAllWebcamsAsync();

        // Other components
        Task<List<FanController>> GetAllFanControllersAsync();
        Task<List<WirelessNetworkCard>> GetAllWirelessNetworkCardsAsync();
        Task<List<WiredNetworkCard>> GetAllWiredNetworkCardsAsync();
        Task<List<SoundCard>> GetAllSoundCardsAsync();
        Task<List<ThermalPaste>> GetAllThermalPastesAsync();
        Task<List<Ups>> GetAllUpsSystemsAsync();
        Task<List<OpticalDrive>> GetAllOpticalDrivesAsync();
        Task<List<OperatingSystem>> GetAllOperatingSystemsAsync();
        Task<List<CaseAccessory>> GetAllCaseAccessoriesAsync();
    }
}