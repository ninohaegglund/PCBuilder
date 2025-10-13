namespace PCBuilder.Services.CustomerAPI.DTO;

public class ReviewDTO
{
    public int Id { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
}
