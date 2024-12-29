using Microsoft.EntityFrameworkCore;

namespace Data.Repository;


public interface IRepository<T> where T : class
{
    void Add(T element);
    void Remove(T element);
    void Update(T element);

    List<T> GetElements();
}

public class Repository<T> : IRepository<T> where T: class
{
    private readonly DbSet<T> _dbSet;
    private readonly ApplicationDbContext _context;

    protected Repository(ApplicationDbContext p_context)
    {
        _context = p_context;
        _dbSet = _context.Set<T>();
    }

    public void Add(T element)
    {
        _dbSet.Add(element);
    }

    public void Remove(T element)
    {
        _dbSet.Remove(element);
    }

    public void Update(T element)
    {
        _dbSet.Update(element);
    }

    public List<T> GetElements()
    {
        return _dbSet.ToList();
    }
}