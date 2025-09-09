using AutoMapper;
using PCBuilder.Services.TestAPI.Models;
using PCBuilder.Services.TestAPI.Models.Dto;

namespace PCBuilder.Services.TestAPI;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration( config =>
        
        {
            config.CreateMap<CouponDto, Coupon>();
            config.CreateMap<Coupon, CouponDto>();
        });

        return mappingConfig;
    }
}
