using Simbi.Common;
using Simbi.Data.Common;
using Simbi.Services;
using System;
using System.Windows.Forms;

namespace Simbi.WindowsForms;

public partial class LoginForm : CredentialsForm
{
    private readonly UserManager userManager;
    private readonly Redirector redirector;

    public LoginForm(Form parent, UserManager userManager, Redirector redirector) : base (parent)
    {
        InitializeComponent();
        this.userManager = userManager;
        this.redirector = redirector;
    }

    public LoginForm() => InitializeComponent();
    
    public override void SubmitCredentialsButton_Click(object sender, EventArgs e)
    {
        var enteredUsername = this.usernameTextBox.Text;
        var enteredPassword = this.passwordTextBox.Text;
        
        User potentialUser = this.userManager.GetUserWithCredentials(enteredUsername, enteredPassword);
        
        if(potentialUser != null)
        {
            userManager.CurrentUser = potentialUser;

            if(userManager.CurrentUser.Role.Name == GlobalConstants.AdministratorRoleName)
            {
                this.redirector.RedirectTo(PageName.Admin, this);
            }
            else if(userManager.CurrentUser.Role.Name == GlobalConstants.CashierRoleName)
            {
                this.redirector.RedirectTo(PageName.Cashier, this);
            }
        }
        else
        {
            this.ErrorMessageLabel.Show();
        }
    }
}
