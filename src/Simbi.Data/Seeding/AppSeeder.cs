using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simbi.Data.Seeding
{
    class AppSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext)
        {
            var seeders = new List<ISeeder>
                          {
                              new RolesSeeder(),
                          };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
