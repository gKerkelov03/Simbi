using Simbi.Data.Common;

namespace Simbi.Data.Models;

public class UserEntity : ApplicationEntity
{
    public UserEntity()
    {
        this.Roles = new HashSet<RoleEntity>();
    }

    public string Password { get; set; }

    public string Username { get; set; }

    public ICollection<RoleEntity> Roles { get; set; }
}
