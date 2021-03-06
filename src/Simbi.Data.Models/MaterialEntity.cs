using Simbi.Data.Common;

namespace Simbi.Data.Models;

public class MaterialEntity : ApplicationEntity
{
    public MaterialEntity()
    {
        this.PurchasesContainingIt = new HashSet<PurchaseEntity>();
    }
    public string Name { get; set; }

    public string Description { get; set; }

    public double QuantityAvailableInKilograms { get; set; }

    public string Size { get; set; } // има л ф б някви obiknoveno sa bukva cifra ma ima i nqkvi dr izvrateni

    public double PricePerKilogram { get; set; }  

    public bool IsDeleted { get; set; }

    public virtual ICollection<PurchaseEntity> PurchasesContainingIt { get; set; }
}
