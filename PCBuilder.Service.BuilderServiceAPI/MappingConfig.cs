using AutoMapper;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.Models;

namespace PCBuilder.Service.BuilderServiceAPI;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration( config =>
        
        {
            config.CreateMap<InventoryItemDTO, Inventory>();
            config.CreateMap<Inventory, InventoryItemDTO>();
            config.AddMaps(typeof(MappingConfig).Assembly);

        });

        return mappingConfig;
    }
}
