﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Data.Common
{
    public class Role : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
