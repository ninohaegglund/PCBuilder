namespace PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;

public class ResponseDTO
{
    public object? Result { get; set; }
    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; } = string.Empty;
}
