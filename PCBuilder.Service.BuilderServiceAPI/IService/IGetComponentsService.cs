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

namespace PCBuilder.Service.BuilderServiceAPI.IService
{
    public interface IGetComponentsService
    {
        Task<List<ChassiCooling>> GetCaseFansAsync(IEnumerable<int> ids);
        Task<List<Chassi>> GetCasesAsync(IEnumerable<int> ids);
        Task<List<CPUCooling>> GetCpuCoolersAsync(IEnumerable<int> ids);
        Task<List<CPU>> GetCpusAsync(IEnumerable<int> ids);
        Task<List<GPU>> GetGpusAsync(IEnumerable<int> ids);
        Task<List<Headset>> GetHeadsetsAsync(IEnumerable<int> ids);
        Task<List<Keyboard>> GetKeyboardsAsync(IEnumerable<int> ids);
        Task<List<Mouse>> GetMiceAsync(IEnumerable<int> ids);
        Task<List<DisplayMonitor>> GetMonitorsAsync(IEnumerable<int> ids);
        Task<List<Motherboard>> GetMotherboardsAsync(IEnumerable<int> ids);
        Task<List<PSU>> GetPsusAsync(IEnumerable<int> ids);
        Task<List<RAM>> GetRamsAsync(IEnumerable<int> ids);
        Task<List<Speaker>> GetSpeakersAsync(IEnumerable<int> ids);
        Task<List<StorageDevice>> GetStoragesAsync(IEnumerable<int> ids);
    }
}