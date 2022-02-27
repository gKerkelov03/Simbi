using Simbi.Data;
using Simbi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Services.Data
{
    namespace Simbi.Services.Data
    {
        public class OrdersService : IOrdersService
        {
            private ApplicationDbContext dbContext;
            public OrdersService(ApplicationDbContext dbContext) => this.dbContext = dbContext;
            
            public void Add(Order newOrder)
            {
                this.dbContext.Orders.Add(newOrder);
                this.dbContext.SaveChanges();
            }

           public void DeleteById(string key) => this.dbContext.Orders.Remove(this.dbContext.Orders.Find(key));
            
            public IQueryable<Order> GetAll() => this.dbContext.Orders;
        }
    }
}
