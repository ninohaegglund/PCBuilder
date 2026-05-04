using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Services.CustomerAPI.DTO;

namespace PCBuilder.Web.ViewModels.Computer;

public class PriceSummaryVM
{
    public OrderDTO Order { get; set; }
    public ComputerDTO Computer { get; set; }
}