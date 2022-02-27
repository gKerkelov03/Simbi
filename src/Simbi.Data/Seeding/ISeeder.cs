using System.Threading.Tasks;

namespace Simbi.Data.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext);
    }
}
