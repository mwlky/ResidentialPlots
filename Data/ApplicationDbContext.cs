using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> p_options) : IdentityDbContext(p_options)
{
    public DbSet<Image> Images { get; set; }
    public DbSet<ResidentialPlot> ResidentialPlots { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ResidentialPlot>().HasData(
            new ResidentialPlot
            {
                ID = 1, Description = "Test", Name = "Test", Location = "Warszawa", Price = 999, Size = 1000
            });

        modelBuilder.Entity<Image>()
            .HasOne(img => img.ResidentialPlot)
            .WithMany(plot => plot.Images)
            .HasForeignKey(img => img.ResidentialPlotID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}