using Data.Repository;

namespace Data;

public interface IUnitOfWork
{
    void Save();
    
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
    
    public void Save()
    {
        _context.SaveChanges();
    }
}