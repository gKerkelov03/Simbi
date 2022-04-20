using Simbi.Data.Common;

namespace Simbi.Data.Models;

public class Purchase : ApplicationEntity
{
    public virtual Material Material { get; set; }

    public double  QuantityInKilograms { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double TotalPrice { get; set; }
}
