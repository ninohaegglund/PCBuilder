using System.Collections.Generic;
using System.Threading.Tasks;

namespace PCBuilder.Service.ComponentsAPI.IRepositories
{
    public interface IComponentRepository
    {
        Task<T?> GetByIdAsync<T>(int id) where T : class;
        Task<List<T>> GetAllAsync<T>() where T : class;
    }
}