﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Data.Seeding
{
    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext);
    }
}
