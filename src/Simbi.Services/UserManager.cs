using static Simbi.Common.GlobalConstants;
using static Simbi.Common.UtilityMethods;
using Simbi.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Simbi.Data.Models;
using Simbi.Services.Models;
using Simbi.Mappings;

namespace Simbi.Services;

public class UserManager
{
    private static UserEntity CurrentUser { get; set; }

    private readonly ApplicationDbContext dbContext;

    public UserManager(ApplicationDbContext dbContext) => this.dbContext = dbContext;

    public UserServiceModel GetUserWithCredentials(string username, string password) => this.dbContext.Users.Where(user => user.Password == Hash(password) && user.Username == username).Include(x => x.Roles).AsNoTracking().FirstOrDefault().To<UserServiceModel>();

    public UserServiceModel FindByUsername(string username) => this.dbContext.Users.Where(user => user.Username == username).Include(x => x.Roles).FirstOrDefault().To<UserServiceModel>();

    public bool SignIn(string username, string password) => (CurrentUser = GetUserWithCredentials(username, password).To<UserEntity>()) != null;

    public bool CreateUserWithCredentials(string username, string password)
    {
        var hashedPassword = Hash(password);
        var suchUserAlreadyExists = this.dbContext.Users.Any(user => user.Username == username);

        if (suchUserAlreadyExists)
        {
            return false;
        }

        this.dbContext.Users.Add(new UserEntity()
        {
            Username = username,
            Password = hashedPassword,
            Roles = new[] { dbContext.Roles.Where(role => role.Name == CashierRoleName).FirstOrDefault() }
        });
        this.dbContext.SaveChanges();

        return true;
    }

    public void CurrentUserLogout() => CurrentUser = null;

    public IEnumerable<string> CurrentUserRoles() => CurrentUser.Roles.Select(role => role.Name);
    
    public string CurrentUserUsername() => (CurrentUser?.Username) ?? "null";
}
