using Simbi.Data.Models;
using System.Collections.Generic;

namespace Simbi.Services.Data
{
    public interface IPurchasesService
    {
        void AddMultipe(IEnumerable<Purchase> purchases);

        void Add(Purchase newPurchase);
    }
}
