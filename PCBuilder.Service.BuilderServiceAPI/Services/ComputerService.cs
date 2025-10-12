using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.BuilderServiceAPI.Data;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.BuilderServiceAPI.Models;
using PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.Repository;
using PCBuilder.Service.BuilderServiceAPI.Repository.IRepository;

namespace PCBuilder.Service.BuilderServiceAPI.Services;

public class ComputerService : IComputerService
{
    private readonly PcDataContext _context;
    private readonly IMapper _mapper;
    private readonly IGetComponentsService _componentsService;
    private readonly IBuiltComputersRepository _computerRepository;
    private readonly UnfinishedBuildsRepository _unfinishedBuildsRepository;

    public ComputerService(PcDataContext context, IMapper mapper, IGetComponentsService getComponentsService, IBuiltComputersRepository computerRepository, UnfinishedBuildsRepository unfinishedBuildsRepository)
    {
        _context = context;
        _mapper = mapper;
        _componentsService = getComponentsService;
        _computerRepository = computerRepository;
        _unfinishedBuildsRepository = unfinishedBuildsRepository;
    }

    public async Task<ResponseDTO> GetAllComputersAsync()
    {
        try
        {
            var computers = await _context.Computers.ToListAsync();

            var dtoList = new List<ComputerDTO>();

            foreach (var computer in computers)
            {
                var dto = new ComputerDTO
                {
                    Id = computer.Id,
                    Name = computer.Name,
                    CPUId = computer.CPUId,
                    PSUId = computer.PSUId,
                    MotherboardId = computer.MotherboardId,
                    CaseId = computer.CaseId,
                    CpuCoolerId = computer.CpuCoolerId,
                    KeyboardId = computer.KeyboardId,
                    MouseId = computer.MouseId,
                    HeadsetId = computer.HeadsetId,

                    GPUIds = computer.GPUIds,
                    RAMIds = computer.RAMIds,
                    StorageIds = computer.StorageIds,
                    CaseFanIds = computer.CaseFanIds,
                    MonitorIds = computer.MonitorIds,
                    SpeakerIds = computer.SpeakerIds
                };

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
            var computer = await _context.Computers.FindAsync(id);

            if (computer == null)
                return new ResponseDTO { IsSuccess = false, Result = "Computer not found" };

            var dto = new ComputerDTO
            {
                Id = computer.Id,
                Name = computer.Name,
                CPUId = computer.CPUId,
                PSUId = computer.PSUId,
                MotherboardId = computer.MotherboardId,
                CaseId = computer.CaseId,
                CpuCoolerId = computer.CpuCoolerId,
                KeyboardId = computer.KeyboardId,
                MouseId = computer.MouseId,
                HeadsetId = computer.HeadsetId,

                GPUIds = computer.GPUIds,
                RAMIds = computer.RAMIds,
                StorageIds = computer.StorageIds,
                CaseFanIds = computer.CaseFanIds,
                MonitorIds = computer.MonitorIds,
                SpeakerIds = computer.SpeakerIds
            };

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

            // 1-1-komponentnamn
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
            var computer = new Computer();

            // Namn-hantering
            if (string.IsNullOrWhiteSpace(computerDTO.Name))
            {
                int numberOfPc = await _context.Computers.CountAsync();
                computer.Name = $"Customer Computer {numberOfPc + 1}";
            }
            else
            {
                computer.Name = computerDTO.Name;
            }

            // 1-1 relationer
            computer.CPUId = computerDTO.CPUId;
            computer.PSUId = computerDTO.PSUId;
            computer.MotherboardId = computerDTO.MotherboardId;
            computer.CaseId = computerDTO.CaseId;
            computer.CpuCoolerId = computerDTO.CpuCoolerId;
            computer.KeyboardId = computerDTO.KeyboardId;
            computer.MouseId = computerDTO.MouseId;
            computer.HeadsetId = computerDTO.HeadsetId;

            // List-relationer: Spara bara ID-listor!
            computer.GPUIds = computerDTO.GPUIds?.ToList() ?? new();
            computer.RAMIds = computerDTO.RAMIds?.ToList() ?? new();
            computer.StorageIds = computerDTO.StorageIds?.ToList() ?? new();
            computer.CaseFanIds = computerDTO.CaseFanIds?.ToList() ?? new();
            computer.MonitorIds = computerDTO.MonitorIds?.ToList() ?? new();
            computer.SpeakerIds = computerDTO.SpeakerIds?.ToList() ?? new();

            _context.Computers.Add(computer);
            await _context.SaveChangesAsync();

            response.IsSuccess = true;
            response.Result = new ComputerDTO { Id = computer.Id, Name = computer.Name };
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

            var computer = await _context.Computers.FindAsync(id);

            if (computer == null)
            {
                response.IsSuccess = false;
                response.Result = "Computer not found";
                return response;
            }

            if (!string.IsNullOrWhiteSpace(computerDTO.Name))
                computer.Name = computerDTO.Name;

            computer.CPUId = computerDTO.CPUId;
            computer.PSUId = computerDTO.PSUId;
            computer.MotherboardId = computerDTO.MotherboardId;
            computer.CaseId = computerDTO.CaseId;
            computer.CpuCoolerId = computerDTO.CpuCoolerId;
            computer.KeyboardId = computerDTO.KeyboardId;
            computer.MouseId = computerDTO.MouseId;
            computer.HeadsetId = computerDTO.HeadsetId;

            computer.GPUIds = computerDTO.GPUIds?.ToList() ?? new();
            computer.RAMIds = computerDTO.RAMIds?.ToList() ?? new();
            computer.StorageIds = computerDTO.StorageIds?.ToList() ?? new();
            computer.CaseFanIds = computerDTO.CaseFanIds?.ToList() ?? new();
            computer.MonitorIds = computerDTO.MonitorIds?.ToList() ?? new();
            computer.SpeakerIds = computerDTO.SpeakerIds?.ToList() ?? new();

            await _computerRepository.SaveUpdatesAsync(computer);

            response.IsSuccess = true;
            response.Result = new ComputerDTO { Id = computer.Id, Name = computer.Name };
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
            var computer = await _context.Computers.FindAsync(id);
            if (computer == null)
            {
                response.IsSuccess = false;
                response.Result = "Computer not found";
                return response;
            }

            _context.Computers.Remove(computer);
            await _context.SaveChangesAsync();

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