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
        public LoginForm(Form parent, UserManager userManager) : base (parent)
        {
            InitializeComponent();
            this.userManager = userManager;
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        public override void SubmitCredentialsButton_Click(object sender, EventArgs e)
        {
            var enteredUsername = this.usernameTextBox.Text;
            var enteredPassword = this.passwordTextBox.Text;

            
            ApplicationUser potentialUser = this.userManager.GetUserWithCredentials(enteredUsername, enteredPassword);
            
            if(potentialUser != null)
            {
                userManager.CurrentUser = potentialUser;
            }
            else
            {
                this.ErrorMessageLabel.Show();
            }
        }

        
    }
}
