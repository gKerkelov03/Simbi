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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        #region InputsOnFocusAndOnBlur

        private void usernameTextBox_Focus(object sender, EventArgs e)
        {
            this.usernameTextBox.Text = "";
        }

        private void usernameTextBox_Blur(object sender, EventArgs e)
        {
            this.usernameTextBox.Text = "";
        }

        private void passwordTextBox_Focus(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_Blur(object sender, EventArgs e)
        {
            this.usernameTextBox.Text = "";
        }

        #endregion

        private void SubmitCredentialsButton_Click(object sender, EventArgs e)
        {

        }

        private void ExitLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
