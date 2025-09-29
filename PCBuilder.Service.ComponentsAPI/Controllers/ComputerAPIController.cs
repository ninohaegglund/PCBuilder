using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Service.ComponentsAPI.Models.DTO.Response;
using PCBuilder.Services.ComponentsAPI.DTOs;
using PCBuilder.Services.ComponentsAPI.Models;

namespace PCBuilder.Service.ComponentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputerAPIController : ControllerBase
    {
        private readonly DataContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;
        public ComputerAPIController(DataContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDTO();
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ResponseDTO> Get()
        {
            try
            {
                var computers = await _db.Computers
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

        [HttpGet("{id:int}")]
        public async Task<ResponseDTO> Get(int id)
        {
            try
            {
                var computer = await _db.Computers
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

        [HttpGet("GetByName/{name}")]
        public async Task<ResponseDTO> GetByName(string name)
        {
            try
            {
                var computer = await _db.Computers
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


        [HttpPost]
        public ResponseDTO CreateComputer([FromBody] ComputerDTO computerDTO)
        {
            try
            {
                Computer computer = _mapper.Map<Computer>(computerDTO);
                _db.Computers.Add(computer);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ComputerDTO>(computer);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = ex.Message + (ex.InnerException != null ? " | Inner: " + ex.InnerException.Message : "");
            }
            return _response;
        }

        [HttpPut("{id:int}")]
        public ResponseDTO UpdateComputer(int id, [FromBody] ComputerDTO computerDTO)
        {
            try
            {
                if (id != computerDTO.Id)
                {
                    _response.IsSuccess = false;
                    _response.Result = "Computer ID mismatch";
                    return _response;
                }

                var computer = _db.Computers.FirstOrDefault(u => u.Id == id);
                if (computer == null)
                {
                    _response.IsSuccess = false;
                    _response.Result = "Computer not found";
                    return _response;
                }

                _mapper.Map(computerDTO, computer);
                _db.Computers.Update(computer);
                _db.SaveChanges();

                _response.Result = _mapper.Map<ComputerDTO>(computer);
            }

            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = ex.Message;
            }
            return _response;
        }


        [HttpDelete("{id:int}")]
        public ResponseDTO DeleteComputer(int id)
        {
            try
            {
                var computer = _db.Computers.FirstOrDefault(u => u.Id == id);
                if (computer == null)
                {
                    _response.IsSuccess = false;
                    _response.Result = "Computer not found";
                    return _response;
                }

                _db.Computers.Remove(computer);
                _db.SaveChanges();

                _response.Result = "Computer deleted successfully";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = ex.Message;
            }
            return _response;
        }
    }
}

