using Simbi.Data.Common;
using Simbi.Data.Models;
using Simbi.Mappings;
using Simbi.Services.Data.Contracts;
using Simbi.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simbi.Services.Data;

public class AdminRemarksService : IAdminRemarksService
{
    private readonly BaseRepository<AdminRemarkEntity> adminRemarksRepository;
    
    public AdminRemarksService(BaseRepository<AdminRemarkEntity> adminRemarksRepository) => this.adminRemarksRepository = adminRemarksRepository;
    
    public async Task Add(AdminRemarkServiceModel newRemark) => await this.adminRemarksRepository.CreateAsync(newRemark.To<AdminRemarkEntity>());

    public async Task<IEnumerable<AdminRemarkServiceModel>> GetAll(Expression<Func<AdminRemarkServiceModel, bool>> filter = null) => (await this.adminRemarksRepository.GetAllAsync(filter.To<Expression<Func<AdminRemarkEntity, bool>>>())).To<AdminRemarkServiceModel>();

    public async Task DeleteById(Guid key) => await this.adminRemarksRepository.DeleteAsync(key);    
}
