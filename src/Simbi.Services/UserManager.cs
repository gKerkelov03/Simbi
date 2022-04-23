using static Simbi.Common.GlobalConstants;
using static Simbi.Common.UtilityMethods;
using Simbi.Data;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Simbi.Data.Models;

namespace Simbi.Services;

public class UserManager
{
    private static UserEntity CurrentUser { get; set; }

    private readonly ApplicationDbContext dbContext = new ApplicationDbContext();

    public UserEntity GetUserWithCredentials(string username, string password) => this.dbContext.Users.Where(user => user.Password == Hash(password) && user.Username == username).Include(x => x.Roles).FirstOrDefault();

    public bool SignIn(string username, string password) => (CurrentUser = GetUserWithCredentials(username, password)) != null;

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

    public void MakeAdmin(UserEntity user) => user.Roles.Add(dbContext.Roles.Where(role => role.Name == AdministratorRoleName).FirstOrDefault());

    public void CurrentUserLogout() => CurrentUser = null;

    public IEnumerable<string> CurrentUserRoles() => CurrentUser.Roles.Select(role => role.Name);
    
    public string CurrentUserUsername() => CurrentUser.Username;
}
