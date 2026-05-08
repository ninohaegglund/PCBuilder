using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using Contracts;


namespace PCBuilder.Service.BuilderServiceAPI.IService
{
    public interface IComputerService
    {
        Task<ResponseDTO> CreateComputerAsync(ComputerCreateDTO computerDTO);
        Task<ResponseDTO> DeleteComputerAsync(int id);
        Task<ResponseDTO> GetAllComputersAsync();
        Task<ResponseDTO> GetComputerByIdAsync(int? id);
        Task<ResponseDTO> UpdateComputerAsync(int id, ComputerCreateDTO computerDTO);
    }
}