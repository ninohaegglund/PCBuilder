using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.ComponentsAPI.Models.DTO.Response;
using PCBuilder.Services.ComponentsAPI.DTOs;
using PCBuilder.Services.ComponentsAPI.Models;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cables;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cables.PCIe;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.Cooling;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.IO.Speakers;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.RAM;
using PCBuilder.Services.ComponentsAPI.Models.ComputerParts.StorageDevice;

namespace PCBuilder.Service.ComponentsAPI.Services;

public class ComputerService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ComputerService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Computer BuildComputerFromDTO(ComputerDTO computerDTO)
    {
        var computer = _mapper.Map<Computer>(computerDTO);
        if (computerDTO.GPUIds != null && computerDTO.GPUIds.Any())
        {
            computer.GPU = _context.GPUs.Where(g => computerDTO.GPUIds.Contains(g.Id)).ToList();
        }
        if (computerDTO.RAMIds != null && computerDTO.RAMIds.Any())
        {
            computer.RamModules = _context.RAMModules.Where(r => computerDTO.RAMIds.Contains(r.Id)).ToList();
        }
        if (computerDTO.StorageIds != null && computerDTO.StorageIds.Any())
        {       
            computer.Storage = _context.Storages.Where(s => computerDTO.StorageIds.Contains(s.Id)).ToList();
        }
        if (computerDTO.CaseFanIds != null && computerDTO.CaseFanIds.Any())
        {
            computer.CaseFans = _context.ChassiCooling.Where(f => computerDTO.CaseFanIds.Contains(f.Id)).ToList();
        }
        if (computerDTO.PCIeCableIds != null && computerDTO.PCIeCableIds.Any())
        {
            computer.PCIeCables = _context.PCIeCables.Where(c => computerDTO.PCIeCableIds.Contains(c.Id)).ToList();
        }
        if (computerDTO.PowerCableIds != null && computerDTO.PowerCableIds.Any())
        {
            computer.PowerCables = _context.PowerCables.Where(c => computerDTO.PowerCableIds.Contains(c.Id)).ToList();
        }
        if (computerDTO.SataCableIds != null && computerDTO.SataCableIds.Any())
        {
            computer.SataCables = _context.SataCables.Where(c => computerDTO.SataCableIds.Contains(c.Id)).ToList();
        }
        if (computerDTO.MonitorIds != null && computerDTO.MonitorIds.Any())
        {
            computer.Monitor = _context.Monitors.Where(m => computerDTO.MonitorIds.Contains(m.Id)).ToList();
        }
        if (computerDTO.SpeakerIds != null && computerDTO.SpeakerIds.Any())
        {
            computer.Speakers = _context.Speakers.Where(s => computerDTO.SpeakerIds.Contains(s.Id)).ToList();
        }

        return computer;
    }

    public async Task<ResponseDTO> GetAllComputersAsync()
    {
        try
        {
            var computers = await _context.Computers
                .Include(c => c.Cpu)
                .Include(c => c.PSU)
                .Include(c => c.Motherboard)
                .Include(c => c.Case)
                .Include(c => c.CPUCooler)
                .Include(c => c.Keyboard)
                .Include(c => c.Mouse)
                .Include(c => c.Headset)
                .Include(c => c.GPU)
                .Include(c => c.RamModules)
                .Include(c => c.Storage)
                .Include(c => c.CaseFans)
                .Include(c => c.PCIeCables)
                .Include(c => c.PowerCables)
                .Include(c => c.SataCables)
                .Include(c => c.Monitor)
                .Include(c => c.Speakers)
                .ToListAsync();

            var dtoList = computers.Select(computer => new ComputerDTO
            {
                Id = computer.Id,
                Name = computer.Name,
                CPUId = computer.CPUId,
                CPUName = computer.Cpu?.ModelName,
                PSUId = computer.PSUId,
                PSUName = computer.PSU?.ModelName,
                MotherboardId = computer.MotherboardId,
                MotherboardName = computer.Motherboard?.ModelName,
                CaseId = computer.CaseId,
                CaseName = computer.Case?.ModelName,
                CpuCoolerId = computer.CpuCoolerId,
                CPUCoolerName = computer.CPUCooler?.ModelName,
                KeyboardId = computer.KeyboardId,
                KeyboardName = computer.Keyboard?.ModelName,
                MouseId = computer.MouseId,
                MouseName = computer.Mouse?.ModelName,
                HeadsetId = computer.HeadsetId,
                HeadsetName = computer.Headset?.ModelName,
                GPUIds = computer.GPU.Select(g => g.Id).ToList(),
                GPUNames = computer.GPU.Select(g => g.ModelName).ToList(),
                RAMIds = computer.RamModules.Select(r => r.Id).ToList(),
                RAMNames = computer.RamModules.Select(r => r.ModelName).ToList(),
                StorageIds = computer.Storage.Select(s => s.Id).ToList(),
                StorageNames = computer.Storage.Select(s => s.ModelName).ToList(),
                CaseFanIds = computer.CaseFans.Select(f => f.Id).ToList(),
                CaseFanNames = computer.CaseFans.Select(f => f.ModelName).ToList(),
                PCIeCableIds = computer.PCIeCables.Select(pc => pc.Id).ToList(),
                PowerCableIds = computer.PowerCables.Select(pc => pc.Id).ToList(),
                SataCableIds = computer.SataCables.Select(sc => sc.Id).ToList(),
                MonitorIds = computer.Monitor.Select(m => m.Id).ToList(),
                MonitorNames = computer.Monitor.Select(m => m.ModelName).ToList(),
                SpeakerIds = computer.Speakers.Select(s => s.Id).ToList(),
                SpeakerNames = computer.Speakers.Select(s => s.ModelName).ToList()
            }).ToList();

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
            var computer = await _context.Computers
                .Include(c => c.Cpu)
                .Include(c => c.PSU)
                .Include(c => c.Motherboard)
                .Include(c => c.Case)
                .Include(c => c.CPUCooler)
                .Include(c => c.Keyboard)
                .Include(c => c.Mouse)
                .Include(c => c.Headset)
                .Include(c => c.GPU)
                .Include(c => c.RamModules)
                .Include(c => c.Storage)
                .Include(c => c.CaseFans)
                .Include(c => c.PCIeCables)
                .Include(c => c.PowerCables)
                .Include(c => c.SataCables)
                .Include(c => c.Monitor)
                .Include(c => c.Speakers)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (computer == null)
                return new ResponseDTO { IsSuccess = false, Result = "Computer not found" };

            var dto = new ComputerDTO
            {
                Id = computer.Id,
                Name = computer.Name,
                CPUId = computer.CPUId,
                CPUName = computer.Cpu?.ModelName,
                PSUId = computer.PSUId,
                PSUName = computer.PSU?.ModelName,
                MotherboardId = computer.MotherboardId,
                MotherboardName = computer.Motherboard?.ModelName,
                CaseId = computer.CaseId,
                CaseName = computer.Case?.ModelName,
                CpuCoolerId = computer.CpuCoolerId,
                CPUCoolerName = computer.CPUCooler?.ModelName,
                KeyboardId = computer.KeyboardId,
                KeyboardName = computer.Keyboard?.ModelName,
                MouseId = computer.MouseId,
                MouseName = computer.Mouse?.ModelName,
                HeadsetId = computer.HeadsetId,
                HeadsetName = computer.Headset?.ModelName,
                GPUIds = computer.GPU.Select(g => g.Id).ToList(),
                GPUNames = computer.GPU.Select(g => g.ModelName).ToList(),
                RAMIds = computer.RamModules.Select(r => r.Id).ToList(),
                RAMNames = computer.RamModules.Select(r => r.ModelName).ToList(),
                StorageIds = computer.Storage.Select(s => s.Id).ToList(),
                StorageNames = computer.Storage.Select(s => s.ModelName).ToList(),
                CaseFanIds = computer.CaseFans.Select(f => f.Id).ToList(),
                CaseFanNames = computer.CaseFans.Select(f => f.ModelName).ToList(),
                PCIeCableIds = computer.PCIeCables.Select(pc => pc.Id).ToList(),
                PowerCableIds = computer.PowerCables.Select(pc => pc.Id).ToList(),
                SataCableIds = computer.SataCables.Select(sc => sc.Id).ToList(),
                MonitorIds = computer.Monitor.Select(m => m.Id).ToList(),
                MonitorNames = computer.Monitor.Select(m => m.ModelName).ToList(),
                SpeakerIds = computer.Speakers.Select(s => s.Id).ToList(),
                SpeakerNames = computer.Speakers.Select(s => s.ModelName).ToList()
            };

            return new ResponseDTO { IsSuccess = true, Result = dto };
        }
        catch (Exception ex)
        {
            return new ResponseDTO { IsSuccess = false, Result = ex.Message };
        }
    }

    public async Task<ResponseDTO> GetComputerByNameAsync(string name)
    {
        try
        {
            var computer = await _context.Computers
                .Include(c => c.Cpu)
                .Include(c => c.PSU)
                .Include(c => c.Motherboard)
                .Include(c => c.Case)
                .Include(c => c.CPUCooler)
                .Include(c => c.Keyboard)
                .Include(c => c.Mouse)
                .Include(c => c.Headset)
                .Include(c => c.GPU)
                .Include(c => c.RamModules)
                .Include(c => c.Storage)
                .Include(c => c.CaseFans)
                .Include(c => c.PCIeCables)
                .Include(c => c.PowerCables)
                .Include(c => c.SataCables)
                .Include(c => c.Monitor)
                .Include(c => c.Speakers)
                .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());

            if (computer == null)
                return new ResponseDTO { IsSuccess = false, Result = "Computer not found" };

            var dto = new ComputerDTO
            {
                Id = computer.Id,
                Name = computer.Name,
                CPUId = computer.CPUId,
                CPUName = computer.Cpu?.ModelName,
                PSUId = computer.PSUId,
                PSUName = computer.PSU?.ModelName,
                MotherboardId = computer.MotherboardId,
                MotherboardName = computer.Motherboard?.ModelName,
                CaseId = computer.CaseId,
                CaseName = computer.Case?.ModelName,
                CpuCoolerId = computer.CpuCoolerId,
                CPUCoolerName = computer.CPUCooler?.ModelName,
                KeyboardId = computer.KeyboardId,
                KeyboardName = computer.Keyboard?.ModelName,
                MouseId = computer.MouseId,
                MouseName = computer.Mouse?.ModelName,
                HeadsetId = computer.HeadsetId,
                HeadsetName = computer.Headset?.ModelName,
                GPUIds = computer.GPU.Select(g => g.Id).ToList(),
                GPUNames = computer.GPU.Select(g => g.ModelName).ToList(),
                RAMIds = computer.RamModules.Select(r => r.Id).ToList(),
                RAMNames = computer.RamModules.Select(r => r.ModelName).ToList(),
                StorageIds = computer.Storage.Select(s => s.Id).ToList(),
                StorageNames = computer.Storage.Select(s => s.ModelName).ToList(),
                CaseFanIds = computer.CaseFans.Select(f => f.Id).ToList(),
                CaseFanNames = computer.CaseFans.Select(f => f.ModelName).ToList(),
                PCIeCableIds = computer.PCIeCables.Select(pc => pc.Id).ToList(),
                PowerCableIds = computer.PowerCables.Select(pc => pc.Id).ToList(),
                SataCableIds = computer.SataCables.Select(sc => sc.Id).ToList(),
                MonitorIds = computer.Monitor.Select(m => m.Id).ToList(),
                MonitorNames = computer.Monitor.Select(m => m.ModelName).ToList(),
                SpeakerIds = computer.Speakers.Select(s => s.Id).ToList(),
                SpeakerNames = computer.Speakers.Select(s => s.ModelName).ToList()
            };

            return new ResponseDTO { IsSuccess = true, Result = dto };
        }
        catch (Exception ex)
        {
            return new ResponseDTO { IsSuccess = false, Result = ex.Message };
        }
    }

    public async Task<ResponseDTO> CreateComputerAsync(ComputerDTO computerDTO)
    {
        var response = new ResponseDTO();
        try
        {
            var computer = new Computer
            {
                Name = computerDTO.Name,
                CPUId = computerDTO.CPUId,
                PSUId = computerDTO.PSUId,
                MotherboardId = computerDTO.MotherboardId,
                CaseId = computerDTO.CaseId,
                CpuCoolerId = computerDTO.CpuCoolerId,
                KeyboardId = computerDTO.KeyboardId,
                MouseId = computerDTO.MouseId,
                HeadsetId = computerDTO.HeadsetId
            };

            if (computerDTO.GPUIds?.Any() == true)
                computer.GPU = await _context.GPUs.Where(g => computerDTO.GPUIds.Contains(g.Id)).ToListAsync();
            if (computerDTO.RAMIds?.Any() == true)
                computer.RamModules = await _context.RAMModules.Where(r => computerDTO.RAMIds.Contains(r.Id)).ToListAsync();
            if (computerDTO.StorageIds?.Any() == true)
                computer.Storage = await _context.Storages.Where(s => computerDTO.StorageIds.Contains(s.Id)).ToListAsync();
            if (computerDTO.CaseFanIds?.Any() == true)
                computer.CaseFans = await _context.ChassiCooling.Where(f => computerDTO.CaseFanIds.Contains(f.Id)).ToListAsync();
            if (computerDTO.PCIeCableIds?.Any() == true)
                computer.PCIeCables = await _context.PCIeCables.Where(c => computerDTO.PCIeCableIds.Contains(c.Id)).ToListAsync();
            if (computerDTO.PowerCableIds?.Any() == true)
                computer.PowerCables = await _context.PowerCables.Where(c => computerDTO.PowerCableIds.Contains(c.Id)).ToListAsync();
            if (computerDTO.SataCableIds?.Any() == true)
                computer.SataCables = await _context.SataCables.Where(c => computerDTO.SataCableIds.Contains(c.Id)).ToListAsync();
            if (computerDTO.MonitorIds?.Any() == true)
                computer.Monitor = await _context.Monitors.Where(m => computerDTO.MonitorIds.Contains(m.Id)).ToListAsync();
            if (computerDTO.SpeakerIds?.Any() == true)
                computer.Speakers = await _context.Speakers.Where(s => computerDTO.SpeakerIds.Contains(s.Id)).ToListAsync();

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

    public async Task<ResponseDTO> UpdateComputerAsync(int id, ComputerDTO computerDTO)
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

            var computer = await _context.Computers
                .Include(c => c.GPU)
                .Include(c => c.RamModules)
                .Include(c => c.Storage)
                .Include(c => c.CaseFans)
                .Include(c => c.PCIeCables)
                .Include(c => c.PowerCables)
                .Include(c => c.SataCables)
                .Include(c => c.Monitor)
                .Include(c => c.Speakers)
                .FirstOrDefaultAsync(u => u.Id == id);

            if (computer == null)
            {
                response.IsSuccess = false;
                response.Result = "Computer not found";
                return response;
            }

            computer.Name = computerDTO.Name;
            computer.CPUId = computerDTO.CPUId;
            computer.PSUId = computerDTO.PSUId;
            computer.MotherboardId = computerDTO.MotherboardId;
            computer.CaseId = computerDTO.CaseId;
            computer.CpuCoolerId = computerDTO.CpuCoolerId;
            computer.KeyboardId = computerDTO.KeyboardId;
            computer.MouseId = computerDTO.MouseId;
            computer.HeadsetId = computerDTO.HeadsetId;

            computer.GPU = computerDTO.GPUIds?.Any() == true ?
                await _context.GPUs.Where(g => computerDTO.GPUIds.Contains(g.Id)).ToListAsync() : new List<GPU>();
            computer.RamModules = computerDTO.RAMIds?.Any() == true ?
                await _context.RAMModules.Where(r => computerDTO.RAMIds.Contains(r.Id)).ToListAsync() : new List<RAM>();
            computer.Storage = computerDTO.StorageIds?.Any() == true ?
                await _context.Storages.Where(s => computerDTO.StorageIds.Contains(s.Id)).ToListAsync() : new List<StorageDevice>();
            computer.CaseFans = computerDTO.CaseFanIds?.Any() == true ?
                await _context.ChassiCooling.Where(f => computerDTO.CaseFanIds.Contains(f.Id)).ToListAsync() : new List<ChassiCooling>();
            computer.PCIeCables = computerDTO.PCIeCableIds?.Any() == true ?
                await _context.PCIeCables.Where(c => computerDTO.PCIeCableIds.Contains(c.Id)).ToListAsync() : new List<PCIeCable>();
            computer.PowerCables = computerDTO.PowerCableIds?.Any() == true ?
                await _context.PowerCables.Where(c => computerDTO.PowerCableIds.Contains(c.Id)).ToListAsync() : new List<PowerCable>();
            computer.SataCables = computerDTO.SataCableIds?.Any() == true ?
                await _context.SataCables.Where(c => computerDTO.SataCableIds.Contains(c.Id)).ToListAsync() : new List<SataCable>();
            computer.Monitor = computerDTO.MonitorIds?.Any() == true ?
                await _context.Monitors.Where(m => computerDTO.MonitorIds.Contains(m.Id)).ToListAsync() : new List<DisplayMonitor>();
            computer.Speakers = computerDTO.SpeakerIds?.Any() == true ?
                await _context.Speakers.Where(s => computerDTO.SpeakerIds.Contains(s.Id)).ToListAsync() : new List<Speaker>();

            _context.Computers.Update(computer);
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
