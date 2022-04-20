using Simbi.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simbi.Services.Data;

public interface IOrdersService
{
    Task<IEnumerable<Order>> GetAll();

    Task DeleteById(Guid key);

    Task Add(Order newOrder);
}
