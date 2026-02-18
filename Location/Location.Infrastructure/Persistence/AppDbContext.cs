using Location.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Location.Infrastructure.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Locations> locations { get; set; }
    public DbSet<OperatorLocation> operator_location { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Locations>()
            .HasMany(x => x.operator_locations)
            .WithOne(x => x.location)
            .HasForeignKey(x => x.location_id);

        modelBuilder.Entity<Locations>()
            .HasData(
                new Locations { id=1,name="Main",description="Main location",is_active=true }
            );

        modelBuilder.Entity<OperatorLocation>()
            .HasData(
                new OperatorLocation {
                    id=1,
                    operator_id =1,
                    location_id =1,
                    is_active = true
                }
            );


    }

}
