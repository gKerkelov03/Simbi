using Simbi.Common;
using Simbi.Data.Common;
using Simbi.Services;
using Simbi.Services.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simbi.WindowsForms
{
    public partial class LoginForm : CredentialsForm
    {
        private UserManager userManager;
        private Redirector redirector;

        public LoginForm(Form parent, UserManager userManager, Redirector redirector) : base (parent)
        {
            InitializeComponent();
            this.userManager = userManager;
            this.redirector = redirector;
        }

        public LoginForm()
        {
            InitializeComponent();
        }

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
}
