

using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.ComponentsAPI.IRepositories;
using PCBuilder.Service.ComponentsAPI.Models;
using PCBuilder.Services.ComponentsAPI.Data;
using Monitor = PCBuilder.Service.ComponentsAPI.Models.Monitor;
using OperatingSystem = PCBuilder.Service.ComponentsAPI.Models.OperatingSystem;

namespace PCBuilder.Service.ComponentsAPI.Repositories
{
    public class ComponentRepository : IComponentRepository
    {
        private readonly DataContext _context;

        public ComponentRepository(DataContext context)
        {
            _context = context;
        }

        // Lookups
        public async Task<List<Manufacturer>> GetAllManufacturersAsync() =>
            await _context.Manufacturers.AsNoTracking().ToListAsync();

        public async Task<List<Color>> GetAllColorsAsync() =>
          await _context.Colors.AsNoTracking().ToListAsync();

        public async Task<List<FormFactor>> GetAllFormFactorsAsync() =>
            await _context.FormFactors.AsNoTracking().ToListAsync();

        // Core components
        public async Task<List<Cpu>> GetAllCPUsAsync() =>
            await _context.Cpus.AsNoTracking().ToListAsync();

        public async Task<List<VideoCard>> GetAllGPUsAsync() =>
            await _context.VideoCards.AsNoTracking().ToListAsync();

        public async Task<List<MemoryKit>> GetAllRAMModulesAsync() =>
            await _context.MemoryKits.AsNoTracking().ToListAsync();

        public async Task<List<Motherboard>> GetAllMotherboardsAsync() =>
            await _context.Motherboards.AsNoTracking().ToListAsync();

        public async Task<List<Case>> GetAllCasesAsync() =>
            await _context.Cases.AsNoTracking().ToListAsync();

        public async Task<List<PowerSupply>> GetAllPSUsAsync() =>
            await _context.PowerSupplies.AsNoTracking().ToListAsync();

        public async Task<List<CpuCooler>> GetAllCPUCoolersAsync() =>
            await _context.CpuCoolers.AsNoTracking().ToListAsync();

        public async Task<List<CaseFan>> GetAllChassiCoolersAsync() =>
            await _context.CaseFans.AsNoTracking().ToListAsync();

        // Storage
        public async Task<List<InternalHardDrive>> GetAllInternalStorageDevicesAsync() =>
            await _context.InternalHardDrives.AsNoTracking().ToListAsync();

        public async Task<List<ExternalHardDrive>> GetAllExternalStorageDevicesAsync() =>
            await _context.ExternalHardDrives.AsNoTracking().ToListAsync();

        // Peripherals
        public async Task<List<Monitor>> GetAllMonitorsAsync() =>
            await _context.Monitors.AsNoTracking().ToListAsync();

        public async Task<List<Mouse>> GetAllMiceAsync() =>
            await _context.Mice.AsNoTracking().ToListAsync();

        public async Task<List<Keyboard>> GetAllKeyboardsAsync() =>
            await _context.Keyboards.AsNoTracking().ToListAsync();

        public async Task<List<Headphones>> GetAllHeadsetsAsync() =>
            await _context.Headphones.AsNoTracking().ToListAsync();

        public async Task<List<Speakers>> GetAllSpeakersAsync() =>
            await _context.Speakers.AsNoTracking().ToListAsync();

        public async Task<List<Webcam>> GetAllWebcamsAsync() =>
            await _context.Webcams.AsNoTracking().ToListAsync();

        // Other components
        public async Task<List<FanController>> GetAllFanControllersAsync() =>
            await _context.FanControllers.AsNoTracking().ToListAsync();

        public async Task<List<WirelessNetworkCard>> GetAllWirelessNetworkCardsAsync() =>
            await _context.WirelessNetworkCards.AsNoTracking().ToListAsync();

        public async Task<List<WiredNetworkCard>> GetAllWiredNetworkCardsAsync() =>
            await _context.WiredNetworkCards.AsNoTracking().ToListAsync();

        public async Task<List<SoundCard>> GetAllSoundCardsAsync() =>
            await _context.SoundCards.AsNoTracking().ToListAsync();

        public async Task<List<ThermalPaste>> GetAllThermalPastesAsync() =>
            await _context.ThermalPastes.AsNoTracking().ToListAsync();

        public async Task<List<Ups>> GetAllUpsSystemsAsync() =>
            await _context.UpsSystems.AsNoTracking().ToListAsync();

        public async Task<List<OpticalDrive>> GetAllOpticalDrivesAsync() =>
            await _context.OpticalDrives.AsNoTracking().ToListAsync();

        public async Task<List<OperatingSystem>> GetAllOperatingSystemsAsync() =>
            await _context.OperatingSystems.AsNoTracking().ToListAsync();

        public async Task<List<CaseAccessory>> GetAllCaseAccessoriesAsync() =>
            await _context.CaseAccessories.AsNoTracking().ToListAsync();
    }
}