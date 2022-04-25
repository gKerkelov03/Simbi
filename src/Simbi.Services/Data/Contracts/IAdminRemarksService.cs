using Simbi.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simbi.Services.Data.Contracts;

public interface IAdminRemarksService
{
    Task<IEnumerable<AdminRemarkServiceModel>> GetAll(Expression<Func<AdminRemarkServiceModel, bool>> filter = null);    

    Task DeleteById(Guid key);

    Task Add(AdminRemarkServiceModel newRemark);

    Task Update(AdminRemarkServiceModel remark);

}
