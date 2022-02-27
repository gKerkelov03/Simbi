using Simbi.Data.Common;
using System.Threading.Tasks;

namespace Simbi.Data.Seeding
{
    public class RolesSeeder : ISeeder
    {
        private static Role[] dataToSeed = new[] {
            new Role
            {
                Name = "Admin"
            },
            new Role
            {
                Name = "Admin"
            }            
        };
        public async Task SeedAsync(ApplicationDbContext dbContext)
        {
            foreach(var role in dataToSeed)
            {
                await dbContext.Roles.AddAsync(role);
            }
        }
    }
}
