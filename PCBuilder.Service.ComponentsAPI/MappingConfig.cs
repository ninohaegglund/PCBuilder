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
using System.Linq;

namespace PCBuilder.Service.ComponentsAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CPU, CPUDto>();
                config.CreateMap<PSU, PSUDTO>();
                config.CreateMap<Motherboard, MotherboardDTO>();
                config.CreateMap<Chassi, ChassiDTO>();
                config.CreateMap<CPUCooling, CPUCoolingDTO>();
                config.CreateMap<Keyboard, KeyboardDTO>();
                config.CreateMap<Mouse, MouseDTO>();
                config.CreateMap<Headset, HeadsetDTO>();
                config.CreateMap<GPU, GPUDto>();
                config.CreateMap<RAM, RAMDTO>();
                config.CreateMap<StorageDevice, StorageDTO>();
                config.CreateMap<ChassiCooling, ChassiCoolingDTO>();
                config.CreateMap<DisplayMonitor, MonitorDTO>();
                config.CreateMap<Speaker, SpeakerDTO>();
                
            });

            return mappingConfig;
        }
    }
}
