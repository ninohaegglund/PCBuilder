using PCBuilder.Service.BuilderServiceAPI.Data;

namespace PCBuilder.Service.BuilderServiceAPI.Repository;

public class UnfinishedBuildsRepository
{
    public readonly PcDataContext _context;
    public UnfinishedBuildsRepository(PcDataContext context)
    {
        _context = context;
    }

}
