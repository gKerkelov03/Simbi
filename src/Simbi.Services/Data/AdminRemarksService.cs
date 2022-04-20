using Simbi.Data.Common;
using Simbi.Data.Models;
using System;
using System.Threading.Tasks;

namespace Simbi.Services.Data;

public class AdminRemarksService : IAdminRemarksService
{
    private readonly BaseRepository<AdminRemark> adminRemarksRepository;
    
    public AdminRemarksService(BaseRepository<AdminRemark> adminRemarksRepository) => this.adminRemarksRepository = adminRemarksRepository;
    
    public async Task Add(AdminRemark newRemark) => await this.adminRemarksRepository.CreateAsync(newRemark);            
    
    public async Task DeleteById(Guid key) => await this.adminRemarksRepository.DeleteAsync(key);
}
