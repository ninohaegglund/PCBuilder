namespace Contracts;

public class ResponseDTO
{
    public bool IsSuccess { get; set; } = true;
    public object? Result { get; set; }
    public string? Message { get; set; } = string.Empty;
}