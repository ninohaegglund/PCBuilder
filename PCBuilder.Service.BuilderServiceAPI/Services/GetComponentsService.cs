using PCBuilder.Service.BuilderServiceAPI.Client;
using PCBuilder.Service.BuilderServiceAPI.IService;
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

    public async Task<List<GPU>> GetGpusAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<GPU>("api/Component/GetComponents", ids);

    public async Task<List<RAM>> GetRamsAsync(IEnumerable<int> ids) =>
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