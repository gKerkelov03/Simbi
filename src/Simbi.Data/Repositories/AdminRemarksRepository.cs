using Microsoft.EntityFrameworkCore;
using Simbi.Data.Common;
using Simbi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simbi.Data.Repositories;

public class AdminRemarksRepository : BaseRepository<AdminRemarkEntity>
{
    public AdminRemarksRepository(ApplicationDbContext context) : base(context) { }

    public override async Task<ICollection<AdminRemarkEntity>> GetAllAsync(Expression<Func<AdminRemarkEntity, bool>> filter = null)
    {
        var set = context.Set<AdminRemarkEntity>().AsQueryable();

        if (filter != null)
        {
            set = set.Where(filter);        
        }

        set = set.Include(AdminRemarkEntity => AdminRemarkEntity.Creator);

        return await set.ToListAsync();
    }
}
