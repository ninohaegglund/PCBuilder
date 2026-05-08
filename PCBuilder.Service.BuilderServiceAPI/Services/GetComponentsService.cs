using PCBuilder.Service.BuilderServiceAPI.Client;
using PCBuilder.Service.ComponentsAPI.Models;

namespace PCBuilder.Service.BuilderServiceAPI.Services;

public class GetComponentsService : IGetComponentsService
{
    private readonly ComponentsAPIClient _componentsClient;

    public GetComponentsService(ComponentsAPIClient componentsClient)
    {
        _componentsClient = componentsClient;
    }

    public async Task<List<Cpu>> GetCpusAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<Cpu>("api/components/cpus", ids);

    public async Task<List<VideoCard>> GetGpusAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<VideoCard>("api/components/videocards", ids);

    public async Task<List<MemoryKit>> GetRamsAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<MemoryKit>("api/components/memorykits", ids);

    public async Task<List<Motherboard>> GetMotherboardsAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<Motherboard>("api/components/motherboards", ids);

    public async Task<List<Case>> GetCasesAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<Case>("api/components/cases", ids);

    public async Task<List<PowerSupply>> GetPowerSuppliesAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<PowerSupply>("api/components/powersupplies", ids);

    public async Task<List<CpuCooler>> GetCpuCoolersAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<CpuCooler>("api/components/cpucoolers", ids);

    public async Task<List<CaseFan>> GetCaseFansAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<CaseFan>("api/components/casefans", ids);

    public async Task<List<InternalHardDrive>> GetInternalStoragesAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<InternalHardDrive>("api/components/internalharddrives", ids);

    public async Task<List<ExternalHardDrive>> GetExternalStoragesAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<ExternalHardDrive>("api/components/externalharddrives", ids);

    public async Task<List<ComponentsAPI.Models.Monitor>> GetMonitorsAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<ComponentsAPI.Models.Monitor>("api/components/monitors", ids);

    public async Task<List<Keyboard>> GetKeyboardsAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<Keyboard>("api/components/keyboards", ids);

    public async Task<List<Mouse>> GetMiceAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<Mouse>("api/components/mice", ids);

    public async Task<List<Headphones>> GetHeadphonesAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<Headphones>("api/components/headphones", ids);

    public async Task<List<Speakers>> GetSpeakersAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<Speakers>("api/components/speakers", ids);

    public async Task<List<Webcam>> GetWebcamsAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<Webcam>("api/components/webcams", ids);

    public async Task<List<FanController>> GetFanControllersAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<FanController>("api/components/fancontrollers", ids);

    public async Task<List<SoundCard>> GetSoundCardsAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<SoundCard>("api/components/soundcards", ids);

    public async Task<List<Ups>> GetUpsSystemsAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<Ups>("api/components/ups", ids);

    public async Task<List<ComponentsAPI.Models.OperatingSystem>> GetOperatingSystemsAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<ComponentsAPI.Models.OperatingSystem>("api/components/operatingsystems", ids);

    public async Task<List<CaseAccessory>> GetCaseAccessoriesAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<CaseAccessory>("api/components/caseaccessories", ids);
}
