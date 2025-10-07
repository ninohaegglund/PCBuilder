using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.ComponentsAPI.Models.DTO.Response;
using PCBuilder.Service.ComponentsAPI.Services.IService;
using PCBuilder.Services.ComponentsAPI.DTOs;
using PCBuilder.Services.ComponentsAPI.Models;


namespace PCBuilder.Service.ComponentsAPI.Services;

public class ComputerService : IComputerService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public ComputerService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    private async Task<List<T>> GetEntitiesByIdsAsync<T>(DbSet<T> dbSet, IEnumerable<int> ids) where T : class
    {
        return ids != null && ids.Any() ? await dbSet.Where(e => ids.Contains(EF.Property<int>(e, "Id"))).ToListAsync() : new List<T>();
    }

    private Computer BuildComputerFromDTO(ComputerDTO computerDTO)
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

            // 1-1 relationer (sätt bara om != null)
            if (computerDTO.CPUId != null)
                computer.CPUId = computerDTO.CPUId;

            if (computerDTO.PSUId != null)
                computer.PSUId = computerDTO.PSUId;

            if (computerDTO.MotherboardId != null)
                computer.MotherboardId = computerDTO.MotherboardId;

            if (computerDTO.CaseId != null)
                computer.CaseId = computerDTO.CaseId;

            if (computerDTO.CpuCoolerId != null)
                computer.CpuCoolerId = computerDTO.CpuCoolerId;

            if (computerDTO.KeyboardId != null)
                computer.KeyboardId = computerDTO.KeyboardId;

            if (computerDTO.MouseId != null)
                computer.MouseId = computerDTO.MouseId;

            if (computerDTO.HeadsetId != null)
                computer.HeadsetId = computerDTO.HeadsetId;

            if (computerDTO.GPUIds != null)
            {
                computer.GPU = await GetEntitiesByIdsAsync(_context.GPUs, computerDTO.GPUIds);
                foreach (var gpu in computer.GPU) { gpu.Computer = computer; }
            }

            if (computerDTO.RAMIds != null)
            {
                computer.RamModules = await GetEntitiesByIdsAsync(_context.RAMModules, computerDTO.RAMIds);
                foreach (var ram in computer.RamModules) { ram.Computer = computer; }
            }

            if (computerDTO.StorageIds != null)
            {
                computer.Storage = await GetEntitiesByIdsAsync(_context.Storages, computerDTO.StorageIds);
                foreach (var storage in computer.Storage) { storage.Computer = computer; }
            }

            if (computerDTO.CaseFanIds != null)
            {
                computer.CaseFans = await GetEntitiesByIdsAsync(_context.ChassiCooling, computerDTO.CaseFanIds);
                foreach (var fan in computer.CaseFans) { fan.Computer = computer; }
            }

            if (computerDTO.PCIeCableIds != null)
            {
                computer.PCIeCables = await GetEntitiesByIdsAsync(_context.PCIeCables, computerDTO.PCIeCableIds);
                foreach (var pcie in computer.PCIeCables) { pcie.Computer = computer; }
            }

            if (computerDTO.PowerCableIds != null)
            {
                computer.PowerCables = await GetEntitiesByIdsAsync(_context.PowerCables, computerDTO.PowerCableIds);
                foreach (var power in computer.PowerCables) { power.Computer = computer; }
            }

            if (computerDTO.SataCableIds != null)
            {
                computer.SataCables = await GetEntitiesByIdsAsync(_context.SataCables, computerDTO.SataCableIds);
                foreach (var sata in computer.SataCables) { sata.Computer = computer; }
            }

            if (computerDTO.MonitorIds != null)
            {
                computer.Monitor = await GetEntitiesByIdsAsync(_context.Monitors, computerDTO.MonitorIds);
                foreach (var monitor in computer.Monitor) { monitor.Computer = computer; }
            }

            if (computerDTO.SpeakerIds != null)
            {
                computer.Speakers = await GetEntitiesByIdsAsync(_context.Speakers, computerDTO.SpeakerIds);
                foreach (var speaker in computer.Speakers) { speaker.Computer = computer; }
            }

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

            if (!string.IsNullOrWhiteSpace(computerDTO.Name))
                computer.Name = computerDTO.Name;

            if (computerDTO.CPUId != null)
                computer.CPUId = computerDTO.CPUId;

            if (computerDTO.PSUId != null)
                computer.PSUId = computerDTO.PSUId;

            if (computerDTO.MotherboardId != null)
                computer.MotherboardId = computerDTO.MotherboardId;

            if (computerDTO.CaseId != null)
                computer.CaseId = computerDTO.CaseId;

            if (computerDTO.CpuCoolerId != null)
                computer.CpuCoolerId = computerDTO.CpuCoolerId;

            if (computerDTO.KeyboardId != null)
                computer.KeyboardId = computerDTO.KeyboardId;

            if (computerDTO.MouseId != null)
                computer.MouseId = computerDTO.MouseId;

            if (computerDTO.HeadsetId != null)
                computer.HeadsetId = computerDTO.HeadsetId;

            async Task UpdateComponentList<T>(
                List<T> currentList,
                DbSet<T> dbSet,
                List<int>? newIds,
                Action<T> setComputerReference) where T : class
            {
                if (newIds == null)
                    return;

                currentList.Clear();

                if (newIds.Any())
                {
                    var newEntities = await GetEntitiesByIdsAsync(dbSet, newIds);
                    foreach (var entity in newEntities)
                    {
                        setComputerReference(entity);
                        currentList.Add(entity);
                    }
                }
            }

            await UpdateComponentList(computer.GPU, _context.GPUs, computerDTO.GPUIds, gpu => ((dynamic)gpu).Computer = computer);
            await UpdateComponentList(computer.RamModules, _context.RAMModules, computerDTO.RAMIds, ram => ((dynamic)ram).Computer = computer);
            await UpdateComponentList(computer.Storage, _context.Storages, computerDTO.StorageIds, storage => ((dynamic)storage).Computer = computer);
            await UpdateComponentList(computer.CaseFans, _context.ChassiCooling, computerDTO.CaseFanIds, fan => ((dynamic)fan).Computer = computer);
            await UpdateComponentList(computer.PCIeCables, _context.PCIeCables, computerDTO.PCIeCableIds, pcie => ((dynamic)pcie).Computer = computer);
            await UpdateComponentList(computer.PowerCables, _context.PowerCables, computerDTO.PowerCableIds, power => ((dynamic)power).Computer = computer);
            await UpdateComponentList(computer.SataCables, _context.SataCables, computerDTO.SataCableIds, sata => ((dynamic)sata).Computer = computer);
            await UpdateComponentList(computer.Monitor, _context.Monitors, computerDTO.MonitorIds, monitor => ((dynamic)monitor).Computer = computer);
            await UpdateComponentList(computer.Speakers, _context.Speakers, computerDTO.SpeakerIds, speaker => ((dynamic)speaker).Computer = computer);

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

    private static void MapComputerDtoToEntity(ComputerCreateDTO computerDTO, Computer computer)
    {
        computer.Name = computerDTO.Name;
        computer.CPUId = computerDTO.CPUId;
        computer.PSUId = computerDTO.PSUId;
        computer.MotherboardId = computerDTO.MotherboardId;
        computer.CaseId = computerDTO.CaseId;
        computer.CpuCoolerId = computerDTO.CpuCoolerId;
        computer.KeyboardId = computerDTO.KeyboardId;
        computer.MouseId = computerDTO.MouseId;
        computer.HeadsetId = computerDTO.HeadsetId;
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
