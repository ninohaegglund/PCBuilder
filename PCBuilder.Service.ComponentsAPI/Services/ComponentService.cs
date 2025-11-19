using AutoMapper;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Service.ComponentsAPI.IRepositories;
using PCBuilder.Service.ComponentsAPI.Models;
using PCBuilder.Service.ComponentsAPI.Models.DTOs;

using Monitor = PCBuilder.Service.ComponentsAPI.Models.Monitor;
using OperatingSystem = PCBuilder.Service.ComponentsAPI.Models.OperatingSystem;

namespace PCBuilder.Service.ComponentsAPI.Services
{
    public class ComponentService : IComponentService
    {
        private readonly IComponentRepository _repository;
        private readonly IMapper _mapper;

        public ComponentService(IComponentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public Task<T?> GetByIdAsync<T>(int id) where T : class =>
            _repository.GetByIdAsync<T>(id);

        public Task<List<T>> GetAllAsync<T>() where T : class =>
            _repository.GetAllAsync<T>();

        public async Task<AllComponentsDto> GetAllComponentsAsync()
        {
            // Obs: Här blir det explicit samling per typ (för att DTO:n är starkt typad).
            // Det är fortfarande centralt generiskt i repository/service för övriga operationer.
            var dto = new AllComponentsDto
            {
                Cpus = await GetAllAsync<Cpu>(),
                Gpus = await GetAllAsync<VideoCard>(),
                Rams = await GetAllAsync<MemoryKit>(),
                Motherboards = await GetAllAsync<Motherboard>(),
                Cases = await GetAllAsync<Case>(),
                Psus = await GetAllAsync<PowerSupply>(),
                CpuCoolers = await GetAllAsync<CpuCooler>(),
                CaseFans = await GetAllAsync<CaseFan>(),
                InternalStorages = await GetAllAsync<InternalHardDrive>(),
                ExternalStorages = await GetAllAsync<ExternalHardDrive>(),
                Monitors = await GetAllAsync<Monitor>(),
                Keyboards = await GetAllAsync<Keyboard>(),
                Mice = await GetAllAsync<Mouse>(),
                Headphones = await GetAllAsync<Headphones>(),
                Speakers = await GetAllAsync<Speakers>(),
                Webcams = await GetAllAsync<Webcam>(),
                FanControllers = await GetAllAsync<FanController>(),
                SoundCards = await GetAllAsync<SoundCard>(),
                Ups = await GetAllAsync<Ups>(),
                OperatingSystems = await GetAllAsync<OperatingSystem>(),
                CaseAccessories = await GetAllAsync<CaseAccessory>(),
            };

            return dto;
        }

        public Task<List<Manufacturer>> GetAllManufacturersAsync() =>
            GetAllAsync<Manufacturer>();

        public Task<List<Color>> GetAllColorsAsync() =>
            GetAllAsync<Color>();

        public Task<List<FormFactor>> GetAllFormFactorsAsync() =>
            GetAllAsync<FormFactor>();
    }
}