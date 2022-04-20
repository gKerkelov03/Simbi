using Simbi.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Simbi.Data.Seeding;

public class PurchasesSeeder : ISeeder
{
    public async Task SeedAsync(ApplicationDbContext dbContext)
    {
        var dataToSeed = new[] {
            new Purchase
            {
                Material = dbContext.Materials.FirstOrDefault(material => material.Name == "Material 1"),
                Width = 20,
                Height = 5,
                QuantityInKilograms = 4,
                TotalPrice = 120            
            },
            new Purchase
            {
                Material = dbContext.Materials.FirstOrDefault(material => material.Name == "Material 2"),
                Width = 15,
                Height = 10,
                QuantityInKilograms = 12,
                TotalPrice = 100
            },
            new Purchase
            {
                Material = dbContext.Materials.FirstOrDefault(material => material.Name == "Material 1"),
                Width = 30,
                Height = 30,
                QuantityInKilograms = 30,
                TotalPrice = 10
            }
        };

        foreach (var purchase in dataToSeed)
        {
            await dbContext.Purchases.AddAsync(purchase);
        }
    }
}
