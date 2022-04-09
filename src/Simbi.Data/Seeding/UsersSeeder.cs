using Simbi.Data.Common;
using System;
using System.Threading.Tasks;

namespace Simbi.Data.Seeding
{
    public class UsersSeeder : ISeeder
    {
        private static ApplicationUser[] dataToSeed = new[] {
            new ApplicationUser
            {               
            },
            new ApplicationUser
            {
            }
        };
        public async Task SeedAsync(ApplicationDbContext dbContext)
        {
            foreach (var applicationUser in dataToSeed)
            {
                await dbContext.Users.AddAsync(applicationUser);
            }
        }
    }
}
