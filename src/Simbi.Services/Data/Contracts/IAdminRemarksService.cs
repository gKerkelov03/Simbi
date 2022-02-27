using Simbi.Data.Models;

namespace Simbi.Services.Data
{
    public interface IAdminRemarksService
    {
        void DeleteById(string key);

        void Add(AdminRemark newRemark);
    }
}
