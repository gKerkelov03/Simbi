using Simbi.Data.Common;

namespace Simbi.Data.Models;

public class OrderEntity : ApplicationEntity
{
    public OrderEntity()
    {
        this.Purchases = new HashSet<PurchaseEntity>();
    }

    public string ClientName { get; set; }

    public string ClientPhoneNumber { get; set; }

    public virtual ICollection<PurchaseEntity> Purchases { get; set; }
}
