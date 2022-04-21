using Simbi.Data.Common;
using System.Collections.Generic;

namespace Simbi.Data.Models;

public class Order : ApplicationEntity
{
    public string ClientName { get; set; }

    public string ClientPhoneNumber { get; set; }

    public virtual System.Collections.Generic.ICollection<Purchase> Purchases { get; set; }
}
