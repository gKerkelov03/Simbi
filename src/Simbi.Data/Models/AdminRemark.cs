﻿using Simbi.Data.Common;

namespace Simbi.Data.Models
{
    public class AdminRemark : ApplicationEntity
    {
        public string Text { get; set; }

        public virtual User Creator { get; set; }
    }
}
