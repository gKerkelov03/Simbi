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
    public partial class RegisterForm : CredentialsForm
    {
        private UsersService usersService;
        public RegisterForm(Form parent, UsersService usersService) : base(parent)
        {
            this.usersService = usersService;
            this.InitializeComponent();
        }

        public RegisterForm()
        {
            InitializeComponent();
        }

        public override void SubmitCredentialsButton_Click(object sender, EventArgs e)
        {
            var enteredUsername = this.usernameTextBox.Text;
            var enteredPassword = this.passwordTextBox.Text;

            try
            {
               usersService.TryCreateUserWithCredentials(enteredUsername, enteredPassword);
                this.ErrorMessageLabel.Text = "Your creation was successfull";
                this.ErrorMessageLabel.ForeColor = Color.Green;
                this.ErrorMessageLabel.Show();
            }
            catch (Exception)
            {
                this.ErrorMessageLabel.Text = "That user already exists!";
                this.ErrorMessageLabel.ForeColor = Color.Red;

                this.ErrorMessageLabel.Show();
            }
        }        
    }
}
