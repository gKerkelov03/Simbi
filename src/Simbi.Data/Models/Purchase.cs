using Simbi.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Data.Models
{
    public class Purchase : ApplicationEntity
    {
        public virtual Material Material { get; set; }

        public double  Quantity { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Price { get; set; }
    }
}
