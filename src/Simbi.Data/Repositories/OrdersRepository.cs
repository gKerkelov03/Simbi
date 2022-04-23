using Microsoft.EntityFrameworkCore;
using Simbi.Data.Common;
using Simbi.Data.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Simbi.Data.Repositories;

public class OrdersRepository : BaseRepository<OrderEntity>
{
    public OrdersRepository(ApplicationDbContext context) : base(context) { }

    public override ValueTask<OrderEntity> GetByIdAsync(Guid id)
    {
        return ValueTask.FromResult(context.Set<OrderEntity>().Where(order => order.Id == id).Include(order => order.Purchases).ThenInclude(purchase => purchase.Material).FirstOrDefault());
    }
}
