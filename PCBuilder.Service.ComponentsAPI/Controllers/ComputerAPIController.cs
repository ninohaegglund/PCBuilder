using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Computer> Computers = _db.Computers.ToList();
                _response.Result = _mapper.Map<IEnumerable<ComputerDTO>>(Computers);
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
                Computer Computers = _db.Computers.First(u => u.Id == id);
                _response.Result = _mapper.Map<ComputerDTO>(Computers);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("GetByName/{name}")]
        public ResponseDTO GetByName(string name)
        {
            try
            {
                Computer computer = _db.Computers.FirstOrDefault(u => u.Name.ToLower() == name.ToLower());
                if (computer == null)
                {
                    _response.IsSuccess = false;
                }
                _response.Result = _mapper.Map<ComputerDTO>(computer);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Result = ex.Message;
            }
            return _response;
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
                _response.Result = ex.Message;
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

