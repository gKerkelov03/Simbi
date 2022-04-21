using static Simbi.Common.GlobalConstants;
using static Simbi.Common.UtilityMethods;
using Simbi.Data;
using Simbi.Data.Common;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;

namespace Simbi.Services;

public class UserManager
{
    private User CurrentUser { get; set; }

    private readonly ApplicationDbContext dbContext = new ApplicationDbContext();

    public User GetUserWithCredentials(string username, string password) => this.dbContext.Users.FirstOrDefault(user => user.Password == Hash(password) && user.Username == username);

    public bool SignIn(string username, string password) => (this.CurrentUser = GetUserWithCredentials(username, password)) != null;

    public bool CreateUserWithCredentials(string username, string password)
    {
        var hashedPassword = Hash(password);
        var suchUserAlreadyExists = this.dbContext.Users.Any(user => user.Password == hashedPassword || user.Username == username);

        if (suchUserAlreadyExists)
        {
            return false;
        }

        this.dbContext.Users.Add(new User()
        {
            Username = username,
            Password = hashedPassword,
            Roles = new[] { dbContext.Roles.Where(role => role.Name == CashierRoleName).FirstOrDefault() }
        });

        return true;
    }

    public void MakeAdmin(User user) => user.Roles.Add(dbContext.Roles.Where(role => role.Name == AdministratorRoleName).FirstOrDefault());

    public void CurrentUserLogout() => this.CurrentUser = null;

    public IEnumerable<string> CurrentUserRoles() => CurrentUser.Roles.Select(role => role.Name);
    
    public string CurrentUserUsername() => CurrentUser.Username;
}
