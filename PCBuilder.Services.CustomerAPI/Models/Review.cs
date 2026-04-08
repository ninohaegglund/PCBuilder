namespace PCBuilder.Services.CustomerAPI.Models;

public class Review
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedDate { get; set; }
    public int Rating { get; set; }
}
