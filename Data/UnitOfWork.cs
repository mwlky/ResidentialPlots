using Data.Repository;

namespace Data;

public interface IUnitOfWork
{
    void Save();
    
    IImageRepository ImageRepository { get; }
    IResidentialPlotRepository ResidentialPlots { get; }
}

public class UnitOfWork : IUnitOfWork
{
    public IImageRepository ImageRepository { get; }
    public IResidentialPlotRepository ResidentialPlots { get; }
    
    
    private readonly ApplicationDbContext _context;
    
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
        
        ImageRepository = new ImageRepository(_context);
        ResidentialPlots = new ResidentialPlotRepository(_context);
    }
    
    public void Save()
    {
        _context.SaveChanges();
    }
}