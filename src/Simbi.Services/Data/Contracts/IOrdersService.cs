using Simbi.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simbi.Services.Data.Contracts;

public interface IOrdersService
{
    Task<IEnumerable<OrderServiceModel>> GetAll();

    Task DeleteById(Guid key);

    Task<OrderServiceModel> GetById(Guid id);

    Task Add(OrderServiceModel newOrder);
}
