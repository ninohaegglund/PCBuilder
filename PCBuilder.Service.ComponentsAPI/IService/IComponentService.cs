using PCBuilder.Service.ComponentsAPI.Models;
using PCBuilder.Service.ComponentsAPI.Models.DTOs;

namespace PCBuilder.Service.ComponentsAPI.Interfaces
{
    public interface IComponentService
    {
        Task<T?> GetByIdAsync<T>(int id) where T : class;
        Task<List<T>> GetAllAsync<T>() where T : class;

        Task<AllComponentsDto> GetAllComponentsAsync();

        Task<List<ManufacturerDto>> GetAllManufacturersAsync();
        Task<List<FormFactor>> GetAllFormFactorsAsync();
    }
}