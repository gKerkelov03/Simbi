using System.Windows.Forms;
using Simbi.Common;
using Simbi.WindowsForms;

namespace Simbi.Services;

public class Redirector
{        
    private static readonly UserManager userManager = new UserManager();
    public void RedirectTo(PageName page, object currentPage)
    {
        Form newPage = null;

        if(page == PageName.Home)
        {
            newPage = new HomePage();
        }
        else if (page == PageName.Cashier)
        {
            newPage = new AdminPage(userManager);
        }
        else if(page == PageName.Admin)
        {
            newPage = new CashierPage(userManager);
        }

        newPage.Show();

        if (currentPage is CredentialsForm)
        {
            (currentPage as CredentialsForm).Parent.Hide();
        }

        (currentPage as Form).Close();
    }
}
