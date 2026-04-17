using Microsoft.EntityFrameworkCore;
using RecycleManager.Api.Domain;
using System.Drawing;

namespace RecycleManager.Api.Infrastructure;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<CollectionPoint> CollectionPoints { get; set; }
    public DbSet<Material> Materials { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CollectionPoint>().HasIndex(p => p.Name).IsUnique(false);
        modelBuilder.Entity<Material>().HasIndex(m => m.Name).IsUnique(false);
    }
}
