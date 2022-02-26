using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Simbi.Common;
using Simbi.Services;
using Simbi.WindowsForms;

namespace Simbi.Services
{
    public class WindowsFormsRedirector : IRedirector
    {        
        public void RedirectTo(PageName page,object currentPage)
        {
            Form newPage = null;

            if(page == PageName.Home)
            {
                newPage = new HomePage();
            }
            else if (page == PageName.Cashier)
            {
                newPage = new CashierPage(new SignInManager(this));
            }
            else if(page == PageName.Admin)
            {
                newPage = new AdminPage();
            }

            newPage.Show();

                if (currentPage is CredentialsForm)
                {
                    (currentPage as CredentialsForm).Parent.Hide();
                }

                (currentPage as Form).Close();
        }
    }
}
