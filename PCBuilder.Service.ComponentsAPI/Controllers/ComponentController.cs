using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Service.ComponentsAPI.Models.DTOs;

namespace PCBuilder.Service.ComponentsAPI.Controllers
{
    [ApiController]
    [Route("api/components")]
    public class ComponentController : ControllerBase
    {
        private readonly IComponentService _componentService;

        public ComponentController(IComponentService componentService)
        {
            _componentService = componentService;
        }

        [HttpGet]
        public async Task<AllComponentsDto> GetAll()
        {
            return await _componentService.GetAllComponentsAsync();
        }

        [HttpGet("manufacturers")]
        public async Task<List<ManufacturerDto>> GetAllManufacturers()
        {
            return await _componentService.GetAllManufacturersAsync();
        }

        // CPU
        [HttpGet("cpus")]
        public async Task<List<CPUDto>> GetAllCpus()
            => await _componentService.GetAllAsync<CPUDto>();

        [HttpGet("cpus/{id:int}")]
        public async Task<ActionResult<CPUDto>> GetCpuById(int id)
            => await GetByIdTyped<CPUDto>(id);

        // Video Cards
        [HttpGet("videocards")]
        public async Task<List<GPUDto>> GetAllVideoCards()
            => await _componentService.GetAllAsync<GPUDto>();

        [HttpGet("videocards/{id:int}")]
        public async Task<ActionResult<GPUDto>> GetVideoCardById(int id)
            => await GetByIdTyped<GPUDto>(id);

        // Memory Kits
        [HttpGet("memorykits")]
        public async Task<List<RAMDto>> GetAllMemoryKits()
            => await _componentService.GetAllAsync<RAMDto>();

        [HttpGet("memorykits/{id:int}")]
        public async Task<ActionResult<RAMDto>> GetMemoryKitById(int id)
            => await GetByIdTyped<RAMDto>(id);

        // Motherboards
        [HttpGet("motherboards")]
        public async Task<List<MotherboardDto>> GetAllMotherboards()
            => await _componentService.GetAllAsync<MotherboardDto>();

        [HttpGet("motherboards/{id:int}")]
        public async Task<ActionResult<MotherboardDto>> GetMotherboardById(int id)
            => await GetByIdTyped<MotherboardDto>(id);

        // Cases
        [HttpGet("cases")]
        public async Task<List<CaseDto>> GetAllCases()
            => await _componentService.GetAllAsync<CaseDto>();

        [HttpGet("cases/{id:int}")]
        public async Task<ActionResult<CaseDto>> GetCaseById(int id)
            => await GetByIdTyped<CaseDto>(id);

        // Power Supplies
        [HttpGet("powersupplies")]
        public async Task<List<PSUDto>> GetAllPowerSupplies()
            => await _componentService.GetAllAsync<PSUDto>();

        [HttpGet("powersupplies/{id:int}")]
        public async Task<ActionResult<PSUDto>> GetPowerSupplyById(int id)
            => await GetByIdTyped<PSUDto>(id);

        // CPU Coolers (KORRIGERAT)
        [HttpGet("cpucoolers")]
        public async Task<List<CPUCoolerDto>> GetAllCpuCoolers()
            => await _componentService.GetAllAsync<CPUCoolerDto>();

        [HttpGet("cpucoolers/{id:int}")]
        public async Task<ActionResult<CPUCoolerDto>> GetCpuCoolerById(int id)
            => await GetByIdTyped<CPUCoolerDto>(id);

        // Case Fans
        [HttpGet("casefans")]
        public async Task<List<CaseFanDto>> GetAllCaseFans()
            => await _componentService.GetAllAsync<CaseFanDto>();

        [HttpGet("casefans/{id:int}")]
        public async Task<ActionResult<CaseFanDto>> GetCaseFanById(int id)
            => await GetByIdTyped<CaseFanDto>(id);

        // Internal Hard Drives
        [HttpGet("internalharddrives")]
        public async Task<List<InternalStorageDto>> GetAllInternalHardDrives()
            => await _componentService.GetAllAsync<InternalStorageDto>();

        [HttpGet("internalharddrives/{id:int}")]
        public async Task<ActionResult<InternalStorageDto>> GetInternalHardDriveById(int id)
            => await GetByIdTyped<InternalStorageDto>(id);

        // External Hard Drives
        [HttpGet("externalharddrives")]
        public async Task<List<ExternalStorageDto>> GetAllExternalHardDrives()
            => await _componentService.GetAllAsync<ExternalStorageDto>();

