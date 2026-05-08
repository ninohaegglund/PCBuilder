using Contracts;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Service.ComponentsAPI.Models.DTOs;
using PCBuilder.Service.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.Models;

namespace PCBuilder.Service.CustomerAPI.Services;

public class ComputerValidationService : IComputerValidationService
{
    private readonly IGetComponentsService _componentsService;
    private readonly IComponentService _componentService;
    private readonly IReviewTextService _reviewTextService;

    public ComputerValidationService(
        IGetComponentsService componentsService,
        IComponentService componentService,
        IReviewTextService reviewTextService)
    {
        _componentsService = componentsService;
        _componentService = componentService;
        _reviewTextService = reviewTextService;
    }

    public async Task<ResponseDTO> CheckIfGpuFitsInCaseAsync(Order order, ComputerDTO computer)
    {
        if (computer.GpuIds == null || !computer.GpuIds.Any())
        {
            return new ResponseDTO
            {
                IsSuccess = true,
                Message = string.Empty
            };
        }

        if (!computer.CaseId.HasValue)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = _reviewTextService.GetRandomText("GpuDoesNotFitInCase")
            };
        }

        var gpus = await _componentsService.GetGpusAsync(computer.GpuIds);
        var caseDto = await _componentService.GetByIdAsync<CaseDto>(computer.CaseId);

        if (caseDto == null)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = _reviewTextService.GetRandomText("GpuDoesNotFitInCase")
            };
        }

        foreach (var gpu in gpus)
        {
            if (gpu.LengthMM.HasValue &&
                caseDto.MaxGpuLengthMm.HasValue &&
                gpu.LengthMM.Value > caseDto.MaxGpuLengthMm.Value)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = _reviewTextService.GetRandomText("GpuDoesNotFitInCase")
                };
            }
        }

        return new ResponseDTO
        {
            IsSuccess = true,
            Message = string.Empty
        };
    }

    public async Task<ResponseDTO> CheckCoolingIsSufficientAsync(Order order, ComputerDTO computer)
    {
        if (!computer.CpuId.HasValue || !computer.CpuCoolerId.HasValue)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = _reviewTextService.GetRandomText("CoolingIsInsufficient")
            };
        }

        var cpu = await _componentService.GetByIdAsync<CPUDto>(computer.CpuId);
        var cooler = await _componentService.GetByIdAsync<CPUCoolerDto>(computer.CpuCoolerId);

        if (cpu == null || cooler == null)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = _reviewTextService.GetRandomText("CoolingIsInsufficient")
            };
        }

        if (!cpu.Tdp.HasValue || !cooler.MaxTdpWatts.HasValue)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = _reviewTextService.GetRandomText("CoolingIsInsufficient")
            };
        }

        if (cooler.MaxTdpWatts.Value < cpu.Tdp.Value)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = _reviewTextService.GetRandomText("CoolingIsInsufficient")
            };
        }

        return new ResponseDTO
        {
            IsSuccess = true,
            Message = _reviewTextService.GetRandomText("CoolingIsGood")
        };
    }

    public async Task<ResponseDTO> CheckPsuCanPowerAsync(Order order, ComputerDTO computer)
    {
        if (!computer.PowerSupplyId.HasValue)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = _reviewTextService.GetRandomText("PsuCannotPowerBuild")
            };
        }

        var psu = await _componentService.GetByIdAsync<PSUDto>(computer.PowerSupplyId);

        if (psu == null)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = _reviewTextService.GetRandomText("PsuCannotPowerBuild")
            };
        }

        var estimatedPowerDraw = 0;

        if (computer.CpuId.HasValue)
        {
            var cpu = await _componentService.GetByIdAsync<CPUDto>(computer.CpuId);
            if (cpu?.Tdp.HasValue == true)
            {
                estimatedPowerDraw += cpu.Tdp.Value;
            }
        }

        if (computer.GpuIds != null && computer.GpuIds.Any())
        {
            var gpus = await _componentsService.GetGpusAsync(computer.GpuIds);
            if (gpus != null)
            {
                foreach (var gpu in gpus)
                {
                    if (gpu.Tdp.HasValue)
                    {
                        estimatedPowerDraw += gpu.Tdp.Value;
                    }
                }
            }
        }

        if (estimatedPowerDraw > psu.Wattage)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = _reviewTextService.GetRandomText("PsuCannotPowerBuild")
            };
        }

        return new ResponseDTO
        {
            IsSuccess = true,
            Message = string.Empty
        };
    }

    public async Task<ResponseDTO> CheckEfficiencyIsGoodAsync(Order order, ComputerDTO computer)
    {
        if (!computer.PowerSupplyId.HasValue)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = _reviewTextService.GetRandomText("EfficiencyIsPoor")
            };
        }

        var psu = await _componentService.GetByIdAsync<PSUDto>(computer.PowerSupplyId);

        if (psu == null)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = _reviewTextService.GetRandomText("EfficiencyIsPoor")
            };
        }

        if (string.IsNullOrWhiteSpace(psu.EfficiencyRating))
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = _reviewTextService.GetRandomText("EfficiencyIsPoor")
            };
        }

        var rating = psu.EfficiencyRating.Trim().ToLowerInvariant();

        if (rating is "80+ gold" or "80+ platinum" or "80+ titanium")
        {
            return new ResponseDTO
            {
                IsSuccess = true,
                Message = string.Empty
            };
        }

        return new ResponseDTO
        {
            IsSuccess = false,
            Message = _reviewTextService.GetRandomText("EfficiencyIsPoor")
        };
    }

    public async Task<ResponseDTO> CheckPriceIsWithinBudgetAsync(Order order, ComputerDTO computer)
    {
        if (order.SellingPrice <= order.Budget)
        {
            return new ResponseDTO
            {
                IsSuccess = true,
                Message = string.Empty
            };
        }

        return new ResponseDTO
        {
            IsSuccess = false,
            Message = _reviewTextService.GetRandomText("PriceIsOverBudget")
        };
    }
}
