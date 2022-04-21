using Simbi.Common;
using Simbi.Services;
using System.Windows.Forms;

namespace Simbi.WindowsForms;

public partial class CashierPage : Form
{
    private readonly UserManager userManager;
    private readonly Redirector redirector;

    public CashierPage(UserManager UserManager, Redirector redirector)
    {
        this.userManager = UserManager;
        this.redirector = redirector;
        InitializeComponent();
    }

    private void button2_Click(object sender, System.EventArgs e)
    {
        this.userManager.CurrentUserLogout();
        this.redirector.RedirectTo(PageName.Home, this);
    }
}
