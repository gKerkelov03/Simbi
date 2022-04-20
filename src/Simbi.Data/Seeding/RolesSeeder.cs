using static Simbi.Common.GlobalConstants;
using Simbi.Data.Common;
using System.Threading.Tasks;


namespace Simbi.Data.Seeding;

public class RolesSeeder : ISeeder
{

    public async Task SeedAsync(ApplicationDbContext dbContext)
    {
        var dataToSeed = new[] {
            new Role
            {                
                Name = AdministratorRoleName            
            },            
            new Role
            {                
                Name = CashierRoleName
            },
        };

        foreach(var role in dataToSeed)
        {
            await dbContext.Roles.AddAsync(role);
        }
    }
}
