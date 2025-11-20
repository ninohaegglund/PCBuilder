using System.Collections.Generic;

namespace PCBuilder.Service.ComponentsAPI.Models.DTOs
{
    public class AllComponentsDto
    {
        public List<CPUDto> Cpus { get; set; } = new();
        public List<GPUDto> Gpus { get; set; } = new();
        public List<RAMDto> Rams { get; set; } = new();
        public List<MotherboardDto> Motherboards { get; set; } = new();
        public List<CaseDto> Cases { get; set; } = new();
        public List<PSUDto> Psus { get; set; } = new();
        public List<CPUCoolerDto> CpuCoolers { get; set; } = new();
        public List<CaseFanDto> CaseFans { get; set; } = new();
        public List<InternalStorageDto> InternalStorages { get; set; } = new();
        public List<ExternalStorageDto> ExternalStorages { get; set; } = new();
        public List<MonitorDto> Monitors { get; set; } = new();
        public List<KeyboardDto> Keyboards { get; set; } = new();
        public List<MouseDto> Mice { get; set; } = new();
        public List<HeadphonesDto> Headphones { get; set; } = new();
        public List<SpeakersDto> Speakers { get; set; } = new();
        public List<WebcamDto> Webcams { get; set; } = new();
        public List<FanControllerDto> FanControllers { get; set; } = new();
        public List<SoundCardDto> SoundCards { get; set; } = new();
        public List<UpsDto> Ups { get; set; } = new();
        public List<OperatingSystemDto> OperatingSystems { get; set; } = new();
        public List<CaseAccessoryDto> CaseAccessories { get; set; } = new();

        // Added missing properties referenced by ComponentService
        public List<ManufacturerDto> Manufacturers { get; set; } = new();
        public List<ColorDto> Colors { get; set; } = new();
        public List<FormFactorDto> FormFactors { get; set; } = new();
    }
}