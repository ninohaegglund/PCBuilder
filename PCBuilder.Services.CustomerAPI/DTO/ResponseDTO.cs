namespace PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;

public class ResponseDTO
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }

    public decimal? EstimatedTotalPrice { get; set; }
    public int? EstimatedTotalPowerDraw { get; set; }

    public List<string> Errors { get; set; } = new();
    public List<string> Warnings { get; set; } = new();
}