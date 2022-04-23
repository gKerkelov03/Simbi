using Simbi.Data.Models;

namespace Simbi.Data.Repositories;

public class RolesRepository : BaseRepository<RoleEntity>
{
    public RolesRepository(ApplicationDbContext context) : base(context) { }
}
