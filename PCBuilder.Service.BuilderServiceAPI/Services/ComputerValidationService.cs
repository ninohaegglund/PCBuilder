using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.IService;
using PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Service.ComponentsAPI.Models.DTOs;

namespace PCBuilder.Service.BuilderServiceAPI.Services;

public class ComputerValidationService : IComputerValidationService
{
    private readonly IGetComponentsService _componentsService;
    private readonly IComponentService _componentService;

    public ComputerValidationService(IGetComponentsService componentsService, IComponentService componentService)
    {
        _componentsService = componentsService;
        _componentService = componentService;
    }

    public async Task<ResponseDTO> CheckIfGpuFitsInCaseAsync(BuildReviewRequestDto buildReviewRequestDto)
    {
        var gpus = await _componentsService.GetGpusAsync(buildReviewRequestDto.GpuIds);
        var chassi = await _componentService.GetByIdAsync<CaseDto>(buildReviewRequestDto.CaseId);

        if (gpus == null || !gpus.Any())
        {
            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "No GPUs to validate."
            };
        }

        if (chassi == null)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = $"Case with ID {buildReviewRequestDto.CaseId} was not found."
            };
        }

        foreach (var gpu in gpus)
        {
            if (gpu.LengthMM.HasValue &&
                chassi.MaxGpuLengthMm.HasValue &&
                gpu.LengthMM.Value > chassi.MaxGpuLengthMm.Value)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = $"WARNING: GPU {gpu.Name} does not fit in the case {chassi.Name}."
                };
            }
        }

        return new ResponseDTO
        {
            IsSuccess = true,
            Message = "All GPUs fit in the case."
        };
    }
    
    public async Task<ResponseDTO> CheckPsuCanPowerAsync(IEnumerable<int> componentIds)
    {
        
    }
}