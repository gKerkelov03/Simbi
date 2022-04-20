using Simbi.Data.Common;
using Simbi.Data.Models;

namespace Simbi.Data.Repositories;

public class AdminRemarksRepository : BaseRepository<AdminRemark>
{
    public AdminRemarksRepository(ApplicationDbContext context) : base(context) { }
}
