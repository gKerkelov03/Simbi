using Simbi.Data.Common;
using Simbi.Data.Models;

namespace Simbi.Data.Repositories;

public class MaterialsRepository : BaseRepository<Material>
{
    public MaterialsRepository(ApplicationDbContext context) : base(context) { }
}
