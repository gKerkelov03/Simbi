using Simbi.Data.Common;
using System.Threading.Tasks;

namespace Simbi.Data.Seeding;

public class UsersSeeder : ISeeder
{
    private readonly static User[] dataToSeed = new[] {
        new User
        {               
        },
        new User
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
