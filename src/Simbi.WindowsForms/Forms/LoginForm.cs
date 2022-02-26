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
        public LoginForm(Form parent) : base (parent)
        {
            InitializeComponent();
        }

        public override void SubmitCredentialsButton_Click(object sender, EventArgs e)
        {
            var enteredUsername = this.usernameTextBox.Text;
            var enteredPassword = this.passwordTextBox.Text;

            try
            {
                SignInManager.Instance.TrySignIn(enteredUsername, enteredPassword);
            }
            catch (Exception)
            {
                this.ErrorMessageLabel.Show();
            }
        }

        
    }
}
