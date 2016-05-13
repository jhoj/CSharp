using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace WebApp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Machine> Machine { get; set; }
        public DbSet<OilConsumption> OilConsumption { get; set; }
        public DbSet<Production> Production { get; set; }
        public DbSet<RecommendedOilConsumption> RecommendedOilConsumption { get; set; }
    }
}
