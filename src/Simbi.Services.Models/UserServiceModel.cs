
namespace Simbi.Services.Models;

public class UserServiceModel
{
    public UserServiceModel() => this.Roles = new HashSet<RoleServiceModel>();
    public string Password { get; set; }

    public string Username { get; set; }

    public ICollection<RoleServiceModel> Roles { get; set; }
}
