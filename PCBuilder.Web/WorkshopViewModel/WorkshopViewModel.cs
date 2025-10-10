using PCBuilder.Services.ComponentsAPI.DTOs;

namespace PCBuilder.Web.WorkshopViewModel;

public class WorkshopViewModel
{
    public List<PendingOrdersDTO> PendingOrders { get; set; }
    public List<ComputerDTO> UnfinishedBuilds { get; set; }
    public List<ComputerDTO> BuiltComputers { get; set; }
    public List<InventoryDTO> Inventory { get; set; }
}