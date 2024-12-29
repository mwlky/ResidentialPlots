using Models;

namespace Data.Repository;

public interface IResidentialPlotRepository : IRepository<ResidentialPlot>
{
}

internal class ResidentialPlotRepository(ApplicationDbContext p_context)
    : Repository<ResidentialPlot>(p_context), IResidentialPlotRepository
{
}