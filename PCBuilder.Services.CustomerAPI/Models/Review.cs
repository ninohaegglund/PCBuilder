namespace PCBuilder.Services.CustomerAPI.Models; 

public class Review
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public int ComputerId { get; set; }
    public int Rating { get; set; } 
    public string Comment { get; set; } = string.Empty;
    public DateTime ReviewDate { get; set; } = DateTime.UtcNow;
    public Customer? Customer { get; set; }
}
