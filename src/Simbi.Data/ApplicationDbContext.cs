﻿using Microsoft.EntityFrameworkCore;
using Simbi.Data.Models;

namespace Simbi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public DbSet<UserEntity> Users { get; set; }

    public DbSet<RoleEntity> Roles { get; set; }

    public DbSet<AdminRemarkEntity> AdminRemarks { get; set; }

    public DbSet<MaterialEntity> Materials { get; set; }

    public DbSet<PurchaseEntity> Purchases { get; set; }

    public DbSet<OrderEntity> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=.;Database=Simbi;Trusted_Connection=True;");
    
}
