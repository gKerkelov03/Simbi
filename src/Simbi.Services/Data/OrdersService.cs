using Simbi.Data.Common;
using Simbi.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simbi.Services.Data
{
    namespace Simbi.Services.Data
    {
        public class OrdersService : IOrdersService
        {
            private readonly BaseRepository<Order> ordersRepository;

            public OrdersService(BaseRepository<Order> ordersRepository) => this.ordersRepository = ordersRepository;
            

            public async Task Add(Order newOrder) => await this.ordersRepository.CreateAsync(newOrder);

            public async Task DeleteById(Guid key) => await this.ordersRepository.DeleteAsync(key);
            
            public async Task<IEnumerable<Order>> GetAll() => await this.ordersRepository.GetAllAsync();
        }
    }
}
