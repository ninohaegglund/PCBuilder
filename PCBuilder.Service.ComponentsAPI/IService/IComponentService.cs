using System.Collections.Generic;
using System.Threading.Tasks;
using PCBuilder.Service.ComponentsAPI.Models;
using PCBuilder.Service.ComponentsAPI.Models.DTO;
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

namespace PCBuilder.Service.ComponentsAPI.Interfaces
{
    public interface IComponentService
    {
        Task<List<CPU>> GetAllCPUsAsync();
        Task<List<PSU>> GetAllPSUsAsync();
        Task<List<Motherboard>> GetAllMotherboardsAsync();
        Task<List<Chassi>> GetAllCasesAsync();
        Task<List<Keyboard>> GetAllKeyboardsAsync();
        Task<List<Mouse>> GetAllMiceAsync();
        Task<List<Headset>> GetAllHeadsetsAsync();
        Task<List<GPU>> GetAllGPUsAsync();
        Task<List<RAM>> GetAllRAMModulesAsync();
        Task<List<StorageDevice>> GetAllStorageDevicesAsync();
        Task<List<CPUCooling>> GetAllCPUCoolersAsync();
        Task<List<ChassiCooling>> GetAllChassiCoolersAsync();
        Task<List<DisplayMonitor>> GetAllMonitorsAsync();
        Task<List<Speaker>> GetAllSpeakersAsync();


        Task<List<ComponentDTO>> GetComponentsAsync(IEnumerable<int> ids);
    }
}