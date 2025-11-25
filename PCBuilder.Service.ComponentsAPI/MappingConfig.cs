using AutoMapper;
using PCBuilder.Service.ComponentsAPI.Models;
using PCBuilder.Service.ComponentsAPI.Models.DTOs;
using System.ComponentModel;

namespace PCBuilder.Service.ComponentsAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Cpu, CPUDto>().ReverseMap();
                config.CreateMap<VideoCard, GPUDto>().ReverseMap();
                config.CreateMap<MemoryKit, RAMDto>().ReverseMap();
                config.CreateMap<Motherboard, MotherboardDto>().ReverseMap();
                config.CreateMap<Case, CaseDto>().ReverseMap();
                config.CreateMap<PowerSupply, PSUDto>().ReverseMap();

                config.CreateMap<CpuCooler, CPUCoolerDto>().ReverseMap();
                config.CreateMap<CaseFan, CaseFanDto>().ReverseMap();

                config.CreateMap<InternalHardDrive, InternalStorageDto>().ReverseMap();
                config.CreateMap<ExternalHardDrive, ExternalStorageDto>().ReverseMap();

                config.CreateMap<Models.Monitor, MonitorDto>().ReverseMap();
                config.CreateMap<Keyboard, KeyboardDto>().ReverseMap();
                config.CreateMap<Mouse, MouseDto>().ReverseMap();
                config.CreateMap<Headphones, HeadphonesDto>().ReverseMap();
                config.CreateMap<Speakers, SpeakersDto>().ReverseMap();
                config.CreateMap<Webcam, WebcamDto>().ReverseMap();

                config.CreateMap<FanController, FanControllerDto>().ReverseMap();
                config.CreateMap<SoundCard, SoundCardDto>().ReverseMap();
                config.CreateMap<Ups, UpsDto>().ReverseMap();
                config.CreateMap<Models.OperatingSystem, OperatingSystemDto>().ReverseMap();
                config.CreateMap<CaseAccessory, CaseAccessoryDto>().ReverseMap();

                config.CreateMap<Manufacturer, ManufacturerDto>().ReverseMap();
                config.CreateMap<Color, ColorDto>().ReverseMap();
                config.CreateMap<FormFactor, FormFactorDto>().ReverseMap();


                config.AddMaps(typeof(MappingConfig).Assembly);
            });

            return mappingConfig;
        }
    }
}