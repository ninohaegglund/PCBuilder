using PCBuilder.Service.BuilderServiceAPI.DTO;

namespace PCBuilder.Web.WorkshopViewModel;

public class WorkshopViewModel
{
    public List<PendingOrdersDTO> PendingOrders { get; set; }
    public List<ComputerDTO> UnfinishedBuilds { get; set; }
    public List<ComputerDTO> BuiltComputers { get; set; }
    public List<InventoryItemDTO> InventoryItem { get; set; }
}