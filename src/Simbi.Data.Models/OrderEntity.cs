using Simbi.Data.Common;

namespace Simbi.Data.Models;

public class OrderEntity : ApplicationEntity
{
    public string ClientName { get; set; }

    public string ClientPhoneNumber { get; set; }

    public virtual ICollection<PurchaseEntity> Purchases { get; set; }
}
