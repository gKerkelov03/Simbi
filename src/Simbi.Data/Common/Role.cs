using System.Collections.Generic;

namespace Simbi.Data.Common;

public class Role : ApplicationEntity
{
    public string Name { get; set; }

    public ICollection<User> Users { get; set; }
}
