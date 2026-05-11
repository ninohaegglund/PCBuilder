namespace PCBuilder.Web.ViewModels.Reviews;

public class CustomerReviewItemViewModel
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; } = "Customer";
    public string CustomerImageUrl { get; set; } = string.Empty;
    public string OrderDescription { get; set; } = string.Empty;
    public string ReviewText { get; set; } = string.Empty;
    public int Rating { get; set; }
    public decimal SellingPrice { get; set; }
    public DateTime CreatedAt { get; set; }
}
