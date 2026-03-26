namespace PCBuilder.Services.CustomerAPI.Models;

public class Order
{
    public int Id { get; set; }
    public int Budget { get; set; }
    public string Description { get; set; } = string.Empty;
    public string DetrailedDescription { get; set; } = string.Empty;
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
public enum OrderStatus
{
    Draft,
    InProgress,
    Completed,
    Cancelled
}