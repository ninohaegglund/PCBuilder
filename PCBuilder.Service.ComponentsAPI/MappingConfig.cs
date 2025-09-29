using AutoMapper;
using PCBuilder.Services.ComponentsAPI.DTOs;
using PCBuilder.Services.ComponentsAPI.Models;

namespace PCBuilder.Service.ComponentsAPI;
public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(config=>
        {
            config.CreateMap<ComputerDTO, Computer>();
            config.CreateMap<Computer, ComputerDTO>();
        });
            return mappingConfig;
    }
}
