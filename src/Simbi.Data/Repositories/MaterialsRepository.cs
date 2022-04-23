using Simbi.Data.Models;

namespace Simbi.Data.Repositories;

public class MaterialsRepository : BaseRepository<MaterialEntity>
{
    public MaterialsRepository(ApplicationDbContext context) : base(context) { }
}
