using Microsoft.EntityFrameworkCore;
using Simbi.Data.Common;
using Simbi.Data.Models;
using System;

namespace Simbi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public ApplicationDbContext() { }

        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<AdminRemark> AdminRemarks { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<Purchase> Purchases { get; set; }

        public DbSet<Order> Orders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=Simbi;TrustedConnection=True;");
        }
    }
}
