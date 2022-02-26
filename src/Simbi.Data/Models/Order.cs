using Simbi.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Data.Models
{
    public class Order : BaseEntity<string>
    {
        public string ClientName { get; set; }

        public string ClientPhoneNumber { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
