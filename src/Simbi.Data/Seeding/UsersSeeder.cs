using static Simbi.Common.UtilityMethods;
using static Simbi.Common.GlobalConstants;

using Simbi.Data.Common;
using System.Threading.Tasks;
using System.Linq;

namespace Simbi.Data.Seeding;

public class UsersSeeder : ISeeder
{

    public async Task SeedAsync(ApplicationDbContext dbContext)
    {
        var dataToSeed = new[] {
            new User
            {
                Password = Hash(TestUsersPassword),
                Username = "testuser1",
                Role = dbContext.Roles.FirstOrDefault(role => role.Name == CashierRoleName),
            },
            new User
            {
                Password = Hash(AdministratorPassword),
                Username = "angel",
                Role = dbContext.Roles.FirstOrDefault(role => role.Name == AdministratorRoleName),
            }
        };

        foreach (var applicationUser in dataToSeed)
        {
            await dbContext.Users.AddAsync(applicationUser);
        }
    }
}
