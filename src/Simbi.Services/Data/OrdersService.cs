using Simbi.Data.Models;
using Simbi.Data.Repositories;
using Simbi.Mappings;
using Simbi.Services.Data.Contracts;
using Simbi.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simbi.Services.Data
{
    namespace Simbi.Services.Data
    {
        public class OrdersService : IOrdersService
        {
            private readonly BaseRepository<OrderEntity> ordersRepository;

            public OrdersService(BaseRepository<OrderEntity> ordersRepository) => this.ordersRepository = ordersRepository;

            public async Task Add(OrderServiceModel newOrder) => await this.ordersRepository.CreateAsync(newOrder.To<OrderEntity>());

            public async Task DeleteById(Guid key) => await this.ordersRepository.DeleteAsync(key);

            public async Task<OrderServiceModel> GetById(Guid key) => (await this.ordersRepository.GetByIdAsync(key)).To<OrderServiceModel>();

            public async Task<IEnumerable<OrderServiceModel>> GetAll(Expression<Func<OrderServiceModel, bool>> filter = null) => (await this.ordersRepository.GetAllAsync(filter?.To<Expression<Func<OrderEntity, bool>>>())).To<OrderServiceModel>();
        }
    }
}
