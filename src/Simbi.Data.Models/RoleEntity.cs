using Simbi.Data.Common;

namespace Simbi.Data.Models;

public class RoleEntity : ApplicationEntity
{
    public RoleEntity()
    {
        this.Users = new HashSet<UserEntity>();
    }

    public string Name { get; set; }

    public ICollection<UserEntity> Users { get; set; }
}
