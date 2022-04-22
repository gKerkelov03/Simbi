using Simbi.Data.Common;
using Simbi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Simbi.Data.Repositories;

public class PurchasesRepository : BaseRepository<Purchase>
{
    public PurchasesRepository(ApplicationDbContext context) : base(context) { }      
}

