namespace PCBuilder.Web.ViewModels.Reviews;

public class ReviewsIndexViewModel
{
    public List<CustomerReviewItemViewModel> Reviews { get; set; } = new();
    public decimal AverageRating { get; set; }
    public bool IsGameOver { get; set; }
    public int CompletedReviewCount => Reviews.Count;
}
