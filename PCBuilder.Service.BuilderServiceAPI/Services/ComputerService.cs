using AutoMapper;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.IRepository;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.BuilderServiceAPI.Models;
using PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;

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

    public async Task<ResponseDTO> GetAllComputersAsync()
    {
        try
        {
            var computers = await _computerRepository.GetAllAsync();
            var dtoList = new List<ComputerDTO>();

            foreach (var computer in computers)
            {
                var dto = _mapper.Map<ComputerDTO>(computer);

                if (dto.GPUIds != null && dto.GPUIds.Any())
                    dto.GPUs = (await _componentsService.GetGpusAsync(dto.GPUIds)).ToList();
                if (dto.RAMIds != null && dto.RAMIds.Any())
                    dto.RAMs = (await _componentsService.GetRamsAsync(dto.RAMIds)).ToList();
                if (dto.StorageIds != null && dto.StorageIds.Any())
                    dto.Storages = (await _componentsService.GetStoragesAsync(dto.StorageIds)).ToList();
                if (dto.CaseFanIds != null && dto.CaseFanIds.Any())
                    dto.CaseFans = (await _componentsService.GetCaseFansAsync(dto.CaseFanIds)).ToList();
                if (dto.MonitorIds != null && dto.MonitorIds.Any())
                    dto.Monitors = (await _componentsService.GetMonitorsAsync(dto.MonitorIds)).ToList();
                if (dto.SpeakerIds != null && dto.SpeakerIds.Any())
                    dto.Speakers = (await _componentsService.GetSpeakersAsync(dto.SpeakerIds)).ToList();

                if (computer.CPUId.HasValue)
                    dto.CPU = (await _componentsService.GetCpusAsync(new[] { computer.CPUId.Value })).FirstOrDefault();
                if (computer.PSUId.HasValue)
                    dto.PSU = (await _componentsService.GetPsusAsync(new[] { computer.PSUId.Value })).FirstOrDefault();
                if (computer.MotherboardId.HasValue)
                    dto.Motherboard = (await _componentsService.GetMotherboardsAsync(new[] { computer.MotherboardId.Value })).FirstOrDefault();
                if (computer.CaseId.HasValue)
                    dto.Case = (await _componentsService.GetCasesAsync(new[] { computer.CaseId.Value })).FirstOrDefault();
                if (computer.CpuCoolerId.HasValue)
                    dto.CPUCooler = (await _componentsService.GetCpuCoolersAsync(new[] { computer.CpuCoolerId.Value })).FirstOrDefault();
                if (computer.KeyboardId.HasValue)
                    dto.Keyboard = (await _componentsService.GetKeyboardsAsync(new[] { computer.KeyboardId.Value })).FirstOrDefault();
                if (computer.MouseId.HasValue)
                    dto.Mouse = (await _componentsService.GetMiceAsync(new[] { computer.MouseId.Value })).FirstOrDefault();
                if (computer.HeadsetId.HasValue)
                    dto.Headset = (await _componentsService.GetHeadsetsAsync(new[] { computer.HeadsetId.Value })).FirstOrDefault();

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

            if (dto.GPUIds != null && dto.GPUIds.Any())
                dto.GPUs = (await _componentsService.GetGpusAsync(dto.GPUIds)).ToList();
            if (dto.RAMIds != null && dto.RAMIds.Any())
                dto.RAMs = (await _componentsService.GetRamsAsync(dto.RAMIds)).ToList();
            if (dto.StorageIds != null && dto.StorageIds.Any())
                dto.Storages = (await _componentsService.GetStoragesAsync(dto.StorageIds)).ToList();
            if (dto.CaseFanIds != null && dto.CaseFanIds.Any())
                dto.CaseFans = (await _componentsService.GetCaseFansAsync(dto.CaseFanIds)).ToList();
            if (dto.MonitorIds != null && dto.MonitorIds.Any())
                dto.Monitors = (await _componentsService.GetMonitorsAsync(dto.MonitorIds)).ToList();
            if (dto.SpeakerIds != null && dto.SpeakerIds.Any())
                dto.Speakers = (await _componentsService.GetSpeakersAsync(dto.SpeakerIds)).ToList();

            if (computer.CPUId.HasValue)
                dto.CPU = (await _componentsService.GetCpusAsync(new[] { computer.CPUId.Value })).FirstOrDefault();
            if (computer.PSUId.HasValue)
                dto.PSU = (await _componentsService.GetPsusAsync(new[] { computer.PSUId.Value })).FirstOrDefault();
            if (computer.MotherboardId.HasValue)
                dto.Motherboard = (await _componentsService.GetMotherboardsAsync(new[] { computer.MotherboardId.Value })).FirstOrDefault();
            if (computer.CaseId.HasValue)
                dto.Case = (await _componentsService.GetCasesAsync(new[] { computer.CaseId.Value })).FirstOrDefault();
            if (computer.CpuCoolerId.HasValue)
                dto.CPUCooler = (await _componentsService.GetCpuCoolersAsync(new[] { computer.CpuCoolerId.Value })).FirstOrDefault();
            if (computer.KeyboardId.HasValue)
                dto.Keyboard = (await _componentsService.GetKeyboardsAsync(new[] { computer.KeyboardId.Value })).FirstOrDefault();
            if (computer.MouseId.HasValue)
                dto.Mouse = (await _componentsService.GetMiceAsync(new[] { computer.MouseId.Value })).FirstOrDefault();
            if (computer.HeadsetId.HasValue)
                dto.Headset = (await _componentsService.GetHeadsetsAsync(new[] { computer.HeadsetId.Value })).FirstOrDefault();

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

            response.IsSuccess = true;
            response.Result = _mapper.Map<ComputerDTO>(computer);
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

            response.IsSuccess = true;
            response.Result = _mapper.Map<ComputerDTO>(computer);
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