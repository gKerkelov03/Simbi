using Simbi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simbi.Services.Data;

public interface IAdminRemarksService
{
    Task<IEnumerable<AdminRemark>> GetAll(Expression<Func<AdminRemark, bool>> filter = null);

    Task DeleteById(Guid key);

    Task Add(AdminRemark newRemark);

}
