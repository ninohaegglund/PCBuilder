namespace PCBuilder.Service.BuilderServiceAPI.Mapping;

using AutoMapper;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.Models;
public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Computer, ComputerDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ComputerName)).ReverseMap();

        CreateMap<Computer, ComputerCreateDTO>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ComputerName)).ReverseMap();

    }
    
}