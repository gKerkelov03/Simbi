using Simbi.Services;
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
    public partial class UserPage : Form
    {
        protected SignInManager signInManager;
        public UserPage(SignInManager signInManager)
        {
            this.signInManager = signInManager;
            InitializeComponent();
        }                

        private void SignInButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            new LoginForm(this, this.signInManager).Show();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.signInManager.Logout(this);
        }
    }
}
