namespace PCBuilder.Web.ViewModels.Shop;

public class ShopSectionViewModel
{
    public string Title { get; set; }
    public string Icon { get; set; }
    public IEnumerable<dynamic> Items { get; set; }

    public ShopSectionViewModel(string title, string icon, IEnumerable<dynamic>? items)
    {
        Title = title;
        Icon = icon;
        Items = items ?? Enumerable.Empty<dynamic>();
    }
}
