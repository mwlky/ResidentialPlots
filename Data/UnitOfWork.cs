using Data.Repository;

namespace Data;

public interface IUnitOfWork
{
    IResidentialPlotRepository ResidentialPlots { get; }
}

public class UnitOfWork : IUnitOfWork
{
    public IResidentialPlotRepository ResidentialPlots => _residentialPlots;

    private readonly ApplicationDbContext _context;
    private readonly IResidentialPlotRepository _residentialPlots;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        _residentialPlots = new ResidentialPlotRepository(_context);
    }
}