using Simbi.Data;
using Simbi.Data.Models;
using Simbi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Services.Data
{
    public class PurchasesService : IPurchasesService
    {
        private readonly PurchasesRepository purchasesRepository;
        
        public PurchasesService(PurchasesRepository purchasesRepository) => this.purchasesRepository = purchasesRepository;
        
        public async Task Add(Purchase newPurchase)
        {
            await this.purchasesRepository.CreateAsync(newPurchase);
        }

        public async Task AddMultipe(IEnumerable<Purchase> purchasesToAdd)
        {
            foreach (var purchase in purchasesToAdd)
            {
                this.dbContext.Purchases.Add(purchase);
            }

            this.dbContext.SaveChanges();
        }
    }
}
