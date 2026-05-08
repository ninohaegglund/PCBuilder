using PCBuilder.Service.ComponentsAPI.Models.DTOs;

namespace PCBuilder.Web.ViewModels.Shop;

public class ShopViewModel
{
    public AllComponentsDto? Components { get; set; }
    public decimal? WalletBalance { get; set; }
}
