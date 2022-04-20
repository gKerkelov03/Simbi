using static Simbi.Common.GlobalConstants;
using static Simbi.Common.UtilityMethods;
using Simbi.Data;
using Simbi.Data.Common;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Simbi.Services;

public class UserManager 
{
    public User CurrentUser { get; set; }

    private readonly ApplicationDbContext dbContext = new ApplicationDbContext();

    public User GetUserWithCredentials(string username, string password) => this.dbContext.Users.FirstOrDefault(user => user.Password == Hash(password) && user.Username == username);
              
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
            Role = new Role
            {
                Name = CashierRoleName,
                Id = Guid.NewGuid()//aka not admin                    
            }
        });

        return true;
    }

    public void MakeAdmin(User user) => user.Role.Name = AdministratorRoleName;            
    
    public void CurrentUserLogout() => this.CurrentUser = null;        

}
