﻿using System.Windows.Forms;
using Simbi.Common;
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
                newPage = new AdminPage(new SignInManager(this));
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
