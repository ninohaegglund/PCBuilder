using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;

namespace PCBuilder.Service.BuilderServiceAPI.IService;

public interface IComputerValidationService
{
    Task<ResponseDTO> CheckGpuFitsInCaseAsync(IEnumerable<int> gpuIds, int? caseId);
    Task<ResponseDTO> CheckPsuCanPowerAsync(BuildReviewRequestDto request);
    Task<ResponseDTO> CheckCoolingIsSufficientAsync(BuildReviewRequestDto request);
    Task<ResponseDTO> CheckEfficiencyIsGoodAsync(BuildReviewRequestDto request);
    Task<ResponseDTO> CheckPriceIsWithinBudgetAsync(BuildReviewRequestDto request);
}