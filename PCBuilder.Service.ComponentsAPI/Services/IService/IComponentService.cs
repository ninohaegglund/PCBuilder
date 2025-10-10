using PCBuilder.Service.ComponentsAPI.Models.DTO;

namespace PCBuilder.Service.ComponentsAPI.Services.IService
{
    public interface IComponentService
    {
        Task<IEnumerable<ChassiDTO>> GetAllCasesAsync();
        Task<IEnumerable<ChassiCoolingDTO>> GetAllChassiCoolersAsync();
        Task<IEnumerable<CPUCoolingDTO>> GetAllCPUCoolersAsync();
        Task<IEnumerable<CPUDto>> GetAllCPUsAsync();
        Task<IEnumerable<GPUDto>> GetAllGPUsAsync();
        Task<IEnumerable<HeadsetDTO>> GetAllHeadsetsAsync();
        Task<IEnumerable<KeyboardDTO>> GetAllKeyboardsAsync();
        Task<IEnumerable<MouseDTO>> GetAllMiceAsync();
        Task<IEnumerable<MonitorDTO>> GetAllMonitorsAsync();
        Task<IEnumerable<MotherboardDTO>> GetAllMotherboardsAsync();
        Task<IEnumerable<PCIeCableDTO>> GetAllPCIeCablesAsync();
        Task<IEnumerable<PowerCableDTO>> GetAllPowerCablesAsync();
        Task<IEnumerable<PSUDTO>> GetAllPSUsAsync();
        Task<IEnumerable<RAMDTO>> GetAllRAMModulesAsync();
        Task<IEnumerable<SataCableDTO>> GetAllSataCablesAsync();
        Task<IEnumerable<SpeakerDTO>> GetAllSpeakersAsync();
        Task<IEnumerable<StorageDTO>> GetAllStorageDevicesAsync();
    }
}