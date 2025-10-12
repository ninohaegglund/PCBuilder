using PCBuilder.Service.BuilderServiceAPI.Models;

namespace PCBuilder.Service.BuilderServiceAPI.IRepository
{
    public interface IBuiltComputersRepository
    {
        Task SaveComputerAsync(Computer computer);
        Task SaveUpdatesAsync(Computer computer);
    }
}