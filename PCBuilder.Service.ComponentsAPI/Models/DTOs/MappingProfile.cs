using AutoMapper;
using PCBuilder.Service.ComponentsAPI.Models;

namespace PCBuilder.Service.ComponentsAPI.Models.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cpu, CPUDto>().ReverseMap();
            CreateMap<VideoCard, GPUDto>().ReverseMap();
            CreateMap<MemoryKit, RAMDto>().ReverseMap();
            CreateMap<Motherboard, MotherboardDto>().ReverseMap();
            CreateMap<Case, CaseDto>().ReverseMap();
            CreateMap<PowerSupply, PSUDto>().ReverseMap();

            CreateMap<CpuCooler, CPUCoolerDto>().ReverseMap();
            CreateMap<CaseFan, CaseFanDto>().ReverseMap();

            CreateMap<InternalHardDrive, InternalStorageDto>().ReverseMap();
            CreateMap<ExternalHardDrive, ExternalStorageDto>().ReverseMap();

            CreateMap<Monitor, MonitorDto>().ReverseMap();
            CreateMap<Keyboard, KeyboardDto>().ReverseMap();
            CreateMap<Mouse, MouseDto>().ReverseMap();
            CreateMap<Headphones, HeadphonesDto>().ReverseMap();
            CreateMap<Speakers, SpeakersDto>().ReverseMap();
            CreateMap<Webcam, WebcamDto>().ReverseMap();

            CreateMap<FanController, FanControllerDto>().ReverseMap();
            CreateMap<SoundCard, SoundCardDto>().ReverseMap();
            CreateMap<Ups, UpsDto>().ReverseMap();
            CreateMap<OperatingSystem, OperatingSystemDto>().ReverseMap();
            CreateMap<CaseAccessory, CaseAccessoryDto>().ReverseMap();

            CreateMap<Manufacturer, ManufacturerDto>().ReverseMap();
            CreateMap<Color, ColorDto>().ReverseMap();
            CreateMap<FormFactor, FormFactorDto>().ReverseMap();
        }
    }
}