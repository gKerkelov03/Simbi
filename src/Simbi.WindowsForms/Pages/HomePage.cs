using Simbi.Services;
using Simbi.WindowsForms.Infrastructure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Simbi.WindowsForms;

public partial class HomePage : Form
{
    private UserManager userManager;
    private Redirector redirektor;

    public HomePage(UserManager userManager, Redirector redirektor)
    {
        this.userManager = userManager;
        this.redirektor = redirektor;
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
        new LoginForm(this, userManager, redirektor).Show();       
        this.Enabled = false;           
    }        
}
