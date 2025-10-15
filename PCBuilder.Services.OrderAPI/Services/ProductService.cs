
using AutoMapper;
using PCBuilder.Services.OrderAPI.IRepository;
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

    public async Task<ProductDto?> CreateProductAsync(ProductDto dto)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(dto);

            var entity = _mapper.Map<Product>(dto);
            entity = await _productRepository.AddAsync(entity);
            if (entity == null)
                return null;

            return _mapper.Map<ProductDto>(entity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductAsync()
    {
        try
        {

            var entities = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(entities);

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return Enumerable.Empty<ProductDto>();
        }
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        try
        {
            var entity = await _productRepository.GetAsync((x => x.Id == id));
            return _mapper.Map<ProductDto>(entity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }


    public async Task<bool> DeleteProductAsync(int id)
    {
        try
        {
            var entity = await _productRepository.GetAsync(x => x.Id == id);
            if (entity == null)
                return false;
            return await _productRepository.DeleteAsync(entity);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }



}
