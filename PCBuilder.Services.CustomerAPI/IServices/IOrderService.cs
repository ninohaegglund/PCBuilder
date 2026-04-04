using PCBuilder.Services.CustomerAPI.Response;

namespace PCBuilder.Services.CustomerAPI.IServices;

public interface IOrderService
{
    Task<ResponseDTO> GetAllOrdersAsync();
    Task<ResponseDTO> GetOrderByIdAsync(int id);
    Task<ResponseDTO> AcceptOrderAsync(int orderId);
    public Task<ResponseDTO> RejectOrderAsync(int orderId);
    public Task<ResponseDTO> CompleteOrderAsync(int orderId);
}