using Simbi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbi.Data.Seeding;

public class OrdersSeeder : ISeeder
{
    public async Task SeedAsync(ApplicationDbContext dbContext)
    {        
        var dataToSeed = new[] {
            new Order
            {
                ClientName = "Client 1",
                ClientPhoneNumber = "0895105612",
                Purchases = new List<Purchase>
                {
                    dbContext.Purchases.FirstOrDefault(),                    
                }
            },
            new Order
            {
                ClientName = "Client 2",
                ClientPhoneNumber = "0895105612",
                Purchases = dbContext.Purchases.ToList().Skip(1).ToList(),                    
                
            }
        };

        foreach (var order in dataToSeed)
        {
            await dbContext.Orders.AddAsync(order);
        }
    }
}
