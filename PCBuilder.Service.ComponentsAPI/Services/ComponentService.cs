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
            { typeof(ColorDto), typeof(Color) },
            { typeof(FormFactorDto), typeof(FormFactor) }
        };

        public ComponentService(IComponentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            ValidateMappings();
        }

        private void ValidateMappings()
        {
            // Kasta tidigt om någon DTO saknar mapping i AutoMapper-profilen
            foreach (var kv in _dtoToEntity)
            {
                if (_mapper.ConfigurationProvider.FindTypeMapFor(kv.Value, kv.Key) == null)
                {
                    throw new InvalidOperationException(
                        $"Saknar AutoMapper-map från {kv.Value.Name} till {kv.Key.Name}. Lägg till CreateMap<{kv.Value.Name}, {kv.Key.Name}> i ComponentProfile.");
                }
            }
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
            // Hämta entiteter parallellt (valfritt optimering)
            var tasks = new Dictionary<string, Task>
            {
                { "cpus", _repository.GetAllAsync<Cpu>() },
                { "gpus", _repository.GetAllAsync<VideoCard>() },
                { "rams", _repository.GetAllAsync<MemoryKit>() },
                { "motherboards", _repository.GetAllAsync<Motherboard>() },
                { "cases", _repository.GetAllAsync<Case>() },
                { "psus", _repository.GetAllAsync<PowerSupply>() },
                { "cpuCoolers", _repository.GetAllAsync<CpuCooler>() },
                { "caseFans", _repository.GetAllAsync<CaseFan>() },
                { "internalStorage", _repository.GetAllAsync<InternalHardDrive>() },
                { "externalStorage", _repository.GetAllAsync<ExternalHardDrive>() },
                { "monitors", _repository.GetAllAsync<MonitorModel>() },
                { "keyboards", _repository.GetAllAsync<Keyboard>() },
                { "mice", _repository.GetAllAsync<Mouse>() },
                { "headphones", _repository.GetAllAsync<Headphones>() },
                { "speakers", _repository.GetAllAsync<Speakers>() },
                { "webcams", _repository.GetAllAsync<Webcam>() },
                { "fanControllers", _repository.GetAllAsync<FanController>() },
                { "soundCards", _repository.GetAllAsync<SoundCard>() },
                { "ups", _repository.GetAllAsync<Ups>() },
                { "operatingSystems", _repository.GetAllAsync<OperatingSystemModel>() },
                { "caseAccessories", _repository.GetAllAsync<CaseAccessory>() },
                { "manufacturers", _repository.GetAllAsync<Manufacturer>() },
                { "colors", _repository.GetAllAsync<Color>() },
                { "formFactors", _repository.GetAllAsync<FormFactor>() }
            };

            await Task.WhenAll(tasks.Values);

            // Hämta resultat från Task<ResultType>
            List<T> GetResult<T>(string key) =>
                (List<T>)tasks[key].GetType().GetProperty("Result")!.GetValue(tasks[key])!;

            return new AllComponentsDto
            {
                Cpus = _mapper.Map<List<CPUDto>>(GetResult<Cpu>("cpus")),
                Gpus = _mapper.Map<List<GPUDto>>(GetResult<VideoCard>("gpus")),
                Rams = _mapper.Map<List<RAMDto>>(GetResult<MemoryKit>("rams")),
                Motherboards = _mapper.Map<List<MotherboardDto>>(GetResult<Motherboard>("motherboards")),
                Cases = _mapper.Map<List<CaseDto>>(GetResult<Case>("cases")),
                Psus = _mapper.Map<List<PSUDto>>(GetResult<PowerSupply>("psus")),
                CpuCoolers = _mapper.Map<List<CPUCoolerDto>>(GetResult<CpuCooler>("cpuCoolers")),
                CaseFans = _mapper.Map<List<CaseFanDto>>(GetResult<CaseFan>("caseFans")),
                InternalStorages = _mapper.Map<List<InternalStorageDto>>(GetResult<InternalHardDrive>("internalStorage")),
                ExternalStorages = _mapper.Map<List<ExternalStorageDto>>(GetResult<ExternalHardDrive>("externalStorage")),
                Monitors = _mapper.Map<List<MonitorDto>>(GetResult<MonitorModel>("monitors")),
                Keyboards = _mapper.Map<List<KeyboardDto>>(GetResult<Keyboard>("keyboards")),
                Mice = _mapper.Map<List<MouseDto>>(GetResult<Mouse>("mice")),
                Headphones = _mapper.Map<List<HeadphonesDto>>(GetResult<Headphones>("headphones")),
                Speakers = _mapper.Map<List<SpeakersDto>>(GetResult<Speakers>("speakers")),
                Webcams = _mapper.Map<List<WebcamDto>>(GetResult<Webcam>("webcams")),
                FanControllers = _mapper.Map<List<FanControllerDto>>(GetResult<FanController>("fanControllers")),
                SoundCards = _mapper.Map<List<SoundCardDto>>(GetResult<SoundCard>("soundCards")),
                Ups = _mapper.Map<List<UpsDto>>(GetResult<Ups>("ups")),
                OperatingSystems = _mapper.Map<List<OperatingSystemDto>>(GetResult<OperatingSystemModel>("operatingSystems")),
                CaseAccessories = _mapper.Map<List<CaseAccessoryDto>>(GetResult<CaseAccessory>("caseAccessories")),
                Manufacturers = _mapper.Map<List<ManufacturerDto>>(GetResult<Manufacturer>("manufacturers")),
                Colors = _mapper.Map<List<ColorDto>>(GetResult<Color>("colors")),
                FormFactors = _mapper.Map<List<FormFactorDto>>(GetResult<FormFactor>("formFactors"))
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