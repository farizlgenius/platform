using Device.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Infrastructure.Persistance
{
    public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Devices> devices { get; set; }
        public DbSet<Module> modules { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) 
        {
            base.OnModelCreating(builder);

            builder.Entity<Module>()
                .HasOne(x => x.devices)
                .WithMany(x => x.modules)
                .HasForeignKey(x => x.device_id);
        }

    }
}
