using Simbi.Data.Models;
using System.Linq;

namespace Simbi.Services.Data
{
    public interface IOrdersService
    {
        IQueryable<Order> GetAll();

        void DeleteById(string key);

        void Add(Order newOrder);
    }
}
