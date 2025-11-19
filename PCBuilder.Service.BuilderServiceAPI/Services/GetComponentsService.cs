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
        => await _componentsClient.GetByIdsAsync<Cpu>("api/Component/GetComponents", ids);

    public async Task<List<VideoCard>> GetGpusAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<VideoCard>("api/Component/GetComponents", ids);

    public async Task<List<MemoryKit>> GetRamsAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<MemoryKit>("api/Component/GetComponents", ids);

    public async Task<List<Motherboard>> GetMotherboardsAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<Motherboard>("api/Component/GetComponents", ids);

    public async Task<List<Case>> GetCasesAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<Case>("api/Component/GetComponents", ids);

    public async Task<List<PowerSupply>> GetPowerSuppliesAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<PowerSupply>("api/Component/GetComponents", ids);

    public async Task<List<CpuCooler>> GetCpuCoolersAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<CpuCooler>("api/Component/GetComponents", ids);

    public async Task<List<CaseFan>> GetCaseFansAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<CaseFan>("api/Component/GetComponents", ids);

    public async Task<List<InternalHardDrive>> GetInternalStoragesAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<InternalHardDrive>("api/Component/GetComponents", ids);

    public async Task<List<ExternalHardDrive>> GetExternalStoragesAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<ExternalHardDrive>("api/Component/GetComponents", ids);

    public async Task<List<ComponentsAPI.Models.Monitor>> GetMonitorsAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<ComponentsAPI.Models.Monitor>("api/Component/GetComponents", ids);

    public async Task<List<Keyboard>> GetKeyboardsAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<Keyboard>("api/Component/GetComponents", ids);

    public async Task<List<Mouse>> GetMiceAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<Mouse>("api/Component/GetComponents", ids);

    public async Task<List<Headphones>> GetHeadphonesAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<Headphones>("api/Component/GetComponents", ids);

    public async Task<List<Speakers>> GetSpeakersAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<Speakers>("api/Component/GetComponents", ids);

    public async Task<List<Webcam>> GetWebcamsAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<Webcam>("api/Component/GetComponents", ids);

    public async Task<List<FanController>> GetFanControllersAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<FanController>("api/Component/GetComponents", ids);

    public async Task<List<SoundCard>> GetSoundCardsAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<SoundCard>("api/Component/GetComponents", ids);

    public async Task<List<Ups>> GetUpsSystemsAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<Ups>("api/Component/GetComponents", ids);

    public async Task<List<ComponentsAPI.Models.OperatingSystem>> GetOperatingSystemsAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<ComponentsAPI.Models.OperatingSystem>("api/Component/GetComponents", ids);

    public async Task<List<CaseAccessory>> GetCaseAccessoriesAsync(IEnumerable<int> ids)
        => await _componentsClient.GetByIdsAsync<CaseAccessory>("api/Component/GetComponents", ids);
}