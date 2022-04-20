using Simbi.Common;
using Simbi.Data;
using Simbi.Data.Common;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Simbi.Services
{
    public class UserManager 
    {
        public User CurrentUser { get; set; }

        private SHA256 sha = SHA256.Create();
        private ApplicationDbContext dbContext = new ApplicationDbContext();

        public User GetUserWithCredentials(string username, string password)
        {
            var hashedPassword = this.Hash(password);
            return this.dbContext.Users.FirstOrDefault(user => user.Password == hashedPassword && user.Username == username);
        }
          
        public bool CreateUserWithCredentials(string username, string password)
        {
            var hashedPassword = this.Hash(password);
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
                    Name = GlobalConstants.CashierRoleName,
                    Id = Guid.NewGuid()//aka not admin                    
                }
            });

            return true;
        }

        public void MakeAdmin(User user)
        {
            user.Role.Name = GlobalConstants.AdministratorRoleName;            
        }

        public void CurrentUserLogout() => this.CurrentUser = null;        

        private string Hash(string password) =>        
            string.Join("", this.sha.ComputeHash(Encoding.UTF8.GetBytes(password)));
    }
}
