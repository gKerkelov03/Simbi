using Simbi.Data;
using Simbi.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Services.Data
{
    public sealed class SignInManager
    {
        private static readonly SignInManager instance = new SignInManager();
        public ApplicationUser CurrentUser { get; private set; }

        private ApplicationDbContext dbContext = null;
        private SignInManager()
        {
            this.dbContext = new ApplicationDbContext();
        }
        public void TrySignIn(string username, string password)
        {
            using var sha = SHA256.Create();
            string hash = string.Join("", sha.ComputeHash(Encoding.UTF8.GetBytes(password)));

            this.CurrentUser = UserManager.Instance.TryGetUserMatchingCredentials(username, hash);
        }
        public static SignInManager Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
