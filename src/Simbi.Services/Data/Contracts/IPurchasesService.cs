using Simbi.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simbi.Services.Data.Contracts;

public interface IPurchasesService
{
    Task<IEnumerable<PurchaseServiceModel>> GetAll();

    Task DeleteById(Guid key);

    Task Add(PurchaseServiceModel newPurchase);
}
