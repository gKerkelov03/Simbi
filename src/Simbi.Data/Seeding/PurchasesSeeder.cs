using Simbi.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Simbi.Data.Seeding;

public class PurchasesSeeder : ISeeder
{
    public async Task SeedAsync(ApplicationDbContext dbContext)
    {
        var dataToSeed = new[] {
            new PurchaseEntity
            {
                Material = dbContext.Materials.FirstOrDefault(material => material.Name == "Material 1"),
                Width = 20,
                Height = 5,
                QuantityInKilograms = 4,
                Price = 120            
            },
            new PurchaseEntity
            {
                Material = dbContext.Materials.FirstOrDefault(material => material.Name == "Material 2"),
                Width = 15,
                Height = 10,
                QuantityInKilograms = 12,
                Price = 100
            },
            new PurchaseEntity
            {
                Material = dbContext.Materials.FirstOrDefault(material => material.Name == "Material 1"),
                Width = 30,
                Height = 30,
                QuantityInKilograms = 30,
                Price = 10
            }
        };

        foreach (var purchase in dataToSeed)
        {
            await dbContext.Purchases.AddAsync(purchase);
        }
    }
}
