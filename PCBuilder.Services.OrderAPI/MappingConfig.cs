using AutoMapper;
using PCBuilder.Services.OrderAPI.Models;
using PCBuilder.Services.OrderAPI.Models.Dto;

namespace PCBuilder.Services.OrderAPI;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration( config =>
        
        {
            config.AddMaps(typeof(MappingConfig).Assembly);

        });

        return mappingConfig;
    }
}
