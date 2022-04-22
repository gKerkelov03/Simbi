using Microsoft.EntityFrameworkCore;
using Simbi.Data.Common;
using Simbi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simbi.Data.Repositories;

public class AdminRemarksRepository : BaseRepository<AdminRemark>
{
    public AdminRemarksRepository(ApplicationDbContext context) : base(context) { }

    public override async Task<ICollection<AdminRemark>> GetAllAsync(Expression<Func<AdminRemark, bool>> filter = null)
    {
        var set = context.Set<AdminRemark>().AsQueryable();

        if (filter != null)
        {
            set = set.Where(filter);        
        }

        set = set.Include(adminRemark => adminRemark.Creator);

        return await set.ToListAsync();
    }
}
