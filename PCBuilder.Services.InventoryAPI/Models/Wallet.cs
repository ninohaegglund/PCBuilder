namespace PCBuilder.Services.InventoryAPI.Models;

public class Wallet
{
    public int Id { get; set; }

    public Guid UserId { get; set; }

    public decimal Balance { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
