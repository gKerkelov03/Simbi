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
        var enteredUsername = this.usernameTextBox.Text;
        var enteredPassword = this.passwordTextBox.Text;

        this.passwordTextBox.PasswordChar = '\0';
        this.usernameTextBox.Text = "Username";
        this.passwordTextBox.Text = "Password";

        bool isLoginSuccessful = false;

        //TODO: make this without try catch (userManager.SignIn to return proper bool not to throw exception)
        try
        {
            userManager.SignIn(enteredUsername, enteredPassword);
            isLoginSuccessful = true;
        }
        catch (Exception)
        {
            isLoginSuccessful = false;            
        }

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
