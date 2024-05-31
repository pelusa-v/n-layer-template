using Microsoft.EntityFrameworkCore;
using project_api.Core.Entities;

namespace project_api.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     base.OnModelCreating(modelBuilder);
        
    //     // modelBuilder.Entity<Pet>().ToTable("Pets");  // Change if need custom table name
    // }

    public DbSet<Pet> Pets { get; set; }
}

