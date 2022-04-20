using Microsoft.EntityFrameworkCore;
using Simbi.Data.Common;
using Simbi.Data.Models;

namespace Simbi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<AdminRemark> AdminRemarks { get; set; }

    public DbSet<Material> Materials { get; set; }

    public DbSet<Purchase> Purchases { get; set; }

    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=.;Database=Simbi;Trusted_Connection=True;");
    
}
