using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Service.BuilderServiceAPI.Models;

namespace PCBuilder.Services.CustomerAPI.Models;

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ReviewId { get; set; }
    public int? ComputerId { get; set; }
    public int Budget { get; set; }
    public string Description { get; set; } = string.Empty;
    public string DetailedDescription { get; set; } = string.Empty;
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
public enum OrderStatus
{
    Pending,
    InProgress,
    Completed,
    Rejected,
}