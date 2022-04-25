using Microsoft.EntityFrameworkCore;
using Simbi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simbi.Data.Repositories;

public class OrdersRepository : BaseRepository<OrderEntity>
{
    public OrdersRepository(ApplicationDbContext context) : base(context) { }

    //TODO: debunk the AsNoTracking bug
    public override ValueTask<OrderEntity> GetByIdAsync(Guid id) => ValueTask.FromResult(context.Set<OrderEntity>().Where(order => order.Id == id).Include(order => order.Purchases).ThenInclude(purchase => purchase.Material).FirstOrDefault());

    public override async Task<ICollection<OrderEntity>> GetAllAsync(Expression<Func<OrderEntity, bool>> filter = null)
    {
        var set = context.Set<OrderEntity>().AsQueryable();

        if(filter != null)
        {
            set = set.Where(filter);
        }

        var orders = set.Include(order => order.Purchases).ThenInclude(purchase => purchase.Material).ToListAsync();

        return await orders;
    }
}
