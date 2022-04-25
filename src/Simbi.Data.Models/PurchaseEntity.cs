using Simbi.Data.Common;

namespace Simbi.Data.Models;

public class PurchaseEntity : ApplicationEntity
{
    public virtual MaterialEntity Material { get; set; }

    public double  QuantityInKilograms { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double Price { get; set; }
}
