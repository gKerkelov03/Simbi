using Microsoft.EntityFrameworkCore;
using Simbi.Data.Common;
using System;

namespace Simbi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ApplicationUser> Users { get; set; }
    }
}
