using Simbi.Services;
using System.Windows.Forms;

namespace Simbi.WindowsForms;

public partial class CashierPage : Form
{
    private UserManager userManager;
    public CashierPage(UserManager UserManager)
    {
        this.userManager = UserManager;
        InitializeComponent();
    }
}
