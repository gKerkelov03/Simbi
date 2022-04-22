﻿using Simbi.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Simbi.Services.Data;

public interface IPurchasesService
{
    Task<IEnumerable<Purchase>> GetAll();

    Task DeleteById(Guid key);

    Task Add(Purchase newPurchase);
}
