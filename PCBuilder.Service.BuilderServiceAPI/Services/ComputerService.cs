using AutoMapper;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.IRepository;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.BuilderServiceAPI.Models;
using PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;
using PCBuilder.Service.ComponentsAPI.Models.DTOs;

namespace PCBuilder.Service.BuilderServiceAPI.Services;

public class ComputerService : IComputerService
{
    private readonly IMapper _mapper;
    private readonly IGetComponentsService _componentsService;
    private readonly IRepository<Computer> _computerRepository;

    public ComputerService(
        IMapper mapper,
        IGetComponentsService getComponentsService,
        IRepository<Computer> computerRepository)
    {
        _mapper = mapper;
        _componentsService = getComponentsService;
        _computerRepository = computerRepository;
    }

    private async Task PopulateComponentsAsync(ComputerDTO dto, Computer computer)
    {
        // 1:1-komponenter
        if (computer.CPUId.HasValue)
        {
            var cpu = (await _componentsService.GetCpusAsync(new[] { computer.CPUId.Value })).FirstOrDefault();
            dto.Cpu = _mapper.Map<CPUDto>(cpu);
        }

        if (computer.PSUId.HasValue)
        {
            var psu = (await _componentsService.GetPowerSuppliesAsync(new[] { computer.PSUId.Value })).FirstOrDefault();
            dto.PowerSupply = _mapper.Map<PSUDto>(psu);
        }

        if (computer.MotherboardId.HasValue)
        {
            var mb = (await _componentsService.GetMotherboardsAsync(new[] { computer.MotherboardId.Value })).FirstOrDefault();
            dto.Motherboard = _mapper.Map<MotherboardDto>(mb);
        }

        if (computer.CaseId.HasValue)
        {
            var pcCase = (await _componentsService.GetCasesAsync(new[] { computer.CaseId.Value })).FirstOrDefault();
            dto.Case = _mapper.Map<CaseDto>(pcCase);
        }

        if (computer.CpuCoolerId.HasValue)
        {
            var cooler = (await _componentsService.GetCpuCoolersAsync(new[] { computer.CpuCoolerId.Value })).FirstOrDefault();
            dto.CpuCooler = _mapper.Map<CPUCoolerDto>(cooler);
        }

        if (computer.KeyboardId.HasValue)
        {
            var keyboard = (await _componentsService.GetKeyboardsAsync(new[] { computer.KeyboardId.Value })).FirstOrDefault();
            dto.Keyboard = _mapper.Map<KeyboardDto>(keyboard);
        }

        if (computer.MouseId.HasValue)
        {
            var mouse = (await _componentsService.GetMiceAsync(new[] { computer.MouseId.Value })).FirstOrDefault();
            dto.Mouse = _mapper.Map<MouseDto>(mouse);
        }

        if (computer.HeadsetId.HasValue)
        {
            var headphones = (await _componentsService.GetHeadphonesAsync(new[] { computer.HeadsetId.Value })).FirstOrDefault();
            dto.Headphones = _mapper.Map<HeadphonesDto>(headphones);
        }

        // 1:N-komponenter
        if (computer.GPUIds is { Count: > 0 })
        {
            var gpus = await _componentsService.GetGpusAsync(computer.GPUIds);
            dto.Gpus = _mapper.Map<List<GPUDto>>(gpus);
            dto.GpuIds = computer.GPUIds.ToList();

            if (computer.GPUIds.Count == 1)
                dto.Gpu = dto.Gpus.FirstOrDefault();
        }

        if (computer.RAMIds is { Count: > 0 })
        {
            var rams = await _componentsService.GetRamsAsync(computer.RAMIds);
            dto.Rams = _mapper.Map<List<RAMDto>>(rams);
            dto.RamIds = computer.RAMIds.ToList();
        }

        if (computer.StorageIds is { Count: > 0 })
        {
            var internalTask = _componentsService.GetInternalStoragesAsync(computer.StorageIds);
            var externalTask = _componentsService.GetExternalStoragesAsync(computer.StorageIds);
            await Task.WhenAll(internalTask, externalTask);

            var internalStorages = await internalTask;
            var externalStorages = await externalTask;

            dto.InternalStorages = _mapper.Map<List<InternalStorageDto>>(internalStorages);
            dto.ExternalStorages = _mapper.Map<List<ExternalStorageDto>>(externalStorages);

            dto.InternalStorageIds = computer.StorageIds.ToList();
            dto.ExternalStorageIds = computer.StorageIds.ToList();
        }

        if (computer.CaseFanIds is { Count: > 0 })
        {
            var fans = await _componentsService.GetCaseFansAsync(computer.CaseFanIds);
            dto.CaseFans = _mapper.Map<List<CaseFanDto>>(fans);
            dto.CaseFanIds = computer.CaseFanIds.ToList();
        }

        if (computer.MonitorIds is { Count: > 0 })
        {
            var monitors = await _componentsService.GetMonitorsAsync(computer.MonitorIds);
            dto.Monitors = _mapper.Map<List<MonitorDto>>(monitors);
            dto.MonitorIds = computer.MonitorIds.ToList();
        }

        if (computer.SpeakerIds is { Count: > 0 })
        {
            var speakers = await _componentsService.GetSpeakersAsync(computer.SpeakerIds);
            dto.Speakers = _mapper.Map<List<SpeakersDto>>(speakers);
            dto.SpeakerIds = computer.SpeakerIds.ToList();
        }

        // Id + basfält
        dto.CpuId = computer.CPUId;
        dto.MotherboardId = computer.MotherboardId;
        dto.CaseId = computer.CaseId;
        dto.PowerSupplyId = computer.PSUId;
        dto.CpuCoolerId = computer.CpuCoolerId;
        dto.KeyboardId = computer.KeyboardId;
        dto.MouseId = computer.MouseId;
        dto.HeadphonesId = computer.HeadsetId;

        dto.Id = computer.Id;
        dto.Name = computer.ComputerName;
        dto.CustomerId = computer.CustomerId;
        dto.CreatedAt = computer.CreatedAt;
    }

