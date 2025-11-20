using PCBuilder.Service.ComponentsAPI.Models.DTOs;

namespace PCBuilder.Service.ComponentsAPI.Interfaces
{
    public interface IComponentService
    {
        Task<AllComponentsDto> GetAllComponentsAsync();

        Task<TDto?> GetByIdAsync<TDto>(int id);
        Task<List<TDto>> GetAllAsync<TDto>();

        Task<List<ManufacturerDto>> GetAllManufacturersAsync();
    }
}