using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Services.OrderAPI.Data;
using PCBuilder.Services.OrderAPI.IRepository;
using PCBuilder.Services.OrderAPI.IService;
using PCBuilder.Services.OrderAPI.Models;
using PCBuilder.Services.OrderAPI.Models.Dto;

namespace PCBuilder.Services.OrderAPI.Controllers;


[Route("api/product")]
[ApiController]
public class ProductAPIController : Controller
{
    private readonly IProductService _productService;
    private readonly ResponseDto _response = new();

    public ProductAPIController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ResponseDto> GetAll()
    {
        try
        {
            _response.Result = await _productService.GetAllProductAsync();
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }


    [HttpGet("{id:int}")]
    public async Task<ResponseDto> Get(int id)
    {
        try
        {
            _response.Result = await _productService.GetProductByIdAsync(id);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }


    [HttpPost]
    public async Task<ResponseDto> Post([FromBody] ProductDto productDto)
    {
        try
        {
            _response.Result = await _productService.CreateProductAsync(productDto);
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
    public async Task<ResponseDto> Delete(int id)
    {
        try
        {
            _response.Result = await _productService.DeleteProductAsync(id);
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.Message = ex.Message;
        }
        return _response;
    }
}
