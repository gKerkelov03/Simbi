using Simbi.Data.Common;
using Simbi.Data.Models;

namespace Simbi.Data.Repositories
{
    public class RolesRepository : BaseRepository<Order>
    {
        public RolesRepository(ApplicationDbContext context) : base(context) { }
    }
}