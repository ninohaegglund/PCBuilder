namespace PCBuilder.Services.CustomerAPI.DTO;

public class OrderDTO
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
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
