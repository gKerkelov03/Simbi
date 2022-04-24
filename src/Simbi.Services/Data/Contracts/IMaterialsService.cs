using Simbi.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simbi.Services.Data.Contracts;

public interface IMaterialsService
{
    Task<IEnumerable<MaterialServiceModel>> GetAll(Expression<Func<MaterialServiceModel, bool>> filter = null);

    Task DeleteById(Guid key);

    Task Add(MaterialServiceModel newPurchase);
}
