using System.Collections.Generic;

namespace Simbi.Data.Common;

public class User : ApplicationEntity
{
    public string Password { get; set; }

    public string Username { get; set; }

    public ICollection<Role> Roles { get; set; }
}
