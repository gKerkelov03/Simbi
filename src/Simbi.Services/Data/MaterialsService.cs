using Simbi.Data.Common;
using Simbi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simbi.Services.Data;

public class MaterialsService : IMaterialsService
{
    private readonly BaseRepository<Material> materialsRepository;
    
    public MaterialsService(BaseRepository<Material> purchasesRepository) => this.materialsRepository = purchasesRepository;
    
    public async Task Add(Material newPurchase) => await this.materialsRepository.CreateAsync(newPurchase);

    public async Task<IEnumerable<Material>> GetAll() => await this.materialsRepository.GetAllAsync();

    public async Task DeleteById(Guid key) => await this.materialsRepository.DeleteAsync(key);
   
}
