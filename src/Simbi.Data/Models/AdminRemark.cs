using Simbi.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Data.Models
{
    public class AdminRemark : BaseEntity<string>
    {
        public string Text { get; set; }

        public virtual ApplicationUser Creator { get; set; }
    }
}
