using AutoMapper;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.Models;
using PCBuilder.Service.ComponentsAPI.Models;
using PCBuilder.Service.ComponentsAPI.Models.DTOs;

namespace PCBuilder.Service.BuilderServiceAPI.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Computer ↔ DTO
        CreateMap<Computer, ComputerDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ComputerName))
            .ReverseMap();

        CreateMap<Computer, ComputerCreateDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ComputerName))
            .ReverseMap();

        // ───────── Komponenter: Model → DTO ─────────
        CreateMap<Cpu, CPUDto>();
        CreateMap<VideoCard, GPUDto>();
        CreateMap<Motherboard, MotherboardDto>();
        CreateMap<Case, CaseDto>();
        CreateMap<PowerSupply, PSUDto>();
        CreateMap<CpuCooler, CPUCoolerDto>();
        CreateMap<Keyboard, KeyboardDto>();
        CreateMap<Mouse, MouseDto>();
        CreateMap<Headphones, HeadphonesDto>();
        CreateMap<InternalHardDrive, InternalStorageDto>();
        CreateMap<ExternalHardDrive, ExternalStorageDto>();
        CreateMap<CaseFan, CaseFanDto>();
        CreateMap<ComponentsAPI.Models.Monitor, MonitorDto>();
        CreateMap<Speakers, SpeakersDto>();
        CreateMap<ComponentsAPI.Models.OperatingSystem, OperatingSystemDto>();
    }
}