using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.BuilderServiceAPI.Models;
using PCBuilder.Service.BuilderServiceAPI.Repository;
using PCBuilder.Service.ComponentsAPI.Models.DTO.Response;
using PCBuilder.Services.ComponentsAPI.DTOs;

namespace PCBuilder.Service.ComponentsAPI.Services;

public class ComputerService : IComputerService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    private readonly IGetComponentsService _componentsService;
    private readonly ComputerRepository _computerRepository;

    public ComputerService(DataContext context, IMapper mapper, IGetComponentsService getComponentsService, ComputerRepository computerRepository)
    {
        _context = context;
        _mapper = mapper;
        _componentsService = getComponentsService;
        _computerRepository = computerRepository;
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

                // Hämta namn från respektive ComponentsAPI
                if (dto.GPUIds != null && dto.GPUIds.Any())
                    dto.GPUNames = (await _componentsService.GetGpusAsync(dto.GPUIds)).Select(g => g.ModelName).ToList();
                if (dto.RAMIds != null && dto.RAMIds.Any())
                    dto.RAMNames = (await _componentsService.GetRamsAsync(dto.RAMIds)).Select(r => r.ModelName).ToList();
                if (dto.StorageIds != null && dto.StorageIds.Any())
                    dto.StorageNames = (await _componentsService.GetStoragesAsync(dto.StorageIds)).Select(s => s.ModelName).ToList();
                if (dto.CaseFanIds != null && dto.CaseFanIds.Any())
                    dto.CaseFanNames = (await _componentsService.GetCaseFansAsync(dto.CaseFanIds)).Select(f => f.ModelName).ToList();
                if (dto.MonitorIds != null && dto.MonitorIds.Any())
                    dto.MonitorNames = (await _componentsService.GetMonitorsAsync(dto.MonitorIds)).Select(m => m.ModelName).ToList();
                if (dto.SpeakerIds != null && dto.SpeakerIds.Any())
                    dto.SpeakerNames = (await _componentsService.GetSpeakersAsync(dto.SpeakerIds)).Select(s => s.ModelName).ToList();

                // Hämta namn för 1-1-komponenter om du vill (frivilligt)
                if (computer.CPUId.HasValue)
                    dto.CPUName = (await _componentsService.GetCpusAsync(new[] { computer.CPUId.Value })).FirstOrDefault()?.ModelName;
                if (computer.PSUId.HasValue)
                    dto.PSUName = (await _componentsService.GetPsusAsync(new[] { computer.PSUId.Value })).FirstOrDefault()?.ModelName;
                if (computer.MotherboardId.HasValue)
                    dto.MotherboardName = (await _componentsService.GetMotherboardsAsync(new[] { computer.MotherboardId.Value })).FirstOrDefault()?.ModelName;
                if (computer.CaseId.HasValue)
                    dto.CaseName = (await _componentsService.GetCasesAsync(new[] { computer.CaseId.Value })).FirstOrDefault()?.ModelName;
                if (computer.CpuCoolerId.HasValue)
                    dto.CPUCoolerName = (await _componentsService.GetCpuCoolersAsync(new[] { computer.CpuCoolerId.Value })).FirstOrDefault()?.ModelName;
                if (computer.KeyboardId.HasValue)
                    dto.KeyboardName = (await _componentsService.GetKeyboardsAsync(new[] { computer.KeyboardId.Value })).FirstOrDefault()?.ModelName;
                if (computer.MouseId.HasValue)
                    dto.MouseName = (await _componentsService.GetMiceAsync(new[] { computer.MouseId.Value })).FirstOrDefault()?.ModelName;
                if (computer.HeadsetId.HasValue)
                    dto.HeadsetName = (await _componentsService.GetHeadsetsAsync(new[] { computer.HeadsetId.Value })).FirstOrDefault()?.ModelName;

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

            // Hämta namn på samma sätt som i GetAllComputersAsync (kan extraheras till hjälpfunktion)
            if (dto.GPUIds != null && dto.GPUIds.Any())
                dto.GPUNames = (await _componentsService.GetGpusAsync(dto.GPUIds)).Select(g => g.ModelName).ToList();
            if (dto.RAMIds != null && dto.RAMIds.Any())
                dto.RAMNames = (await _componentsService.GetRamsAsync(dto.RAMIds)).Select(r => r.ModelName).ToList();
            if (dto.StorageIds != null && dto.StorageIds.Any())
                dto.StorageNames = (await _componentsService.GetStoragesAsync(dto.StorageIds)).Select(s => s.ModelName).ToList();
            if (dto.CaseFanIds != null && dto.CaseFanIds.Any())
                dto.CaseFanNames = (await _componentsService.GetCaseFansAsync(dto.CaseFanIds)).Select(f => f.ModelName).ToList();
            if (dto.MonitorIds != null && dto.MonitorIds.Any())
                dto.MonitorNames = (await _componentsService.GetMonitorsAsync(dto.MonitorIds)).Select(m => m.ModelName).ToList();
            if (dto.SpeakerIds != null && dto.SpeakerIds.Any())
                dto.SpeakerNames = (await _componentsService.GetSpeakersAsync(dto.SpeakerIds)).Select(s => s.ModelName).ToList();

            // 1-1-komponentnamn
            if (computer.CPUId.HasValue)
                dto.CPUName = (await _componentsService.GetCpusAsync(new[] { computer.CPUId.Value })).FirstOrDefault()?.ModelName;
            if (computer.PSUId.HasValue)
                dto.PSUName = (await _componentsService.GetPsusAsync(new[] { computer.PSUId.Value })).FirstOrDefault()?.ModelName;
            if (computer.MotherboardId.HasValue)
                dto.MotherboardName = (await _componentsService.GetMotherboardsAsync(new[] { computer.MotherboardId.Value })).FirstOrDefault()?.ModelName;
            if (computer.CaseId.HasValue)
                dto.CaseName = (await _componentsService.GetCasesAsync(new[] { computer.CaseId.Value })).FirstOrDefault()?.ModelName;
            if (computer.CpuCoolerId.HasValue)
                dto.CPUCoolerName = (await _componentsService.GetCpuCoolersAsync(new[] { computer.CpuCoolerId.Value })).FirstOrDefault()?.ModelName;
            if (computer.KeyboardId.HasValue)
                dto.KeyboardName = (await _componentsService.GetKeyboardsAsync(new[] { computer.KeyboardId.Value })).FirstOrDefault()?.ModelName;
            if (computer.MouseId.HasValue)
                dto.MouseName = (await _componentsService.GetMiceAsync(new[] { computer.MouseId.Value })).FirstOrDefault()?.ModelName;
            if (computer.HeadsetId.HasValue)
                dto.HeadsetName = (await _componentsService.GetHeadsetsAsync(new[] { computer.HeadsetId.Value })).FirstOrDefault()?.ModelName;

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