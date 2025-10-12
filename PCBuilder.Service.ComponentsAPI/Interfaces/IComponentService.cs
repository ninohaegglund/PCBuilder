using PCBuilder.Service.ComponentsAPI.Models.DTO;

namespace PCBuilder.Service.ComponentsAPI.Interfaces
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
        Task<IEnumerable<PSUDTO>> GetAllPSUsAsync();
        Task<IEnumerable<RAMDTO>> GetAllRAMModulesAsync();
        Task<IEnumerable<SpeakerDTO>> GetAllSpeakersAsync();
        Task<IEnumerable<StorageDTO>> GetAllStorageDevicesAsync();
    }
}