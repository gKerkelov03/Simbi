using Simbi.Data.Models;
using System.Threading.Tasks;

namespace Simbi.Data.Seeding;

public class MaterialsSeeder : ISeeder
{

    public async Task SeedAsync(ApplicationDbContext dbContext)
    {
        var dataToSeed = new[] {
            new MaterialEntity
            {
                Name = "Material 1",
                QuantityAvailableInKilograms = 100,
                Description = "Material 1 description",
                PricePerKilogram = 15,
                Size = "l"
            },
            new MaterialEntity
            {
                Name = "Material 2",
                QuantityAvailableInKilograms = 100,
                Description = "Material 1 description",
                PricePerKilogram = 15,
                Size = "l"
            }
        };

        foreach (var material in dataToSeed)
        {
            await dbContext.Materials.AddAsync(material);
        }
    }
}