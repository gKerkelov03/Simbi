using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Simbi.Data;
using Simbi.Data.Seeding;

namespace Simbi.WindowsForms;

static class Program
{  
    [STAThread]
    static void Main()
    {
        #region Settings
        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        #endregion

        #region SeedData

        var dbContext = new ApplicationDbContext();
        //dbContext.Database.EnsureDeleted();
        if (dbContext.Database.GetPendingMigrations().Any())
        {
            dbContext.Database.Migrate();
            new AppSeeder().SeedAsync(new ApplicationDbContext()).GetAwaiter().GetResult();
        }

        #endregion

        Application.Run(new HomePage());
    }
}
