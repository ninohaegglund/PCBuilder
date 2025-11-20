using AutoMapper;
using PCBuilder.Service.ComponentsAPI.Models;
using PCBuilder.Service.ComponentsAPI.Models.DTOs;

namespace PCBuilder.Service.ComponentsAPI.Mapping
{
    public class ComponentProfile : Profile
    {
        public ComponentProfile()
        {
            CreateMap<Cpu, CPUDto>();
            CreateMap<VideoCard, GPUDto>();
            CreateMap<MemoryKit, RAMDto>()
                .ForMember(d => d.ModulesCount, opt => opt.MapFrom(src => src.ModulesCount))
                .ForMember(d => d.CapacityPerModuleGB, opt => opt.MapFrom(src => src.CapacityPerModuleGB));
            CreateMap<Motherboard, MotherboardDto>();
            CreateMap<Case, CaseDto>();
            CreateMap<PowerSupply, PSUDto>();
            CreateMap<CpuCooler, CPUCoolerDto>();
            CreateMap<CaseFan, CaseFanDto>();
            CreateMap<InternalHardDrive, InternalStorageDto>();
            CreateMap<ExternalHardDrive, ExternalStorageDto>();
            CreateMap<CaseAccessory, CaseAccessoryDto>();
            CreateMap<FanController, FanControllerDto>();
            CreateMap<Models.OperatingSystem, OperatingSystemDto>();
            CreateMap<SoundCard, SoundCardDto>();
            CreateMap<Speakers, SpeakersDto>();
            CreateMap<Webcam, WebcamDto>();
            CreateMap<Ups, UpsDto>();
            CreateMap<Headphones, HeadphonesDto>();
            CreateMap<Models.Monitor, MonitorDto>();
            CreateMap<Mouse, MouseDto>();
            CreateMap<Keyboard, KeyboardDto>();
            CreateMap<Manufacturer, ManufacturerDto>();
            CreateMap<Color, ColorDto>();
            CreateMap<FormFactor, FormFactorDto>();
        }
    }
}