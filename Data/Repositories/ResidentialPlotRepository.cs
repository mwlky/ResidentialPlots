using Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public interface IResidentialPlotRepository : IRepository<ResidentialPlot>
{
    void Update(ResidentialPlot plot);
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

    public void Update(ResidentialPlot plot)
    {
        p_context.ResidentialPlots.Update(plot);
    }
}