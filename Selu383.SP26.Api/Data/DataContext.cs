using Microsoft.EntityFrameworkCore;
using Selu383.SP26.Api.Models;

namespace Selu383.SP26.Api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Location> Location { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Location entity
        modelBuilder.Entity<Location>(l =>
        {
            l.HasKey(e => e.Id);

            l.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            l.Property(e => e.Address)
                .IsRequired();

            l.Property(e => e.TableCount)
                .IsRequired();
        });

        // Seed data required for unit tests
        modelBuilder.Entity<Location>().HasData(
            new Location
            {
                Id = 1,
                Name = "Test Location 1",
                Address = "123 Main St",
                TableCount = 10
            },
            new Location
            {
                Id = 2,
                Name = "Test Location 2",
                Address = "456 Oak Ave",
                TableCount = 8
            }
        );
    }
}