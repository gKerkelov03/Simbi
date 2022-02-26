using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simbi.Data.Common;

namespace Simbi.Data.Models
{
    public class Material : BaseEntity<string>
    {
        public string Description { get; set; }

        public double QuantityAvailableInKilograms { get; set; }

        public string Size { get; set; } // има л ф б някви obiknoveno sa bukva cifra ma ima i nqkvi dr izvrateni
        public double PricePerKilogram { get; set; }        
    }
}
