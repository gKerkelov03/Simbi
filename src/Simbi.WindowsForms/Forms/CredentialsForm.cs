using Simbi.Services;
using Simbi.Services.Data;
using System;
using System.Windows.Forms;

namespace Simbi.WindowsForms
{
    public partial class CredentialsForm : Form
    {
        public CredentialsForm()
        {
            InitializeComponent();
        }

        private void usernameTextBox_Focus(object sender, EventArgs e)
        {
            if (this.usernameTextBox.Text == "Username")
            {
                this.usernameTextBox.Text = "";
            }
        }

        private void usernameTextBox_Blur(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.usernameTextBox.Text))
            {
                this.usernameTextBox.Text = "Username";
            }
        }

        private void passwordTextBox_Focus(object sender, EventArgs e)
        {
            if (this.passwordTextBox.Text == "Password")
            {
                this.passwordTextBox.Text = "";
                this.passwordTextBox.PasswordChar = '*';
            }
        }

        private void passwordTextBox_Blur(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.passwordTextBox.Text))
            {
                this.passwordTextBox.PasswordChar = '\0';
                this.passwordTextBox.Text = "Password";
            }
        }

        public virtual void SubmitCredentialsButton_Click(object sender, EventArgs e)
        {
            
        }

        private void ExitLabel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
