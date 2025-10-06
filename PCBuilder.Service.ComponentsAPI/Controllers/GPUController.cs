using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.ComponentsAPI.Models.DTO.Response;
using PCBuilder.Services.ComponentsAPI.DTOs;

namespace PCBuilder.Service.ComponentsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GPUController : ControllerBase
    {
        private readonly DataContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;
        public GPUController(DataContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDTO();
            _mapper = mapper;
        }

        [HttpPut("{computerId:int}/add-gpu/{gpuId:int}")]
        public ResponseDTO AddGPUToComputer(int computerId, int gpuId)
        {
            try
            {
                var computer = _db.Computers.FirstOrDefault(c => c.Id == computerId);
                if (computer == null)
                {
                    _response.IsSuccess = false;
                    _response.Result = "Computer not found.";
                }
                var gpu = _db.GPUs.FirstOrDefault(g => g.Id == gpuId); 
                if (gpu == null)
                {
                    _response.IsSuccess = false;
                    _response.Result = "GPU not found.";
                }
                computer.GPU.Add(gpu);
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

        [HttpPut("{id:int}/remove-gpu/{gpuId:int}")]
        public ResponseDTO RemoveGPUFromComputer(int id, int gpuId)
        {
            try
            {
                var computer = _db.Computers.FirstOrDefault(c => c.Id == id);
                if (computer == null)
                {
                    _response.IsSuccess = false;
                    _response.Result = "Computer not found.";
                }
                var gpu = _db.GPUs.FirstOrDefault(g => g.Id == gpuId);
                if (gpu == null)
                {
                    _response.IsSuccess = false;
                    _response.Result = "GPU not found.";
                }
                computer.GPU.Remove(gpu);
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
    }
}
