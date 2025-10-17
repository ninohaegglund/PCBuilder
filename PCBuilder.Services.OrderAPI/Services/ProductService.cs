
using AutoMapper;
using PCBuilder.Services.OrderAPI.IRepository;
using PCBuilder.Services.OrderAPI.IService;
using PCBuilder.Services.OrderAPI.Models;
using PCBuilder.Services.OrderAPI.Models.Dto;
using System.Diagnostics;

namespace PCBuilder.Services.OrderAPI.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDto?> CreateProductAsync(ProductDto dto)
    {
        var response = new ResponseDto();
        try
        {
            ArgumentNullException.ThrowIfNull(dto);

            var entity = _mapper.Map<Product>(dto);
            entity = await _productRepository.AddAsync(entity);
            if (entity == null)
            {
                response.IsSuccess = false;
                response.Message = "Failed to create product.";
                return response;
            }
            response.Result = _mapper.Map<ProductDto>(entity);
        }

        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }
        return response;
    }

    public async Task<ResponseDto> GetAllProductAsync()
    {
        var response = new ResponseDto();
        try
        {

            var entities = await _productRepository.GetAllAsync();
            response.Result = _mapper.Map<IEnumerable<ProductDto>>(entities);

        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }
        return response;
    }

    public async Task<ResponseDto> GetProductByIdAsync(int id)
    {
        var response = new ResponseDto();
        try
        {
            var entity = await _productRepository.GetAsync((x => x.Id == id));
            if (entity == null)
            {
                response.IsSuccess = false;
                response.Message = "Product not found.";
                return response;
            }
            else
            {
                response.Result = _mapper.Map<ProductDto>(entity);
            }
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }
        return response;
    }


    public async Task<ResponseDto> DeleteProductAsync(int id)
    {
        var response = new ResponseDto();
        try
        {
            var entity = await _productRepository.GetAsync(x => x.Id == id);
            if (entity == null)
            {
                response.IsSuccess = false;
                response.Message = "Product not found.";
                return response;
            }
            response.Result = await _productRepository.DeleteAsync(entity);
        }
        catch (Exception ex)
        {
            response.IsSuccess = false;
            response.Message = ex.Message;
        }
        return response;
    }



}
