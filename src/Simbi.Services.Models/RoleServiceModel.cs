
namespace Simbi.Services.Models;

public class RoleServiceModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ICollection<UserServiceModel> Users { get; set; }
}
