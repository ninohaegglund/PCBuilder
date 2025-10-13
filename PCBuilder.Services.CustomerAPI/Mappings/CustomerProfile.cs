using AutoMapper;
using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.Models;

namespace PCBuilder.Services.CustomerAPI.Mappings;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<Customer, CustomerDTO>();
    }
}