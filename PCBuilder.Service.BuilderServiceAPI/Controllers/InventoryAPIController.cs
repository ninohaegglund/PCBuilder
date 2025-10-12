using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.Models;
using PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.Data;

namespace PCBuilder.Service.BuilderServiceAPI.Controllers;

[Route("api/inventory")]
[ApiController]
public class InventoryAPIController : Controller
{
    private readonly PcDataContext _db;
    private ResponseDTO _response;
    private IMapper _mapper;

    public InventoryAPIController(PcDataContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
        _response = new ResponseDTO();
    }

    [HttpGet]
    public ResponseDTO GetAll()
    {
        try
        {
            IEnumerable<Inventory> objList = _db.Inventories.ToList();
            _response.Result = _mapper.Map<IEnumerable<InventoryDTO>>(objList);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;

        }
        return _response;
    }


    [HttpGet]
    [Route("{id:int}")]
    public ResponseDTO Get(int id)
    {
        try
        {
            Inventory obj = _db.Inventories.First(u => u.Id == id);
            _response.Result = _mapper.Map<InventoryDTO>(obj);

        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;

        }
        return _response;
    }
    [HttpGet]
    [Route("GetByName/{name}")]
    public ResponseDTO GetByName(string code)
    {
        try
        {
            Inventory obj = _db.Inventories.First(u => u.InventoryName.ToLower() == code.ToLower());
            _response.Result = _mapper.Map<InventoryDTO>(obj);

        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;

        }
        return _response;
    }

    [HttpPost]
    public ResponseDTO Post([FromBody] InventoryDTO inventoryDto)
    {
        try
        {
            Inventory obj = _mapper.Map<Inventory>(inventoryDto);
            _db.Inventories.Add(obj);
            _db.SaveChanges();

            _response.Result = _mapper.Map<InventoryDTO>(obj);

        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;

        }
        return _response;
    }

    [HttpPut]
    public ResponseDTO Put([FromBody] InventoryDTO inventoryDto)
    {
        try
        {
            Inventory obj = _mapper.Map<Inventory>(inventoryDto);
            _db.Inventories.Update(obj);
            _db.SaveChanges();

            _response.Result = _mapper.Map<InventoryDTO>(obj);

        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;

        }
        return _response;
    }

    [HttpDelete]
    [Route("{id:int}")]
    public ResponseDTO Delete(int id)
    {
        try
        {
            Inventory obj = _db.Inventories.First(u => u.Id == id);
            _db.Inventories.Remove(obj);
            _db.SaveChanges();

        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;

        }
        return _response;
    }

}
