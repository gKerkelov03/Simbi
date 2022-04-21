using Simbi.Common;
using Simbi.Services;
using System.Windows.Forms;

namespace Simbi.WindowsForms;

public partial class AdminPage : Form
{
    private UserManager userManager;
    private Redirector redirector;

    public AdminPage(UserManager userManager, Redirector redirector)
    {
        this.userManager = userManager;
        this.redirector = redirector;  
        InitializeComponent();
    }

    private void button1_Click(object sender, System.EventArgs e)
    {
        this.userManager.CurrentUserLogout();
        this.redirector.RedirectTo(PageName.Home, this);
    }
}
