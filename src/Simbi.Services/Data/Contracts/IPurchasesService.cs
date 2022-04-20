using Simbi.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simbi.Services.Data;

public interface IPurchasesService
{
    void AddMultipe(IEnumerable<Purchase> purchases);

    Task Add(Purchase newPurchase);
}
