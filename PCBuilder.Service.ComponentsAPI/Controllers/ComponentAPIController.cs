using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.ComponentsAPI.Models.DTO.Response;
using PCBuilder.Services.ComponentsAPI.DTOs;
using PCBuilder.Services.ComponentsAPI.Models;

namespace PCBuilder.Service.ComponentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentAPIController : ControllerBase
    {
        private readonly DataContext _db;
        private ResponseDTO _response;

        public ComponentAPIController(DataContext db)
        {
            _db = db;
            _response = new ResponseDTO();
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Computer> Computers = _db.Computers.ToList();
                _response.Result = Computers;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ResponseDTO Get(int id)
        {
            try
            {
                Computer Computers = _db.Computers.First(u=>u.Id==id);
                ComputerDTO computerDTO = new ComputerDTO()
                {
                    Id = Computers.Id,
                    CPUId = Computers.CPUId,
                    CPUName = Computers.Cpu?.ModelName,
                    PSUId = Computers.PSUId,
                    PSUName = Computers.PSU?.ModelName,
                    MotherboardId = Computers.MotherboardId,
                    MotherboardName = Computers.Motherboard?.ModelName,
                    CaseId = Computers.CaseId,
                    CaseName = Computers.Case?.ModelName,
                    CpuCoolerId = Computers.CpuCoolerId,
                    CPUCoolerName = Computers.CPUCooler?.ModelName,
                    KeyboardId = Computers.KeyboardId,
                    KeyboardName = Computers.Keyboard?.ModelName,
                    MouseId = Computers.MouseId,
                    MouseName = Computers.Mouse?.ModelName,
                    HeadsetId = Computers.HeadsetId,
                    HeadsetName = Computers.Headset?.ModelName,
                    GPUIds = Computers.GPU.Select(g => g.Id).ToList(),
                    GPUNames = Computers.GPU.Select(g => g.ModelName).ToList(),
                    RAMIds = Computers.RamModules.Select(r => r.Id).ToList(),
                    RAMNames = Computers.RamModules.Select(r => r.ModelName).ToList(),
                    StorageIds = Computers.Storage.Select(s => s.Id).ToList(),
                    StorageNames = Computers.Storage.Select(s => s.ModelName).ToList(),
                    CaseFanIds = Computers.CaseFans.Select(c => c.Id).ToList(),
                    CaseFanNames = Computers.CaseFans.Select(c => c.ModelName).ToList(),
                    PCIeCableIds = Computers.PCIeCables.Select(p => p.Id).ToList(),
                    PowerCableIds = Computers.PowerCables.Select(p => p.Id).ToList(),
                    SataCableIds = Computers.SataCables.Select(s => s.Id).ToList(),
                    MonitorIds = Computers.Monitor.Select(m => m.Id).ToList(),
                    MonitorNames = Computers.Monitor.Select(m => m.ModelName).ToList(),
                    SpeakerIds = Computers.Speakers.Select(s => s.Id).ToList(),
                    SpeakerNames = Computers.Speakers.Select(s => s.ModelName).ToList()
                };
                _response.Result = computerDTO;
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
