using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Data.Common
{
    public class ApplicationUser : BaseEntity<string>
    {
        public string Password { get; set; }
        public string Username { get; set; }
    }
}
