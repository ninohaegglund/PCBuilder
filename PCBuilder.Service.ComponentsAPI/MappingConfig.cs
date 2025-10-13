using AutoMapper;
using PCBuilder.Service.ComponentsAPI.Models.DTO;
using PCBuilder.Services.ComponentsAPI.Models;
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

namespace PCBuilder.Service.ComponentsAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CPU, CPUDto>().ReverseMap();
                config.CreateMap<PSU, PSUDTO>().ReverseMap();
                config.CreateMap<Motherboard, MotherboardDTO>().ReverseMap();
                config.CreateMap<Chassi, ChassiDTO>().ReverseMap();
                config.CreateMap<CPUCooling, CPUCoolingDTO>().ReverseMap();
                config.CreateMap<Keyboard, KeyboardDTO>().ReverseMap();
                config.CreateMap<Mouse, MouseDTO>().ReverseMap();
                config.CreateMap<Headset, HeadsetDTO>().ReverseMap();
                config.CreateMap<GPU, GPUDto>().ReverseMap();
                config.CreateMap<RAM, RAMDTO>().ReverseMap();
                config.CreateMap<StorageDevice, StorageDTO>().ReverseMap();
                config.CreateMap<ChassiCooling, ChassiCoolingDTO>().ReverseMap();
                config.CreateMap<DisplayMonitor, MonitorDTO>().ReverseMap();
                config.CreateMap<Speaker, SpeakerDTO>().ReverseMap();
                config.AddMaps(typeof(MappingConfig).Assembly);


            });

            return mappingConfig;
        }
    }
}
