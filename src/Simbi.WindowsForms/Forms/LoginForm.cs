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
        private SignInManager signInManager;
        public LoginForm(Form parent, SignInManager signInManager) : base (parent)
        {
            InitializeComponent();
            this.signInManager = signInManager;
        }

        public LoginForm()
        {
            InitializeComponent();
        }

        public override void SubmitCredentialsButton_Click(object sender, EventArgs e)
        {
            var enteredUsername = this.usernameTextBox.Text;
            var enteredPassword = this.passwordTextBox.Text;

            try
            {
                this.signInManager.TrySignIn(enteredUsername, enteredPassword, this);
            }
            catch (Exception)
            {
                this.ErrorMessageLabel.Show();
            }
        }

        
    }
}
