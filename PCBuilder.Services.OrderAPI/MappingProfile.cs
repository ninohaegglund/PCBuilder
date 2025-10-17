using AutoMapper;
using PCBuilder.Services.OrderAPI.Models;
using PCBuilder.Services.OrderAPI.Models.Dto;

namespace PCBuilder.Services.OrderAPI;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().ReverseMap();
    }
}
