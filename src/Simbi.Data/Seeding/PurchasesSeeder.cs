using Simbi.Data.Models;
using System.Threading.Tasks;

namespace Simbi.Data.Seeding;

public class PurchasesSeeder : ISeeder
{
    private static Purchase[] dataToSeed = new[] {
        new Purchase
        {
        },
        new Purchase
        {
        }
    };
    public async Task SeedAsync(ApplicationDbContext dbContext)
    {
        foreach (var purchase in dataToSeed)
        {
            await dbContext.Purchases.AddAsync(purchase);
        }
    }
}
