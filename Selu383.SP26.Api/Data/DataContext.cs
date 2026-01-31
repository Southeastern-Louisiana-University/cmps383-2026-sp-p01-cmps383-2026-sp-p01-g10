using Microsoft.EntityFrameworkCore;
using Selu383.SP26.Api.Data;
using Selu383.SP26.Api.Models;


namespace Selu383.SP26.Api.Data;

public class DataContext : DbContext { 

    public DataContext(DbContextOptions<DataContext> options) : base(options) 
    { 
    }

    public DbSet<Location> Location { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Location>(l =>
        {
            l.HasKey(e => e.Id);
            l.Property(e => e.Name).IsRequired().HasMaxLength(100);
            l.Property(e => e.Address).IsRequired();
            l.Property(e => e.TableCount).IsRequired();
        });
    }
}