    public async Task<ResponseDTO> GetAllComputersAsync()
    {
        try
        {
            var computers = await _computerRepository.GetAllAsync();
            var dtoList = new List<ComputerDTO>();

            foreach (var computer in computers)
            {
                var dto = _mapper.Map<ComputerDTO>(computer);
                await PopulateComponentsAsync(dto, computer);
                dtoList.Add(dto);
            }

            return new ResponseDTO { IsSuccess = true, Result = dtoList };
        }
        catch (Exception ex)
        {
            return new ResponseDTO { IsSuccess = false, Result = ex.Message };
        }
    }

    public async Task<ResponseDTO> GetComputerByIdAsync(int id)
    {
        try
        {
            var computer = await _computerRepository.GetByIdAsync(id);

            if (computer == null)
                return new ResponseDTO { IsSuccess = false, Result = "Computer not found" };

            var dto = _mapper.Map<ComputerDTO>(computer);
            await PopulateComponentsAsync(dto, computer);

            return new ResponseDTO { IsSuccess = true, Result = dto };
        }
        catch (Exception ex)
        {
            return new ResponseDTO { IsSuccess = false, Result = ex.Message };
        }
    }

    public async Task<ResponseDTO> CreateComputerAsync(ComputerCreateDTO computerDTO)
    {
        var response = new ResponseDTO();
        try
        {
            var computer = _mapper.Map<Computer>(computerDTO);

            if (string.IsNullOrWhiteSpace(computerDTO.Name))
            {
                int numberOfPc = await _computerRepository.CountAsync();
                computer.ComputerName = $"Customer Computer {numberOfPc + 1}";
            }
            else
            {
                computer.ComputerName = computerDTO.Name;
            }

            await _computerRepository.AddAsync(computer);

            var dto = _mapper.Map<ComputerDTO>(computer);
            await PopulateComponentsAsync(dto, computer);

            response.IsSuccess = true;
            response.Result = dto;
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Result = ex.Message + (ex.InnerException != null ? " | Inner: " + ex.InnerException.Message : "");
        }
        return response;
    }

    public async Task<ResponseDTO> UpdateComputerAsync(int id, ComputerCreateDTO computerDTO)
    {
        var response = new ResponseDTO();
        try
        {
            if (id != computerDTO.Id)
            {
                response.IsSuccess = false;
                response.Result = "Computer ID mismatch";
                return response;
            }

            var computer = await _computerRepository.GetByIdAsync(id);

            if (computer == null)
            {
                response.IsSuccess = false;
                response.Result = "Computer not found";
                return response;
            }

            _mapper.Map(computerDTO, computer);

            if (!string.IsNullOrWhiteSpace(computerDTO.Name))
                computer.ComputerName = computerDTO.Name;

            await _computerRepository.UpdateAsync(computer);

            var dto = _mapper.Map<ComputerDTO>(computer);
            await PopulateComponentsAsync(dto, computer);

            response.IsSuccess = true;
            response.Result = dto;
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Result = ex.Message + (ex.InnerException != null ? " | Inner: " + ex.InnerException.Message : "");
        }
        return response;
    }

    public async Task<ResponseDTO> DeleteComputerAsync(int id)
    {
        var response = new ResponseDTO();
        try
        {
            var computer = await _computerRepository.GetByIdAsync(id);
            if (computer == null)
            {
                response.IsSuccess = false;
                response.Result = "Computer not found";
                return response;
            }

            await _computerRepository.DeleteAsync(computer);

            response.IsSuccess = true;
            response.Result = "Computer deleted successfully";
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Result = ex.Message;
        }
        return response;
    }
}