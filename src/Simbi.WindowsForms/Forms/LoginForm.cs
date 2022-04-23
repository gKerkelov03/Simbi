using Simbi.Common;
using Simbi.Services;
using Simbi.WindowsForms.Infrastructure;
using System;
using System.Linq;
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
        this.redirector.RedirectTo(PageName.Admin, this);

        var enteredUsername = this.usernameTextBox.Text;
        var enteredPassword = this.passwordTextBox.Text;

        this.passwordTextBox.PasswordChar = '\0';
        this.usernameTextBox.Text = "Username";
        this.passwordTextBox.Text = "Password";


        bool isLoginSuccessful = userManager.SignIn(enteredUsername, enteredPassword);

        if (isLoginSuccessful)
        {
            if (userManager.CurrentUserRoles().Contains(GlobalConstants.AdministratorRoleName))
            {
                this.redirector.RedirectTo(PageName.Admin, this);
            }
            else if (userManager.CurrentUserRoles().Contains(GlobalConstants.CashierRoleName))
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
