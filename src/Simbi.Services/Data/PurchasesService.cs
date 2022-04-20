using Simbi.Data.Common;
using Simbi.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbi.Services.Data;

public class PurchasesService : IPurchasesService
{
    private readonly BaseRepository<Purchase> purchasesRepository;
    
    public PurchasesService(BaseRepository<Purchase> purchasesRepository) => this.purchasesRepository = purchasesRepository;
    
    public async Task Add(Purchase newPurchase) => await this.purchasesRepository.CreateAsync(newPurchase);

    public void AddMultipe(IEnumerable<Purchase> purchasesToAdd) => purchasesToAdd.ToList().ForEach(async purchase => await this.Add(purchase));        
}
