using Simbi.Data.Common;
using Simbi.Data.Models;

namespace Simbi.Data.Repositories
{
    public class PurchasesRepository : BaseRepository<Order>
    {
        public PurchasesRepository(ApplicationDbContext context) : base(context) { }
    }
}