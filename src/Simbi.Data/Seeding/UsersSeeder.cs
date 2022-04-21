using static Simbi.Common.UtilityMethods;
using static Simbi.Common.GlobalConstants;

using Simbi.Data.Common;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Simbi.Data.Seeding;

public class UsersSeeder : ISeeder
{

    public async Task SeedAsync(ApplicationDbContext dbContext)
    {
        var adminRole = new Role
        {
            Name = AdministratorRoleName
        };

        var cashierRole = new Role
        {
            Name = CashierRoleName
        };

        var dataToSeed = new[] {
            new User
            {
                Password = Hash(TestUsersPassword),
                Username = TestUserUsername,
                Roles = new List<Role> { cashierRole },
            },
            new User
            {
                Password = Hash(AdministratorPassword),
                Username = AdministratorUsername,
                Roles = new List<Role> { adminRole },
            }
        };

        cashierRole.Users = new List<User> { dataToSeed[0] };
        adminRole.Users = new List<User> { dataToSeed[1] };

        foreach (var applicationUser in dataToSeed)
        {
            await dbContext.Users.AddAsync(applicationUser);
        }
    }
}
