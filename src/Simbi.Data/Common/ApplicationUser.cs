using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Data.Common
{
    public class ApplicationUser : ApplicationEntity
    {
        public string Password { get; set; }
        public string Username { get; set; }

        public Role Role { get; set; }
    }
}
