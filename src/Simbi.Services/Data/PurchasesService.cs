using Simbi.Data;
using Simbi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Services.Data
{
    public class PurchasesService : IPurchasesService
    {
        private ApplicationDbContext dbContext;
        public PurchasesService(ApplicationDbContext dbContext)=>this.dbContext = dbContext;
        
        public void Add(Purchase newPurchase)
        {
            this.dbContext.Purchases.Add(newPurchase);
            this.dbContext.SaveChanges();
        }

        public void AddMultipe(IEnumerable<Purchase> purchases)
        {
            foreach (var purchase in purchases)
            {
                this.dbContext.Purchases.Add(purchase);
            }

            this.dbContext.SaveChanges();
        }
    }
}
