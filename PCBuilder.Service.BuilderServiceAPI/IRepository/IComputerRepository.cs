using PCBuilder.Service.BuilderServiceAPI.Models;

namespace PCBuilder.Service.BuilderServiceAPI.IRepository
{
    public interface IBuiltComputersRepository
    {
        Task<List<Computer>> GetAllAsync();
        Task<Computer?> GetByIdAsync(int id);
        Task AddAsync(Computer computer);
        Task UpdateAsync(Computer computer);
        Task DeleteAsync(Computer computer);
        Task<int> CountAsync();
    }
}
