using PCBuilder.Service.ComponentsAPI.Models.DTO;

namespace PCBuilder.Service.ComponentsAPI.Services.IService
{
    public interface IComponentService
    {
        Task<IEnumerable<CPUDto>> GetAllCPUsAsync();
        Task<IEnumerable<PSUDTO>> GetAllPSUsAsync();
    }
}