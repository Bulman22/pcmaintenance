using Microsoft.EntityFrameworkCore;
using PcMaintenance.Server.Data.Entities;

namespace PcMaintenance.Server.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Review> Reviews => Set<Review>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Review>(e =>
        {
            e.HasKey(x => x.Id);
            e.Property(x => x.AuthorName).IsRequired().HasMaxLength(200);
            e.Property(x => x.Comment).IsRequired();
            e.Property(x => x.Rating).IsRequired();
            e.Property(x => x.CreatedAt).IsRequired();
        });
    }
}
