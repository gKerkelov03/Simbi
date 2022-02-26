using Simbi.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simbi.WindowsForms
{
    public partial class CashierPage : Form
    {
        private SignInManager signInManager;
        public CashierPage(SignInManager signInManager)
        {
            this.signInManager = signInManager;
            InitializeComponent();
        }              

        private void OpenLoginFormButton_Click(object sender, EventArgs e)
        {
            this.testLabel.Text = "here i was";
            new LoginForm(this, this.signInManager).Show();
            this.Hide();
        }

        private void LogoutButton_Click(object sender, EventArgs e)
        {
            this.signInManager.Logout(this);
        }
    }
}
