
namespace Simbi.Services.Models;

public class RoleServiceModel : BaseServiceModel
{
    public RoleServiceModel() => this.Users = new HashSet<UserServiceModel>();

    public string Name { get; set; }

    public ICollection<UserServiceModel> Users { get; set; }
}
