using PCBuilder.Service.ComponentsAPI.Models.DTO.Response;

namespace PCBuilder.Service.ComponentsAPI.Services.IService;

public interface IComputerService
{
    Task<ResponseDTO> CreateComputerAsync(ComputerCreateDTO computerDTO);
    Task<ResponseDTO> DeleteComputerAsync(int id);
    Task<ResponseDTO> GetAllComputersAsync();
    Task<ResponseDTO> GetComputerByIdAsync(int id);
    Task<ResponseDTO> GetComputerByNameAsync(string name);
    Task<ResponseDTO> UpdateComputerAsync(int id, ComputerCreateDTO computerDTO);
}