using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simbi.Data.Seeding;

public class AppSeeder : ISeeder
{
    public async Task SeedAsync(ApplicationDbContext dbContext)
    {
        var seeders = new List<ISeeder>
        {
            new RolesSeeder(),
            new UsersSeeder(),
            new AdminRemarksSeeder(),

            new OrdersSeeder(),
            new MaterialsSeeder(),
            new PurchasesSeeder(),     
        };

        foreach (var seeder in seeders)
        {
            await seeder.SeedAsync(dbContext);
            await dbContext.SaveChangesAsync();
        }
    }
}
