using AutoMapper;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Service.ComponentsAPI.IRepositories;
using PCBuilder.Service.ComponentsAPI.Models;
using PCBuilder.Service.ComponentsAPI.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Alias om du har namnkonflikt med System.OperatingSystem / System.Monitor
using OperatingSystemModel = PCBuilder.Service.ComponentsAPI.Models.OperatingSystem;
using MonitorModel = PCBuilder.Service.ComponentsAPI.Models.Monitor;

namespace PCBuilder.Service.ComponentsAPI.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IComponentRepository _repository;
        private readonly IMapper _mapper;

        // DTO -> Entitets-typ
        private static readonly Dictionary<Type, Type> _dtoToEntity = new()
        {
            { typeof(CPUDto), typeof(Cpu) },
            { typeof(GPUDto), typeof(VideoCard) },
            { typeof(RAMDto), typeof(MemoryKit) },
            { typeof(MotherboardDto), typeof(Motherboard) },
            { typeof(CaseDto), typeof(Case) },
            { typeof(PSUDto), typeof(PowerSupply) },
            { typeof(CPUCoolerDto), typeof(CpuCooler) },
            { typeof(CaseFanDto), typeof(CaseFan) },
            { typeof(InternalStorageDto), typeof(InternalHardDrive) },
            { typeof(ExternalStorageDto), typeof(ExternalHardDrive) },
            { typeof(CaseAccessoryDto), typeof(CaseAccessory) },
            { typeof(FanControllerDto), typeof(FanController) },
            { typeof(OperatingSystemDto), typeof(OperatingSystemModel) },
            { typeof(SoundCardDto), typeof(SoundCard) },
            { typeof(SpeakersDto), typeof(Speakers) },
            { typeof(WebcamDto), typeof(Webcam) },
            { typeof(UpsDto), typeof(Ups) },
            { typeof(HeadphonesDto), typeof(Headphones) },
            { typeof(MonitorDto), typeof(MonitorModel) },
            { typeof(MouseDto), typeof(Mouse) },
            { typeof(KeyboardDto), typeof(Keyboard) },
            { typeof(ManufacturerDto), typeof(Manufacturer) },
            { typeof(FormFactorDto), typeof(FormFactor) }
        };

        public ComponentService(IComponentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TDto?> GetByIdAsync<TDto>(int id)
        {
            var dtoType = typeof(TDto);
            if (!_dtoToEntity.TryGetValue(dtoType, out var entityType))
                throw new NotSupportedException($"DTO-typen {dtoType.Name} stöds inte.");

            // Dynamiskt anropa generisk metod
            var method = typeof(IComponentRepository).GetMethod(nameof(IComponentRepository.GetByIdAsync))!
                .MakeGenericMethod(entityType);
            var task = (Task)method.Invoke(_repository, new object?[] { id })!;
            await task.ConfigureAwait(false);

            var resultProperty = task.GetType().GetProperty("Result")!;
            var entity = resultProperty.GetValue(task);

            if (entity == null) return default;

            return (TDto?)_mapper.Map(entity, entityType, dtoType);
        }

        public async Task<List<TDto>> GetAllAsync<TDto>()
        {
            var dtoType = typeof(TDto);
            if (!_dtoToEntity.TryGetValue(dtoType, out var entityType))
                throw new NotSupportedException($"DTO-typen {dtoType.Name} stöds inte.");

            var method = typeof(IComponentRepository).GetMethod(nameof(IComponentRepository.GetAllAsync))!
                .MakeGenericMethod(entityType);
            var task = (Task)method.Invoke(_repository, Array.Empty<object>())!;
            await task.ConfigureAwait(false);

            var resultProperty = task.GetType().GetProperty("Result")!;
            var entities = (IEnumerable<object>)(resultProperty.GetValue(task) as System.Collections.IEnumerable
                                                  ?? Array.Empty<object>());

            var mapped = entities.Select(e => _mapper.Map(e, entityType, dtoType)).Cast<TDto>().ToList();
            return mapped;
        }

        public async Task<AllComponentsDto> GetAllComponentsAsync()
        {
            var cpus = await _repository.GetAllAsync<Cpu>();
            var gpus = await _repository.GetAllAsync<VideoCard>();
            var rams = await _repository.GetAllAsync<MemoryKit>();
            var motherboards = await _repository.GetAllAsync<Motherboard>();
            var cases = await _repository.GetAllAsync<Case>();
            var psus = await _repository.GetAllAsync<PowerSupply>();
            var cpuCoolers = await _repository.GetAllAsync<CpuCooler>();
            var caseFans = await _repository.GetAllAsync<CaseFan>();
            var internalStorage = await _repository.GetAllAsync<InternalHardDrive>();
            var externalStorage = await _repository.GetAllAsync<ExternalHardDrive>();
            var monitors = await _repository.GetAllAsync<MonitorModel>();
            var keyboards = await _repository.GetAllAsync<Keyboard>();
            var mice = await _repository.GetAllAsync<Mouse>();
            var headphones = await _repository.GetAllAsync<Headphones>();
            var speakers = await _repository.GetAllAsync<Speakers>();
            var webcams = await _repository.GetAllAsync<Webcam>();
            var fanControllers = await _repository.GetAllAsync<FanController>();
            var soundCards = await _repository.GetAllAsync<SoundCard>();
            var ups = await _repository.GetAllAsync<Ups>();
            var operatingSystems = await _repository.GetAllAsync<OperatingSystemModel>();
            var caseAccessories = await _repository.GetAllAsync<CaseAccessory>();
            var manufacturers = await _repository.GetAllAsync<Manufacturer>();
            var formFactors = await _repository.GetAllAsync<FormFactor>();

            return new AllComponentsDto
            {
                Cpus = _mapper.Map<List<CPUDto>>(cpus),
                Gpus = _mapper.Map<List<GPUDto>>(gpus),
                Rams = _mapper.Map<List<RAMDto>>(rams),
                Motherboards = _mapper.Map<List<MotherboardDto>>(motherboards),
                Cases = _mapper.Map<List<CaseDto>>(cases),
                Psus = _mapper.Map<List<PSUDto>>(psus),
                CpuCoolers = _mapper.Map<List<CPUCoolerDto>>(cpuCoolers),
                CaseFans = _mapper.Map<List<CaseFanDto>>(caseFans),
                InternalStorages = _mapper.Map<List<InternalStorageDto>>(internalStorage),
                ExternalStorages = _mapper.Map<List<ExternalStorageDto>>(externalStorage),
                Monitors = _mapper.Map<List<MonitorDto>>(monitors),
                Keyboards = _mapper.Map<List<KeyboardDto>>(keyboards),
                Mice = _mapper.Map<List<MouseDto>>(mice),
                Headphones = _mapper.Map<List<HeadphonesDto>>(headphones),
                Speakers = _mapper.Map<List<SpeakersDto>>(speakers),
                Webcams = _mapper.Map<List<WebcamDto>>(webcams),
                FanControllers = _mapper.Map<List<FanControllerDto>>(fanControllers),
                SoundCards = _mapper.Map<List<SoundCardDto>>(soundCards),
                Ups = _mapper.Map<List<UpsDto>>(ups),
                OperatingSystems = _mapper.Map<List<OperatingSystemDto>>(operatingSystems),
                CaseAccessories = _mapper.Map<List<CaseAccessoryDto>>(caseAccessories),
                Manufacturers = _mapper.Map<List<ManufacturerDto>>(manufacturers),
                FormFactors = _mapper.Map<List<FormFactorDto>>(formFactors)
            };
        }

        public async Task<List<ManufacturerDto>> GetAllManufacturersAsync()
        {
            var entities = await _repository.GetAllAsync<Manufacturer>();
            return _mapper.Map<List<ManufacturerDto>>(entities);
        }

        public async Task<List<FormFactorDto>> GetAllFormFactorsAsync()
        {
            var entities = await _repository.GetAllAsync<FormFactor>();
            return _mapper.Map<List<FormFactorDto>>(entities);
        }
    }
}