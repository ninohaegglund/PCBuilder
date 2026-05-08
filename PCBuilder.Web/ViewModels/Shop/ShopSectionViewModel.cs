namespace PCBuilder.Web.ViewModels.Shop;

public class ShopSectionViewModel
{
    public string Title { get; set; }
    public string ComponentType { get; set; }
    public string Icon { get; set; }
    public IEnumerable<dynamic> Items { get; set; }

    public ShopSectionViewModel(string title, string componentType, string icon, IEnumerable<dynamic>? items)
    {
        Title = title;
        ComponentType = componentType;
        Icon = icon;
        Items = items ?? Enumerable.Empty<dynamic>();
    }
}
