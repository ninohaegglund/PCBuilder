using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.ComponentsAPI.Models.DTO.Response;
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
    }
}
