using Simbi.Data.Common;
using Simbi.Data.Models;

namespace Simbi.Data.Repositories;

public class PurchasesRepository : BaseRepository<Purchase>
{
    public PurchasesRepository(ApplicationDbContext context) : base(context) { }
}
