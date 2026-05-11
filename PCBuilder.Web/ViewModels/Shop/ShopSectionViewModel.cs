namespace PCBuilder.Web.ViewModels.Shop;

public class ShopSectionViewModel
{
    public string Title { get; set; }
    public string ComponentType { get; set; }
    public string FilterType { get; set; }
    public string BadgeText { get; set; }
    public string Icon { get; set; }
    public IEnumerable<dynamic> Items { get; set; }

    public ShopSectionViewModel(
        string title,
        string componentType,
        string icon,
        IEnumerable<dynamic>? items,
        string? filterType = null,
        string? badgeText = null)
    {
        Title = title;
        ComponentType = componentType;
        FilterType = filterType ?? componentType;
        BadgeText = badgeText ?? componentType;
        Icon = icon;
        Items = items ?? Enumerable.Empty<dynamic>();
    }
}
