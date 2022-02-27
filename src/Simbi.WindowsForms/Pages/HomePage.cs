﻿using Simbi.Data;
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
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }       

        private void FormResize(object sender, EventArgs e)
        {
            this.backgroundImage.Size = new Size(this.ClientSize.Width + 5, this.ClientSize.Height + 2);     
            this.logoImage.Location = new Point(this.ClientSize.Width - this.logoImage.Size.Width, 0);
            this.label1.Font = new Font(this.label1.Font.FontFamily, this.ClientSize.Width / 50);
            this.label2.Font = new Font(this.label1.Font.FontFamily, this.ClientSize.Width / 50);
            this.LoginButton.Size = new Size(this.ClientSize.Width / 3, this.ClientSize.Height / 9);
            this.LoginButton.Location = new Point(20, this.ClientSize.Height / 2 + this.LoginButton.Height);
            this.LoginButton.Font = new Font(this.LoginButton.Font.FontFamily, this.ClientSize.Width / 78);
            this.label2.Location = new Point(20, this.ClientSize.Height / 3);


        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            new LoginForm(this, new SignInManager(new WindowsFormsRedirector())).Show();
            this.Enabled = false;
            new ApplicationDbContext().Database.EnsureCreated();
        }        
    }
}
