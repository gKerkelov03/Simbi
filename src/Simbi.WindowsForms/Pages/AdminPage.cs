using Simbi.Services;
using System.Windows.Forms;

namespace Simbi.WindowsForms;

public partial class AdminPage : Form
{
    private UserManager userManager;
    public AdminPage(UserManager userManager)
    {
        this.userManager = userManager;
        InitializeComponent();
    }
}
