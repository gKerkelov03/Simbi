using Simbi.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Simbi.Data.Seeding;

public class AdminRemarksSeeder : ISeeder
{

    public async Task SeedAsync(ApplicationDbContext dbContext)
    {
        var dataToSeed = new[] {
            new AdminRemarkEntity
            {
                Creator = dbContext.Users.FirstOrDefault(user => user.Username == "testuser1"),
                Text = "Remark test 1"
            },
            new AdminRemarkEntity
            {
                Creator = dbContext.Users.FirstOrDefault(user => user.Username == "angel"),
                Text = "Remark test 2"
            }
        };

        foreach (var adminRemark in dataToSeed)
        {
            await dbContext.AdminRemarks.AddAsync(adminRemark);
        }
    }
}