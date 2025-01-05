using Models;

namespace Data.Repository;

public interface IImageRepository : IRepository<Image>
{
}

internal class ImageRepository(ApplicationDbContext p_context) 
    : Repository<Image>(p_context), IImageRepository
{
    
}