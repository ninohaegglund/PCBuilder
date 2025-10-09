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

namespace PCBuilder.Service.BuilderServiceAPI.Services;

public class GetComponentsService : IGetComponentsService
{
    public readonly ComponentsAPIClient _componentsClient;

    public GetComponentsService(ComponentsAPIClient componentsClient)
    {
        _componentsClient = componentsClient;
    }

    public async Task<List<GPU>> GetGpusAsync(IEnumerable<int> ids) =>
    await _componentsClient.GetByIdsAsync<GPU>("api/gpus", ids);

    public async Task<List<RAM>> GetRamsAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<RAM>("api/rams", ids);

    public async Task<List<StorageDevice>> GetStoragesAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<StorageDevice>("api/storagedevices", ids);

    public async Task<List<ChassiCooling>> GetCaseFansAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<ChassiCooling>("api/chassicoolings", ids);

    public async Task<List<DisplayMonitor>> GetMonitorsAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<DisplayMonitor>("api/displaymonitors", ids);

    public async Task<List<Speaker>> GetSpeakersAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<Speaker>("api/speakers", ids);

    // 1-1-komponenter (hämtar enstaka, men här som lista för konsekvens)

    public async Task<List<CPU>> GetCpusAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<CPU>("api/cpus", ids);

    public async Task<List<PSU>> GetPsusAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<PSU>("api/psus", ids);

    public async Task<List<Motherboard>> GetMotherboardsAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<Motherboard>("api/motherboards", ids);

    public async Task<List<Chassi>> GetCasesAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<Chassi>("api/chassis", ids);

    public async Task<List<CPUCooling>> GetCpuCoolersAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<CPUCooling>("api/cpucoolings", ids);

    public async Task<List<Keyboard>> GetKeyboardsAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<Keyboard>("api/keyboards", ids);

    public async Task<List<Mouse>> GetMiceAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<Mouse>("api/mice", ids);

    public async Task<List<Headset>> GetHeadsetsAsync(IEnumerable<int> ids) =>
        await _componentsClient.GetByIdsAsync<Headset>("api/headsets", ids);
}