        [HttpGet("externalharddrives/{id:int}")]
        public async Task<ActionResult<ExternalStorageDto>> GetExternalHardDriveById(int id)
            => await GetByIdTyped<ExternalStorageDto>(id);

        // Case Accessories
        [HttpGet("caseaccessories")]
        public async Task<List<CaseAccessoryDto>> GetAllCaseAccessories()
            => await _componentService.GetAllAsync<CaseAccessoryDto>();

        [HttpGet("caseaccessories/{id:int}")]
        public async Task<ActionResult<CaseAccessoryDto>> GetCaseAccessoryById(int id)
            => await GetByIdTyped<CaseAccessoryDto>(id);

        // Fan Controllers
        [HttpGet("fancontrollers")]
        public async Task<List<FanControllerDto>> GetAllFanControllers()
            => await _componentService.GetAllAsync<FanControllerDto>();

        [HttpGet("fancontrollers/{id:int}")]
        public async Task<ActionResult<FanControllerDto>> GetFanControllerById(int id)
            => await GetByIdTyped<FanControllerDto>(id);

        // Operating Systems
        [HttpGet("operatingsystems")]
        public async Task<List<OperatingSystemDto>> GetAllOperatingSystems()
            => await _componentService.GetAllAsync<OperatingSystemDto>();

        [HttpGet("operatingsystems/{id:int}")]
        public async Task<ActionResult<OperatingSystemDto>> GetOperatingSystemById(int id)
            => await GetByIdTyped<OperatingSystemDto>(id);

        // Sound Cards
        [HttpGet("soundcards")]
        public async Task<List<SoundCardDto>> GetAllSoundCards()
            => await _componentService.GetAllAsync<SoundCardDto>();

        [HttpGet("soundcards/{id:int}")]
        public async Task<ActionResult<SoundCardDto>> GetSoundCardById(int id)
            => await GetByIdTyped<SoundCardDto>(id);

        // Speakers
        [HttpGet("speakers")]
        public async Task<List<SpeakersDto>> GetAllSpeakers()
            => await _componentService.GetAllAsync<SpeakersDto>();

        [HttpGet("speakers/{id:int}")]
        public async Task<ActionResult<SpeakersDto>> GetSpeakersById(int id)
            => await GetByIdTyped<SpeakersDto>(id);

        // Webcams
        [HttpGet("webcams")]
        public async Task<List<WebcamDto>> GetAllWebcams()
            => await _componentService.GetAllAsync<WebcamDto>();

        [HttpGet("webcams/{id:int}")]
        public async Task<ActionResult<WebcamDto>> GetWebcamById(int id)
            => await GetByIdTyped<WebcamDto>(id);

        // UPS
        [HttpGet("ups")]
        public async Task<List<UpsDto>> GetAllUps()
            => await _componentService.GetAllAsync<UpsDto>();

        [HttpGet("ups/{id:int}")]
        public async Task<ActionResult<UpsDto>> GetUpsById(int id)
            => await GetByIdTyped<UpsDto>(id);

        // Headphones
        [HttpGet("headphones")]
        public async Task<List<HeadphonesDto>> GetAllHeadphones()
            => await _componentService.GetAllAsync<HeadphonesDto>();

        [HttpGet("headphones/{id:int}")]
        public async Task<ActionResult<HeadphonesDto>> GetHeadphonesById(int id)
            => await GetByIdTyped<HeadphonesDto>(id);

        // Monitors
        [HttpGet("monitors")]
        public async Task<List<MonitorDto>> GetAllMonitors()
            => await _componentService.GetAllAsync<MonitorDto>();

        [HttpGet("monitors/{id:int}")]
        public async Task<ActionResult<MonitorDto>> GetMonitorById(int id)
            => await GetByIdTyped<MonitorDto>(id);

        // Mice
        [HttpGet("mice")]
        public async Task<List<MouseDto>> GetAllMice()
            => await _componentService.GetAllAsync<MouseDto>();

        [HttpGet("mice/{id:int}")]
        public async Task<ActionResult<MouseDto>> GetMouseById(int id)
            => await GetByIdTyped<MouseDto>(id);

        // Keyboards
        [HttpGet("keyboards")]
        public async Task<List<KeyboardDto>> GetAllKeyboards()
            => await _componentService.GetAllAsync<KeyboardDto>();

        [HttpGet("keyboards/{id:int}")]
        public async Task<ActionResult<KeyboardDto>> GetKeyboardById(int id)
            => await GetByIdTyped<KeyboardDto>(id);

        private async Task<ActionResult<TDto>> GetByIdTyped<TDto>(int id)
        {
            var item = await _componentService.GetByIdAsync<TDto>(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
    }
}