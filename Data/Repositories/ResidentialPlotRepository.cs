using Microsoft.EntityFrameworkCore;
using Models;

namespace Data.Repository;

public interface IResidentialPlotRepository : IRepository<ResidentialPlot>
{
}

internal class ResidentialPlotRepository(ApplicationDbContext p_context)
    : Repository<ResidentialPlot>(p_context), IResidentialPlotRepository
{
    public override List<ResidentialPlot> GetElements()
    {
        return p_context.ResidentialPlots
            .Include(x => x.Images)
            .ToList();
    }
}