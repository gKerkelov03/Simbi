using Simbi.Data;
using Simbi.Data.Common;
using Simbi.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Simbi.Services
{
    public sealed class SignInManager
    {
        private static readonly SignInManager instance = new SignInManager();
        public ApplicationUser CurrentUser { get; private set; }

        private ApplicationDbContext dbContext = new ApplicationDbContext();
        private SignInManager()
        {
        }

        public void TrySignIn(string username, string password)
        {
            this.CurrentUser = UserManager.Instance.TryGetUserWithCredentials(username, password);

            //redirect to cashier or admin page
        }

        public void Logout()
        {
            this.CurrentUser = null;

            //redirect to home page
        }

        public static SignInManager Instance => instance;
    }
}
