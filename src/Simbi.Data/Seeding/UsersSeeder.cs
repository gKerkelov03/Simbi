using static Simbi.Common.UtilityMethods;
using static Simbi.Common.GlobalConstants;
using System.Threading.Tasks;
using System.Collections.Generic;
using Simbi.Data.Models;

namespace Simbi.Data.Seeding;

public class UsersSeeder : ISeeder
{

    public async Task SeedAsync(ApplicationDbContext dbContext)
    {
        var adminRole = new RoleEntity
        {
            Name = AdministratorRoleName
        };

        var cashierRole = new RoleEntity
        {
            Name = CashierRoleName
        };

        var dataToSeed = new[] {
            new UserEntity
            {
                Password = Hash(TestUsersPassword),
                Username = TestUserUsername,
                Roles = new List<RoleEntity> { cashierRole },
            },
            new UserEntity
            {
                Password = Hash(AdministratorPassword),
                Username = AdministratorUsername,
                Roles = new List<RoleEntity> { adminRole },
            }
        };

        cashierRole.Users = new List<UserEntity> { dataToSeed[0] };
        adminRole.Users = new List<UserEntity> { dataToSeed[1] };

        foreach (var applicationUser in dataToSeed)
        {
            await dbContext.Users.AddAsync(applicationUser);
        }
    }
}
