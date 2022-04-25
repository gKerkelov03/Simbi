using Simbi.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simbi.Services.Data.Contracts;

public interface IMaterialsService
{
    Task<IEnumerable<MaterialServiceModel>> GetAll(Expression<Func<MaterialServiceModel, bool>> filter = null);
        
    Task<MaterialServiceModel> GetById(Guid key);

    Task DeleteById(Guid key);

    Task Update(MaterialServiceModel material);

    Task Add(MaterialServiceModel newPurchase);
}
