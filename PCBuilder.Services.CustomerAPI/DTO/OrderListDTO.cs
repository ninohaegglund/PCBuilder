namespace PCBuilder.Services.CustomerAPI.DTO;

public class OrderListDTO
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public Guid? UserId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerImageUrl { get; set; } = string.Empty;

    public int? ComputerId { get; set; }
    public int Budget { get; set; }
    public string Description { get; set; } = string.Empty;
    public string DetailedDescription { get; set; } = string.Empty;

    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}