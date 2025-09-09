using Newtonsoft.Json;
using PCBuilder.Web.Models.Dto;
using PCBuilder.Web.Service.IService;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using static PCBuilder.Web.Utility.SD;

namespace PCBuilder.Web.Service;

public class BaseService : IBaseService
{
    private readonly IHttpClientFactory _httpClientFactory;
    public BaseService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
    {
        try
        {
            HttpClient client = _httpClientFactory.CreateClient("PCBuilderAPI");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            //token

            message.RequestUri = new Uri(requestDto.Url!);
            if (requestDto.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");

            }

            HttpResponseMessage? apiResponse = null;

            switch (requestDto.ApiType)
            {
                case ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            apiResponse = await client.SendAsync(message);

            switch (apiResponse.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new() { IsSuccess = false, DisplayMessage = "Not Found" };
                case HttpStatusCode.Forbidden:
                    return new() { IsSuccess = false, DisplayMessage = "Access Denied" };
                case HttpStatusCode.Unauthorized:
                    return new() { IsSuccess = false, DisplayMessage = "Unauthorized" };
                case HttpStatusCode.InternalServerError:
                    return new() { IsSuccess = false, DisplayMessage = "Internal Server Error" };
                default:
                    var apiContent = await apiResponse.Content.ReadAsStringAsync();
                    var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                    return apiResponseDto;

            }

        } catch (Exception ex)
        {
            var dto = new ResponseDto
            {

                DisplayMessage = ex.Message.ToString(),
                IsSuccess = false
            };
            return dto;
        }
    }
}


