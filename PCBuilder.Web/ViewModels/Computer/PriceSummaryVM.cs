using PCBuilder.Service.BuilderServiceAPI.DTO;
using PCBuilder.Services.CustomerAPI.DTO;
using Contracts;

namespace PCBuilder.Web.ViewModels.Computer;

public class PriceSummaryVM
{
    public OrderDTO? Order { get; set; }
    public ComputerDTO? Computer { get; set; }
    public CustomerDTO? Customer { get; set; }
    public ResponseDTO? ReviewResponse { get; set; }
}
