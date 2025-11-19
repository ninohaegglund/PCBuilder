using PCBuilder.Service.ComponentsAPI.Models;

public interface IGetComponentsService
{
    Task<List<Cpu>> GetCpusAsync(IEnumerable<int> ids);
    Task<List<VideoCard>> GetGpusAsync(IEnumerable<int> ids);
    Task<List<MemoryKit>> GetRamsAsync(IEnumerable<int> ids);
    Task<List<Motherboard>> GetMotherboardsAsync(IEnumerable<int> ids);
    Task<List<Case>> GetCasesAsync(IEnumerable<int> ids);
    Task<List<PowerSupply>> GetPowerSuppliesAsync(IEnumerable<int> ids);
    Task<List<CpuCooler>> GetCpuCoolersAsync(IEnumerable<int> ids);
    Task<List<CaseFan>> GetCaseFansAsync(IEnumerable<int> ids);
    Task<List<InternalHardDrive>> GetInternalStoragesAsync(IEnumerable<int> ids);
    Task<List<ExternalHardDrive>> GetExternalStoragesAsync(IEnumerable<int> ids);
    Task<List<PCBuilder.Service.ComponentsAPI.Models.Monitor>> GetMonitorsAsync(IEnumerable<int> ids);
    Task<List<Keyboard>> GetKeyboardsAsync(IEnumerable<int> ids);
    Task<List<Mouse>> GetMiceAsync(IEnumerable<int> ids);
    Task<List<Headphones>> GetHeadphonesAsync(IEnumerable<int> ids);
    Task<List<Speakers>> GetSpeakersAsync(IEnumerable<int> ids);
    Task<List<Webcam>> GetWebcamsAsync(IEnumerable<int> ids);
    Task<List<FanController>> GetFanControllersAsync(IEnumerable<int> ids);
    Task<List<SoundCard>> GetSoundCardsAsync(IEnumerable<int> ids);
    Task<List<Ups>> GetUpsSystemsAsync(IEnumerable<int> ids);
    Task<List<PCBuilder.Service.ComponentsAPI.Models.OperatingSystem>> GetOperatingSystemsAsync(IEnumerable<int> ids);
    Task<List<CaseAccessory>> GetCaseAccessoriesAsync(IEnumerable<int> ids);
}