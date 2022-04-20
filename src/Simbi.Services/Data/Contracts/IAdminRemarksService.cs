using Simbi.Data.Models;
using System;
using System.Threading.Tasks;

namespace Simbi.Services.Data;

public interface IAdminRemarksService
{
    Task DeleteById(Guid key);

    Task Add(AdminRemark newRemark);
}
