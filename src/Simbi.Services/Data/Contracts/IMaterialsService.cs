using Simbi.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simbi.Services.Data.Contracts;

public interface IMaterialsService
{
    Task<IEnumerable<MaterialServiceModel>> GetAll();

    Task DeleteById(Guid key);

    Task Add(MaterialServiceModel newPurchase);
}
