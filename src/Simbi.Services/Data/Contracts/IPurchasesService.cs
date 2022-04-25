using Simbi.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simbi.Services.Data.Contracts;

public interface IPurchasesService
{
    Task<IEnumerable<PurchaseServiceModel>> GetAll(Expression<Func<PurchaseServiceModel, bool>> filter = null);

    Task DeleteById(Guid key);

    Task Add(PurchaseServiceModel newPurchase);

    Task Update(PurchaseServiceModel material);
}
