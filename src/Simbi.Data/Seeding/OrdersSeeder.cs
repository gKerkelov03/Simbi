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
        Random rnd = new Random();
        int purchasesCount = dbContext.Purchases.Count();
        IList<Purchase> purchases = dbContext.Purchases.ToList();

        var dataToSeed = new[] {
            new Order
            {
                ClientName = "Client 1",
                ClientPhoneNumber = "0895105612",
                Purchases = purchases.Skip(rnd.Next(purchasesCount)).ToList()
            },
            new Order
            {
                ClientName = "Client 2",
                ClientPhoneNumber = "0895105612",
                Purchases = purchases.Skip(rnd.Next(purchasesCount)).ToList()
            }
        };

        foreach (var order in dataToSeed)
        {
            await dbContext.Orders.AddAsync(order);
        }
    }
}
