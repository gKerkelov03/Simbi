using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Data.Models
{
    public class Material
    {
        public string Name { get; set; }

        public MaterialType Type { get; set; }

        public double QuantityInKilograms { get; set; }

        public double Fi { get; set; }

        public double PricePerFi { get; }
    }
}
