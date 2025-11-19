namespace PCBuilder.Service.ComponentsAPI.Mapping;

using AutoMapper;
using PCBuilder.Service.ComponentsAPI.Models;
using PCBuilder.Service.ComponentsAPI.Models.DTO;


public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Cpu, CPUDto>().ReverseMap();
        CreateMap<PSU, PSUDTO>().ReverseMap();
        CreateMap<Motherboard, MotherboardDTO>().ReverseMap();
        CreateMap<Chassi, ChassiDTO>().ReverseMap();
        CreateMap<CPUCooling, CPUCoolingDTO>().ReverseMap();
        CreateMap<Keyboard, KeyboardDTO>().ReverseMap();
        CreateMap<Mouse, MouseDTO>().ReverseMap();
        CreateMap<Headset, HeadsetDTO>().ReverseMap();
        CreateMap<GPU, GPUDto>().ReverseMap();
        CreateMap<RAM, RAMDTO>().ReverseMap();
        CreateMap<StorageDevice, StorageDTO>().ReverseMap();
        CreateMap<ChassiCooling, ChassiCoolingDTO>().ReverseMap();
        CreateMap<DisplayMonitor, MonitorDTO>().ReverseMap();
        CreateMap<Speaker, SpeakerDTO>().ReverseMap();
    }

}
    
