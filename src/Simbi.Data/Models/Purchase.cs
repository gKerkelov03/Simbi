using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Data.Models
{
    public class Purchase
    {
        public double  Quantity { get; set; }

        public virtual Material Material { get; set; }

        public decimal Price { get; set; }
    }
}
