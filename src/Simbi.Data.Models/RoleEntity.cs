using Simbi.Data.Common;

namespace Simbi.Data.Models;

public class RoleEntity : ApplicationEntity
{
    public string Name { get; set; }

    public ICollection<UserEntity> Users { get; set; }
}
