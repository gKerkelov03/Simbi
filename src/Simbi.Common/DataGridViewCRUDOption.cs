﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Common;

[Flags]
public enum DataGridViewCRUDOption
{
    None = 0,
    Create = 1,
    Update = 2,
    Delete = 4
}
