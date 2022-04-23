using Simbi.Data.Models;

namespace Simbi.Data.Repositories;

public class PurchasesRepository : BaseRepository<PurchaseEntity>
{
    public PurchasesRepository(ApplicationDbContext context) : base(context) { }      
}

