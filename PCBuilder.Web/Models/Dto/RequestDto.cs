using static PCBuilder.Web.Utility.SD;

namespace PCBuilder.Web.Models.Dto;

public class RequestDto
{
    public ApiType ApiType { get; set; } = ApiType.GET;
    public string? Url { get; set; }
    public object? Data { get; set; }
    public string? AccessToken { get; set; }
}
