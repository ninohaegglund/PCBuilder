using PCBuilder.Services.CustomerAPI.Response;

namespace PCBuilder.Services.CustomerAPI.IServices;

public interface IOrderService
{
    Task<ResponseDTO> GetAllOrdersAsync();
    Task<ResponseDTO> GetOrderByIdAsync(int id);
    Task<ResponseDTO> AcceptOrder(int orderId);
    public Task<ResponseDTO> RejectOrder(int orderId);
    public Task<ResponseDTO> CompleteOrder(int orderId);
}