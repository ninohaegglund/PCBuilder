namespace PCBuilder.Web.WorkshopViewModel;

public class WorkshopViewModel
{
    public List<PendingOrdersDTO> PendingOrders { get; set; }
    public List<UnfinishedBuildsDTO> UnfinishedBuilds { get; set; }
    public List<BuiltComputersDTO> BuiltComputers { get; set; }
    public List<InventoryDTO> Inventory { get; set; }
}