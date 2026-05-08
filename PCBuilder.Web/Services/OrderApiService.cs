using Newtonsoft.Json;
using PCBuilder.Services.CustomerAPI.IServices;
using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Net.Http.Headers;
using System.Text;
using System.Net;

namespace PCBuilder.Web.Services;

public class OrderApiService : IOrderService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public OrderApiService(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor)
    {
        _httpClientFactory = httpClientFactory;
        _httpContextAccessor = httpContextAccessor;
    }

    public Task<ResponseDTO> GetAllOrdersAsync() => SendAsync(HttpMethod.Get, "api/orders");
    public Task<ResponseDTO> GetOrderByIdAsync(int id) => SendAsync(HttpMethod.Get, $"api/orders/{id}");

    public Task<ResponseDTO> AcceptOrderAsync(int orderId) => SendAsync(HttpMethod.Put, $"api/orders/{orderId}/accept");

    public Task<ResponseDTO> RejectOrderAsync(int orderId) => SendAsync(HttpMethod.Put, $"api/orders/{orderId}/reject");

    public Task<ResponseDTO> CompleteOrderAsync(int orderId) => SendAsync(HttpMethod.Put, $"api/orders/{orderId}/complete");
    public Task<ResponseDTO> UpdateSellingPriceAsync(int orderId, decimal sellingPrice)
    {
        var data = new
        {
            SellingPrice = sellingPrice
        };

        return SendAsync(HttpMethod.Put, $"api/orders/{orderId}/selling-price", data);
    }

    private async Task<ResponseDTO> SendAsync(HttpMethod method, string url, object? data = null)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("CustomerAPI");
            using var request = new HttpRequestMessage(method, url);

            var token = _httpContextAccessor.HttpContext?.Session.GetString("AuthToken");
            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }

            if (data != null)
            {
                var json = JsonConvert.SerializeObject(data);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            using var response = await client.SendAsync(request);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                _httpContextAccessor.HttpContext?.Session.Remove("AuthToken");
                _httpContextAccessor.HttpContext?.Session.Remove("CurrentUser");
                if (_httpContextAccessor.HttpContext != null)
                {
                    await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                }

                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Session expired. Please log in again."
                };
            }
            var content = await response.Content.ReadAsStringAsync();

            if (!string.IsNullOrWhiteSpace(content))
            {
                var dto = JsonConvert.DeserializeObject<ResponseDTO>(content);
                if (dto != null)
                {
                    if (!response.IsSuccessStatusCode && dto.IsSuccess)
                    {
                        dto.IsSuccess = false;
                    }

                    return dto;
                }
            }

            return new ResponseDTO
            {
                IsSuccess = response.IsSuccessStatusCode,
                Message = response.IsSuccessStatusCode ? "Success" : $"Request failed: {(int)response.StatusCode}"
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }
}
