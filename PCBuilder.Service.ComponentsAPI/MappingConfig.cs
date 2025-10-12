using AutoMapper;
using PCBuilder.Service.ComponentsAPI.Models.DTO;
using PCBuilder.Services.ComponentsAPI.DTOs;
using PCBuilder.Services.ComponentsAPI.Models;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cables;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cables.PCIe;
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
                // DTO -> Model
                config.CreateMap<ComputerDTO, Computer>();

                // Model -> DTO
                config.CreateMap<Computer, ComputerDTO>()
                    // 1-1 relations
                    .ForMember(dest => dest.CPUName, opt => opt.MapFrom(src => src.Cpu != null ? src.Cpu.ModelName : null))
                    .ForMember(dest => dest.PSUName, opt => opt.MapFrom(src => src.PSU != null ? src.PSU.ModelName : null))
                    .ForMember(dest => dest.MotherboardName, opt => opt.MapFrom(src => src.Motherboard != null ? src.Motherboard.ModelName : null))
                    .ForMember(dest => dest.CaseName, opt => opt.MapFrom(src => src.Case != null ? src.Case.ModelName : null))
                    .ForMember(dest => dest.CPUCoolerName, opt => opt.MapFrom(src => src.CPUCooler != null ? src.CPUCooler.ModelName : null))
                    .ForMember(dest => dest.KeyboardName, opt => opt.MapFrom(src => src.Keyboard != null ? src.Keyboard.ModelName : null))
                    .ForMember(dest => dest.MouseName, opt => opt.MapFrom(src => src.Mouse != null ? src.Mouse.ModelName : null))
                    .ForMember(dest => dest.HeadsetName, opt => opt.MapFrom(src => src.Headset != null ? src.Headset.ModelName : null))
                    // 1-many relations
                    .ForMember(dest => dest.GPUIds, opt => opt.MapFrom(src => src.GPU.Select(g => g.Id)))
                    .ForMember(dest => dest.GPUNames, opt => opt.MapFrom(src => src.GPU.Select(g => g.ModelName)))
                    .ForMember(dest => dest.RAMIds, opt => opt.MapFrom(src => src.RamModules.Select(r => r.Id)))
                    .ForMember(dest => dest.RAMNames, opt => opt.MapFrom(src => src.RamModules.Select(r => r.ModelName)))
                    .ForMember(dest => dest.StorageIds, opt => opt.MapFrom(src => src.Storage.Select(s => s.Id)))
                    .ForMember(dest => dest.StorageNames, opt => opt.MapFrom(src => src.Storage.Select(s => s.ModelName)))
                    .ForMember(dest => dest.CaseFanIds, opt => opt.MapFrom(src => src.CaseFans.Select(f => f.Id)))
                    .ForMember(dest => dest.CaseFanNames, opt => opt.MapFrom(src => src.CaseFans.Select(f => f.ModelName)))
                    .ForMember(dest => dest.PCIeCableIds, opt => opt.MapFrom(src => src.PCIeCables.Select(c => c.Id)))
                    .ForMember(dest => dest.PowerCableIds, opt => opt.MapFrom(src => src.PowerCables.Select(c => c.Id)))
                    .ForMember(dest => dest.SataCableIds, opt => opt.MapFrom(src => src.SataCables.Select(c => c.Id)))
                    .ForMember(dest => dest.MonitorIds, opt => opt.MapFrom(src => src.Monitor.Select(m => m.Id)))
                    .ForMember(dest => dest.MonitorNames, opt => opt.MapFrom(src => src.Monitor.Select(m => m.ModelName)))
                    .ForMember(dest => dest.SpeakerIds, opt => opt.MapFrom(src => src.Speakers.Select(s => s.Id)))
                    .ForMember(dest => dest.SpeakerNames, opt => opt.MapFrom(src => src.Speakers.Select(s => s.ModelName)));

                // DTO to Model mappings
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
                config.CreateMap<PCIeCable, PCIeCableDTO>();
                config.CreateMap<PowerCable, PowerCableDTO>();
                config.CreateMap<SataCable, SataCableDTO>();
                config.CreateMap<DisplayMonitor, MonitorDTO>();
                config.CreateMap<Speaker, SpeakerDTO>();
                
            });

            return mappingConfig;
        }
    }
}
