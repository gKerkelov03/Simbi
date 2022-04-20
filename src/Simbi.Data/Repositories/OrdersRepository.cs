using Simbi.Data.Common;
using Simbi.Data.Models;

namespace Simbi.Data.Repositories;

public class OrdersRepository : BaseRepository<Order>
{
    public OrdersRepository(ApplicationDbContext context) : base(context) { }
}
