using PCBuilder.Service.BuilderServiceAPI.Client;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCPartsDatabase.Models;
using System.ComponentModel;

namespace PCBuilder.Service.BuilderServiceAPI.Services;

public class GetComponentsService : IGetComponentsService
{
    public readonly ComponentsAPIClient _componentsClient;

    public GetComponentsService(ComponentsAPIClient componentsClient)
    {
        _componentsClient = componentsClient;
    }

    public async Task<List<Component>> GetComponentsAsync<T>(IEnumerable<int> ids) where T : Component =>
        await _componentsClient.GetByIdsAsync<Component>("api/Component/GetComponents", ids);

    public async Task<List<VideoCard>> GetGpusAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<VideoCard>("api/Component/GetComponents", ids);

    public async Task<List<Ram>> GetRamsAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<RAM>("api/Component/GetComponents", ids);

    public async Task<List<StorageDevice>> GetStoragesAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<StorageDevice>("api/Component/GetComponents", ids);

    public async Task<List<ChassiCooling>> GetCaseFansAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<ChassiCooling>("api/Component/GetComponents", ids);

    public async Task<List<DisplayMonitor>> GetMonitorsAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<DisplayMonitor>("api/Component/GetComponents", ids);

    public async Task<List<Speaker>> GetSpeakersAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<Speaker>("api/Component/GetComponents", ids);


    public async Task<List<CPU>> GetCpusAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<CPU>("api/Component/GetComponents", ids);

    public async Task<List<PSU>> GetPsusAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<PSU>("api/Component/GetComponents", ids);

    public async Task<List<Motherboard>> GetMotherboardsAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<Motherboard>("api/Component/GetComponents", ids);

    public async Task<List<Chassi>> GetCasesAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<Chassi>("api/Component/GetComponents", ids);

    public async Task<List<CPUCooling>> GetCpuCoolersAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<CPUCooling>("api/Component/GetComponents", ids);

    public async Task<List<Keyboard>> GetKeyboardsAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<Keyboard>("api/Component/GetComponents", ids);

    public async Task<List<Mouse>> GetMiceAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<Mouse>("api/Component/GetComponents", ids);

    public async Task<List<Headset>> GetHeadsetsAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<Headset>("api/Component/GetComponents", ids);
}