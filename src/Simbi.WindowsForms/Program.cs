using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Simbi.Data;
using Simbi.Data.Seeding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Simbi.Data.Repositories;
using Simbi.Data.Models;
using Simbi.Services.Data;
using Simbi.Services.Data.Contracts;
using Simbi.Services;
using Simbi.Services.Data.Simbi.Services.Data;
using Simbi.WindowsForms.Infrastructure;

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
        
        #region Seed Data

        var dbContext = new ApplicationDbContext();
        dbContext.Database.EnsureDeleted();
        if (dbContext.Database.GetPendingMigrations().Any())
        {
            dbContext.Database.Migrate();
            new AppSeeder().SeedAsync(new ApplicationDbContext()).GetAwaiter().GetResult();
        }

        #endregion

        #region Setup Host
        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddTransient<ApplicationDbContext, ApplicationDbContext>();

                serviceCollection.AddTransient<BaseRepository<PurchaseEntity>, PurchasesRepository>();
                serviceCollection.AddTransient<BaseRepository<MaterialEntity>, MaterialsRepository>();
                serviceCollection.AddTransient<BaseRepository<AdminRemarkEntity>, AdminRemarksRepository>();
                serviceCollection.AddTransient<BaseRepository<OrderEntity>, OrdersRepository>();
                serviceCollection.AddTransient<BaseRepository<RoleEntity>, RolesRepository>();
                                    
                serviceCollection.AddTransient<IAdminRemarksService, AdminRemarksService>();
                serviceCollection.AddTransient<IMaterialsService, MaterialsService>();
                serviceCollection.AddTransient<IOrdersService, OrdersService>();
                serviceCollection.AddTransient<IPurchasesService, PurchasesService>();
                serviceCollection.AddTransient<UserManager, UserManager>();
                                    
                serviceCollection.AddTransient<Redirector, Redirector>();
                                     
                serviceCollection.AddTransient<HomePage, HomePage>();
            })
            .Build();
        #endregion

        Application.Run(host.Services.GetRequiredService<HomePage>());
    }
}
