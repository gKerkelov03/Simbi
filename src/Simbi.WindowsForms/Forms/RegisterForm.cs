using Simbi.Services;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Simbi.WindowsForms;

public partial class RegisterForm : CredentialsForm
{
    private readonly UserManager usersService;

    public RegisterForm(Form parent, UserManager usersService) : base(parent)
    {
        this.usersService = usersService;
        this.InitializeComponent();
    }    

    public override void SubmitCredentialsButton_Click(object sender, EventArgs e)
    {
        var enteredUsername = this.usernameTextBox.Text;
        var enteredPassword = this.passwordTextBox.Text;

        this.passwordTextBox.PasswordChar = '\0';
        this.usernameTextBox.Text = "Username";
        this.passwordTextBox.Text = "Password";

        bool isCreatedSuccessfully = usersService.CreateUserWithCredentials(enteredUsername, enteredPassword);

        if(isCreatedSuccessfully)
        {
            this.ErrorMessageLabel.Text = "Your creation was successfull";
            this.ErrorMessageLabel.ForeColor = Color.Green;
            this.ErrorMessageLabel.Show();
        }
        else
        {
            this.ErrorMessageLabel.Text = "That user already exists!";
            this.ErrorMessageLabel.ForeColor = Color.Red;
            this.ErrorMessageLabel.Show();
        }
    }        
}
