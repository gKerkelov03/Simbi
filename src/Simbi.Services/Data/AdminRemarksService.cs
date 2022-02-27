using Simbi.Data;
using Simbi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Services.Data
{
    public class AdminRemarksService : IAdminRemarksService
    {
        private ApplicationDbContext dbContext;
        public AdminRemarksService(ApplicationDbContext dbContext) => this.dbContext = dbContext;

        public void Add(AdminRemark newRemark)
        {
            this.dbContext.AdminRemarks.Add(newRemark);
            this.dbContext.SaveChanges();
        }

        public void DeleteById(string key) => this.dbContext.AdminRemarks.Remove(this.dbContext.AdminRemarks.Find(key));
    }
}
