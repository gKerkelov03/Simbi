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

namespace Simbi.Services.Data;
//TODO: delete this file if you do not need it
public class PurchasesService : IPurchasesService
{
    private readonly BaseRepository<PurchaseEntity> purchasesRepository;
    
    public PurchasesService(BaseRepository<PurchaseEntity> purchasesRepository) => this.purchasesRepository = purchasesRepository;
    
    public async Task Add(PurchaseServiceModel newPurchase) => await this.purchasesRepository.CreateAsync(newPurchase.To<PurchaseEntity>());

    public async Task<IEnumerable<PurchaseServiceModel>> GetAll(Expression<Func<PurchaseServiceModel, bool>> filter) => (await this.purchasesRepository.GetAllAsync(filter?.To<Expression<Func<PurchaseEntity, bool>>>())).To<PurchaseServiceModel>();

    public async Task DeleteById(Guid key) => await this.purchasesRepository.DeleteAsync(key);

    public void AddMultipe(IEnumerable<PurchaseServiceModel> purchasesToAdd) => purchasesToAdd.ToList().ForEach(async purchase => await this.Add(purchase));

    public async Task Update(PurchaseServiceModel purchase) => await this.purchasesRepository.UpdateAsync(purchase.To<PurchaseEntity>());
}
