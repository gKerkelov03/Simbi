using Simbi.Data.Common;

namespace Simbi.Services.Models;

public class UserServiceModel
{
    public string Password { get; set; }

    public string Username { get; set; }

    public ICollection<RoleServiceModel> Roles { get; set; }
}
