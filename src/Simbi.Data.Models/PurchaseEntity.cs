using Simbi.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Simbi.Data.Models;

public class PurchaseEntity : ApplicationEntity
{
    [ForeignKey("Material")]
    public Guid? MaterialId { get; set; }
    public virtual MaterialEntity? Material { get; set; }

    public double  QuantityInKilograms { get; set; }

    public double Width { get; set; }

    public double Height { get; set; }

    public double Price { get; set; }
}
