using Simbi.Data.Models;
using System.Threading.Tasks;

namespace Simbi.Data.Seeding
{
    public class OrdersSeeder : ISeeder
    {
        private static Order[] dataToSeed = new[] {
            new Order
            {
                
            },
            new Order
            {
                
            }
        };
        public async Task SeedAsync(ApplicationDbContext dbContext)
        {
            foreach (var order in dataToSeed)
            {
                await dbContext.Orders.AddAsync(order);
            }
        }
    }
}
