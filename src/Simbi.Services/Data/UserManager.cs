using Simbi.Data;
using Simbi.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Services.Data
{   
    public sealed class UserManager 
    {
        private static readonly UserManager instance = new UserManager();

        private ApplicationDbContext dbContext = null;
        private UserManager()
        {
            this.dbContext = new ApplicationDbContext();
        }

        public ApplicationUser TryGetUserMatchingCredentials(string username, string password)
        {
            var user = this.dbContext.Users.Single(user => user.Password == password && user.Username == username);

            return user;
        }

        public static UserManager Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
