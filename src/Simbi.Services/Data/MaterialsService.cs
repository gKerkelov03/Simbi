using Simbi.Data.Models;
using Simbi.Data.Repositories;
using Simbi.Mappings;
using Simbi.Services.Data.Contracts;
using Simbi.Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simbi.Services.Data;

public class MaterialsService : IMaterialsService
{
    private readonly BaseRepository<MaterialEntity> materialsRepository;
    
    public MaterialsService(BaseRepository<MaterialEntity> purchasesRepository) => this.materialsRepository = purchasesRepository;
    
    public async Task Add(MaterialServiceModel newPurchase) => await this.materialsRepository.CreateAsync(newPurchase.To<MaterialEntity>());

    public async Task<IEnumerable<MaterialServiceModel>> GetAll() => (await this.materialsRepository.GetAllAsync()).To<MaterialServiceModel>();

    public async Task DeleteById(Guid key) => await this.materialsRepository.DeleteAsync(key);   
}
