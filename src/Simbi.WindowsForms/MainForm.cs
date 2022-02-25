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
    public partial class MainForm : Form
    {
        private LoginForm LoginForm;

        public MainForm(LoginForm LoginForm)
        {
            this.LoginForm = LoginForm;

            InitializeComponent();
        }


        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = "test";
            this.testLabel.Text = "main form load";
        }        

        private void OpenLoginFormButton_Click(object sender, EventArgs e)
        {
            this.testLabel.Text = "here i was";
            this.LoginForm.Show();
            this.Hide();
        }      
    }
}
