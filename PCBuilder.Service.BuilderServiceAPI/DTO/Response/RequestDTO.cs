using static PCBuilder.Service.BuilderServiceAPI.Utility.SD;

namespace PCBuilder.Service.BuilderServiceAPI.DTO.Response;

public class RequestDTO
{
    public ApiType ApiType { get; set; } = ApiType.GET;
    public string? Url { get; set; }
    public object? Data { get; set; }
    public string? AccessToken { get; set; }
}
