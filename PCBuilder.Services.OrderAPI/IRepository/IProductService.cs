using PCBuilder.Services.OrderAPI.Models.Dto;

namespace PCBuilder.Services.OrderAPI.IRepository
{
    public interface IProductService
    {
        Task<ProductDto?> CreateProductAsync(ProductDto dto);
        Task<bool> DeleteProductAsync(int id);
        Task<IEnumerable<ProductDto>> GetAllProductAsync();
        Task<ProductDto> GetProductByIdAsync(int id);
    }
}