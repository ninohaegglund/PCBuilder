namespace PCBuilder.Service.BuilderServiceAPI.DTO;

public class PendingOrdersDTO
{
    public int Id { get; set; }
    public string? CustomerName { get; set; }
    public string? Email { get; set; }
    public string? ComputerName { get; set; }
    public string? Address { get; set; }
    public DateTime OrderDate { get; set; }
    public string? PaymentStatus { get; set; }
    public string? OrderStatus { get; set; }
    public decimal TotalAmount { get; set; }
}
