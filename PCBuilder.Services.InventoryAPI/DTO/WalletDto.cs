namespace PCBuilder.Services.InventoryAPI.DTO;

public class WalletDto
{
    public int Id { get; set; }
    public Guid UserId { get; set; }
    public decimal Balance { get; set; }
}
