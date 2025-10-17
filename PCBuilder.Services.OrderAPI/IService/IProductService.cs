using PCBuilder.Services.OrderAPI.Models.Dto;

namespace PCBuilder.Services.OrderAPI.IService
{
    public interface IProductService
    {
        Task<ResponseDto?> CreateProductAsync(ProductDto dto);
        Task<ResponseDto> DeleteProductAsync(int id);
        Task<ResponseDto> GetAllProductAsync();
        Task<ResponseDto> GetProductByIdAsync(int id);
    }
}