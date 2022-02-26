using Simbi.Common;
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
    public class SignInManager
    {            
        public ApplicationUser CurrentUser { get; private set; }

        private ApplicationDbContext dbContext = new ApplicationDbContext();
        private IRedirector redirector;

        public SignInManager(IRedirector redirector)
        {
            this.redirector = redirector;
        }        

        public void TrySignIn(string username, string password, object sender)
        {
            Random rnd = new Random();
            //this.CurrentUser = UserManager.Instance.TryGetUserWithCredentials(username, password);

            //if(this.CurrentUser.Role.Name == "Admin")
            //{
                redirector.RedirectTo(rnd.Next()%2==0?PageName.Admin:PageName.Cashier, sender );
            //}
            //else
            //{
            //    redirector.RedirectTo(PageName.Cashier, sender);
            //}
        }

        public void Logout(object sender)
        {
            this.CurrentUser = null;

            redirector.RedirectTo(PageName.Home, sender);
        }
    }
}
