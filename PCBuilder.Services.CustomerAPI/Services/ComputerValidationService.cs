using Contracts;
using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.ComponentsAPI.Interfaces;
using PCBuilder.Service.ComponentsAPI.Models.DTOs;
using PCBuilder.Service.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.Models;
using System.Text.RegularExpressions;

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
        var softLimit = order.Budget * 1.05m;

        if (order.SellingPrice <= softLimit)
        {
            return new ResponseDTO
            {
                IsSuccess = true,
                Message = string.Empty
            };
        }

        var overBudget = order.SellingPrice - order.Budget;
        var overBudgetPercent = order.Budget > 0
            ? overBudget / order.Budget
            : 1m;

        return new ResponseDTO
        {
            IsSuccess = false,
            Message = overBudgetPercent >= 0.15m
                ? $"{_reviewTextService.GetRandomText("PriceIsOverBudget")} This is much farther over budget than I expected."
                : _reviewTextService.GetRandomText("PriceIsOverBudget")
        };
    }

    public Task<ResponseDTO> CheckRequestedPeripheralsAsync(Order order, ComputerDTO computer)
    {
        var orderText = $"{order.Description} {order.DetailedDescription}".ToLowerInvariant();
        var missing = new List<string>();

        AddMissingIfRequested(
            missing,
            orderText,
            computer.KeyboardId.HasValue,
            "keyboard",
            "keyboard",
            "tangentbord",
            "complete package",
            "complete setup",
            "full setup",
            "desk package",
            "desk bundle");

        AddMissingIfRequested(
            missing,
            orderText,
            computer.MouseId.HasValue,
            "mouse",
            "mouse",
            "mus",
            "complete package",
            "complete setup",
            "full setup",
            "desk package",
            "desk bundle");

        AddMissingIfRequested(
            missing,
            orderText,
            computer.HeadphonesId.HasValue,
            "headset",
            "headset",
            "headphones",
            "horlurar",
            "complete gaming package",
            "streaming kit",
            "complete setup");

        AddMissingIfRequested(
            missing,
            orderText,
            computer.SpeakerIds?.Any() == true || computer.Speakers?.Any() == true,
            "speakers",
            "speakers",
            "speaker",
            "hogtalare",
            "sound system",
            "complete desktop package",
            "complete setup");

        if (!missing.Any())
        {
            return Task.FromResult(new ResponseDTO
            {
                IsSuccess = true,
                Message = string.Empty
            });
        }

        return Task.FromResult(new ResponseDTO
        {
            IsSuccess = false,
            Message = $"{_reviewTextService.GetRandomText("PeripheralsMissing")} Missing: {string.Join(", ", missing)}."
        });
    }

    private static void AddMissingIfRequested(
        List<string> missing,
        string orderText,
        bool isIncluded,
        string label,
        params string[] keywords)
    {
        if (!isIncluded && keywords.Any(keyword => ContainsKeyword(orderText, keyword)))
        {
            missing.Add(label);
        }
    }

    private static bool ContainsKeyword(string text, string keyword)
    {
        return keyword.Contains(' ')
            ? text.Contains(keyword)
            : Regex.IsMatch(text, $@"\b{Regex.Escape(keyword)}\b", RegexOptions.IgnoreCase);
    }
}
