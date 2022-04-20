using Simbi.Data.Common;
using Simbi.Data.Models;

namespace Simbi.Data.Repositories
{
    public class UsersRepository : BaseRepository<User>
    {
        public UsersRepository(ApplicationDbContext context) : base(context) { }
    }
}