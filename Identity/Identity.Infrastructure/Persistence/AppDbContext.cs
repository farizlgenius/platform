using Identity.Infrastructure.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Infrastructure.Persistence
{
    public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Feature> features { get; set; }
        public DbSet<MasterFeature> master_features { get; set; }
        public DbSet<Operator> operators { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<RefreshTokenAudit> refresh_token { get; set; }
        public DbSet<WeakPassword> weak_password { get; set; }
        public DbSet<PasswordRule> password_rule { get; set; }
        public DbSet<OperatorLocation> operator_locations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.UseOpenIddict();


            builder.Entity<MasterFeature>()
           .HasData(
               new MasterFeature { id = 1,  name = "Dashboard", path = "/" },
               new MasterFeature { id = 2, name = "Events", path = "/event" },
               new MasterFeature { id = 3,  name = "Location", path = "/location" },
               new MasterFeature { id = 4,  name = "Alerts", path = "/alert" },
               new MasterFeature { id = 5,  name = "Operator",path="/operator" },
               new MasterFeature { id = 6, name = "Role", path = "/role" },
               new MasterFeature { id = 7,  name = "Hardware",path="/hardware" },
               new MasterFeature { id = 8, name = "Control Point", path = "/control" },
               new MasterFeature { id = 9, name = "Monitor Point", path = "/monitor" },
               new MasterFeature { id = 10, name = "Monitor Group", path = "/monitorgroup" },
               new MasterFeature { id = 11,  name = "Door", path = "/door" },
               new MasterFeature { id = 12,  name = "User", path = "/user" },
               new MasterFeature { id = 13,  name = "Access Level", path = "/level" },
               new MasterFeature { id = 14,  name = "Access Area", path = "/area" },
               new MasterFeature { id = 15,  name = "Timezone",path="/timezone" },
               new MasterFeature { id = 16, name = "Holiday", path = "/holiday" },
               new MasterFeature { id = 17, name = "Interval", path = "/interval" },
               new MasterFeature { id = 18,  name = "Trigger",path="/trigger" },
               new MasterFeature { id = 19, name = "Procedure", path = "/procedure" },
               new MasterFeature { id = 20,  name = "Reports",path="/report" },
               new MasterFeature { id = 21,  name = "Settings", path = "/setting" },
               new MasterFeature { id = 22,  name = "Maps", path = "/map" }

           );

            builder.Entity<Operator>()
                .HasMany(x => x.operator_locations)
                .WithOne(x => x.operators)
                .HasForeignKey(x => x.operator_id);

            builder.Entity<Operator>()
                .HasData(
                    new Operator { id = 1,  userid = "1", username = "admin", password = "2439iBIqejYGcodz6j0vGvyeI25eOrjMX3QtIhgVyo0M4YYmWbS+NmGwo0LLByUY", email = "support@honorsupplying.com", title = "Mr.", firstname = "Administrator", middlename = "", lastname = "Platform", phone = "", image = "", is_active = true,role_id=1 }
                );

            builder.Entity<OperatorLocation>()
                .HasData(
                new OperatorLocation { id=1,location_id=1,operator_id=1 }
                );

            builder.Entity<Role>()
            .HasData(
                new Role { id = 1, name = "Administrator", location_id = 1 }
            );

            builder.Entity<Feature>()
                .HasData(
                new Feature { id=1,name="Dashboard",path="/",is_action=true,is_allow=true,is_active=true,is_create=true,is_delete=true,is_modify=true,role_id=1 },
                new Feature { id = 2, name = "Events", path = "/event", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 3, name = "Location", path = "/location", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 4, name = "Alerts", path = "/alert", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 5, name = "Operator", path = "/operator", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 6, name = "Role", path = "/role", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 7, name = "Hardware", path = "/hardware", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 8, name = "Control Point", path = "/control", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 9, name = "Monitor Point", path = "/monitor", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 10, name = "Monitor Group", path = "/monitorgroup", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 11, name = "Door", path = "/door", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 12, name = "User", path = "/user", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 13, name = "Access Level", path = "/level", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 14, name = "Access Area", path = "/area", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 15, name = "Timezone", path = "/timezone", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 16, name = "Holiday", path = "/holiday", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 17, name = "Interval", path = "/interval", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 18, name = "Trigger", path = "/trigger", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 19, name = "Procedure", path = "/procedure", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 20, name = "Reports", path = "/report", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 21, name = "Settings", path = "/setting", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 },
                new Feature { id = 22, name = "Maps", path = "/map", is_action = true, is_allow = true, is_active = true, is_create = true, is_delete = true, is_modify = true, role_id = 1 }
                );

            builder.Entity<PasswordRule>()
            .HasData(
            new PasswordRule { id = 1, len = 4, is_digit = false, is_lower = false, is_symbol = false, is_upper = false }
            );

            builder.Entity<WeakPassword>()
                .HasData(
                new WeakPassword { id = 1, pattern = "P@ssw0rd", rule_id = 1 },
                new WeakPassword { id = 2, pattern = "password", rule_id = 1 },
                new WeakPassword { id = 3, pattern = "admin", rule_id = 1 },
                new WeakPassword { id = 4, pattern = "123456", rule_id = 1 }
                );

            builder.Entity<Operator>()
                .HasOne(x => x.role)
                .WithMany(x => x.operators)
                .HasForeignKey(x => x.role_id);

            builder.Entity<Role>()
                .HasMany(x => x.features)
                .WithOne(x => x.role)
                .HasForeignKey(x => x.role_id);

            builder.Entity<PasswordRule>()
                .HasMany(x => x.weak_passwords)
                .WithOne(x => x.password_rule)
                .HasForeignKey(x => x.rule_id);

        }
    }


}
