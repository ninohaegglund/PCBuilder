namespace PCBuilder.Web.Models;

public class WorkshopViewModel
{
    public List<CustomerOrderDTO> RecentCustomerOrders { get; set; }
    public List<BuiltComputerDTO> BuiltComputers { get; set; }
    public List<CustomerDTO> Customers { get; set; } 
}
