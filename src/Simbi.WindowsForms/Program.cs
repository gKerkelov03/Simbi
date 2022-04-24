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
        
        #region SeedData

        var dbContext = new ApplicationDbContext();
       //dbContext.Database.EnsureDeleted();
        if (dbContext.Database.GetPendingMigrations().Any())
        {
            dbContext.Database.Migrate();
            new AppSeeder().SeedAsync(new ApplicationDbContext()).GetAwaiter().GetResult();
        }

        #endregion

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices(serviceCollection =>
            {
                serviceCollection.AddTransient<ApplicationDbContext, ApplicationDbContext>();

                serviceCollection.AddSingleton<BaseRepository<PurchaseEntity>, PurchasesRepository>();
                serviceCollection.AddSingleton<BaseRepository<MaterialEntity>, MaterialsRepository>();
                serviceCollection.AddSingleton<BaseRepository<AdminRemarkEntity>, AdminRemarksRepository>();
                serviceCollection.AddSingleton<BaseRepository<OrderEntity>, OrdersRepository>();
                serviceCollection.AddSingleton<BaseRepository<RoleEntity>, RolesRepository>();

                serviceCollection.AddSingleton<IAdminRemarksService, AdminRemarksService>();
                serviceCollection.AddSingleton<IMaterialsService, MaterialsService>();
                serviceCollection.AddSingleton<IOrdersService, OrdersService>();
                serviceCollection.AddSingleton<IPurchasesService, PurchasesService>();
                serviceCollection.AddSingleton<UserManager, UserManager>();

                serviceCollection.AddSingleton<Redirector, Redirector>();

                serviceCollection.AddSingleton<HomePage, HomePage>();
            })
            .Build();

        Application.Run(host.Services.GetRequiredService<HomePage>());
    }
}
