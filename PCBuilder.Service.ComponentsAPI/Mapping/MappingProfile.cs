namespace PCBuilder.Service.ComponentsAPI.Mapping;

using AutoMapper;
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

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CPU, CPUDto>().ReverseMap();
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
    
