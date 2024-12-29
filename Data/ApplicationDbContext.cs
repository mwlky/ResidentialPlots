using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> p_options) : DbContext(p_options)
{
    // public DbSet<ResidentialPlot> ResidentialPlots { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ResidentialPlot>().HasData(
            new ResidentialPlot
            {
                ID = 1, Description = "Test", Name = "Test", Location = "Warszawa", Price = 999, Size = 1000
            });
    }
}