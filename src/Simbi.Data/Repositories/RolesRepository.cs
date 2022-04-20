using Simbi.Data.Common;

namespace Simbi.Data.Repositories;

public class RolesRepository : BaseRepository<Role>
{
    public RolesRepository(ApplicationDbContext context) : base(context) { }
}
