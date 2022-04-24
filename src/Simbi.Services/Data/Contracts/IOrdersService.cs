using Simbi.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simbi.Services.Data.Contracts;

public interface IOrdersService
{
    Task<IEnumerable<OrderServiceModel>> GetAll(Expression<Func<OrderServiceModel, bool>> filter = null);

    Task DeleteById(Guid key);

    Task<OrderServiceModel> GetById(Guid id);

    Task Add(OrderServiceModel newOrder);
}
