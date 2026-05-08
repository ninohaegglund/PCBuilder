

using Contracts;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Services.CustomerAPI.Models;

namespace PCBuilder.Service.CustomerAPI.IServices;

public interface IComputerValidationService
{
    Task<ResponseDTO> CheckIfGpuFitsInCaseAsync(Order order, ComputerDTO computer);
    Task<ResponseDTO> CheckPsuCanPowerAsync(Order order, ComputerDTO computer);
    Task<ResponseDTO> CheckCoolingIsSufficientAsync(Order order, ComputerDTO computer);
    Task<ResponseDTO> CheckEfficiencyIsGoodAsync(Order order, ComputerDTO computer);
    Task<ResponseDTO> CheckPriceIsWithinBudgetAsync(Order order, ComputerDTO computer);
}