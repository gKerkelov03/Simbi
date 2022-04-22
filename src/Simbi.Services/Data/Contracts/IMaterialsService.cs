using Simbi.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simbi.Services.Data;

public interface IMaterialsService
{
    Task<IEnumerable<Material>> GetAll();

    Task DeleteById(Guid key);

    Task Add(Material newPurchase);
}
