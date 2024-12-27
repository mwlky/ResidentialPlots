using Models;

namespace Data.Repository;

public interface IResidentialPlotRepository : IRepository<ResidentialPlot>
{
}

internal class ResidentialPlotRepository : Repository<ResidentialPlot>, IResidentialPlotRepository
{
    private readonly ApplicationDbContext _context;

    public ResidentialPlotRepository(ApplicationDbContext p_context) : base(p_context)
    {
        _context = p_context;
    }
}