
namespace Simbi.WindowsForms
{
    partial class CredentialsForm
    {        
        private System.ComponentModel.IContainer components = null;
        
        protected override void Dispose(bool disposing)
        {
            this.Text = "called";
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CredentialsForm));
            this.SubmitCredentialsButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.exitLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.ErrorMessageLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();            
            this.SuspendLayout();
            // 
            // SubmitCredentialsButton
            // 
            this.SubmitCredentialsButton.BackColor = System.Drawing.Color.Goldenrod;
            this.SubmitCredentialsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitCredentialsButton.Font = new System.Drawing.Font("Bahnschrift", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SubmitCredentialsButton.ForeColor = System.Drawing.Color.White;
            this.SubmitCredentialsButton.Location = new System.Drawing.Point(24, 396);
            this.SubmitCredentialsButton.Name = "SubmitCredentialsButton";
            this.SubmitCredentialsButton.Size = new System.Drawing.Size(264, 51);
            this.SubmitCredentialsButton.TabIndex = 1;
            this.SubmitCredentialsButton.Text = "Submit";
            this.SubmitCredentialsButton.UseVisualStyleBackColor = false;
            this.SubmitCredentialsButton.Click += new System.EventHandler(this.SubmitCredentialsButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(84, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 114);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Bauhaus 93", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.titleLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.titleLabel.Location = new System.Drawing.Point(63, 140);
            this.titleLabel.Name = "label1";
            this.titleLabel.Size = new System.Drawing.Size(176, 57);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "LOG IN";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(24, 215);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(42, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(24, 299);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(47, 49);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 5;
            this.pictureBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Goldenrod;
            this.panel1.Location = new System.Drawing.Point(24, 264);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 3);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Goldenrod;
            this.panel2.Location = new System.Drawing.Point(24, 354);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(264, 3);
            this.panel2.TabIndex = 7;
            // 
            // exitLabel
            // 
            this.exitLabel.AutoSize = true;
            this.exitLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.exitLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.exitLabel.Location = new System.Drawing.Point(130, 457);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(37, 20);
            this.exitLabel.TabIndex = 8;
            this.exitLabel.Text = "Exit";
            this.exitLabel.Click += new System.EventHandler(this.ExitLabel_Click);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.BackColor = System.Drawing.Color.Linen;
            this.usernameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usernameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.usernameTextBox.ForeColor = System.Drawing.Color.Goldenrod;
            this.usernameTextBox.Location = new System.Drawing.Point(80, 229);
            this.usernameTextBox.Multiline = true;
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(216, 35);
            this.usernameTextBox.TabIndex = 9;
            this.usernameTextBox.Text = "Username";
            this.usernameTextBox.GotFocus += new System.EventHandler(this.usernameTextBox_Focus);
            this.usernameTextBox.LostFocus += new System.EventHandler(this.usernameTextBox_Blur);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.Color.Linen;
            this.passwordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.passwordTextBox.ForeColor = System.Drawing.Color.Goldenrod;
            this.passwordTextBox.Location = new System.Drawing.Point(84, 322);
            this.passwordTextBox.Multiline = true;
            this.passwordTextBox.Name = "passwordTextBox";
            //this.passwordTextBox.PasswordChar = '';
            this.passwordTextBox.Size = new System.Drawing.Size(216, 32);
            this.passwordTextBox.TabIndex = 10;
            this.passwordTextBox.Text = "Password";
            this.passwordTextBox.GotFocus += new System.EventHandler(this.passwordTextBox_Focus);
            this.passwordTextBox.LostFocus += new System.EventHandler(this.passwordTextBox_Blur);

            // 
            // label2
            // 
            this.ErrorMessageLabel.AutoSize = true;
            this.ErrorMessageLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorMessageLabel.Location = new System.Drawing.Point(49, 368);
            this.ErrorMessageLabel.Name = "ErrorMessageLabel";
            this.ErrorMessageLabel.Size = new System.Drawing.Size(221, 17);
            this.ErrorMessageLabel.TabIndex = 11;
            this.ErrorMessageLabel.Text = "* Wrong username or password.";
            this.ErrorMessageLabel.Hide();
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(308, 486);
            this.Controls.Add(this.ErrorMessageLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SubmitCredentialsButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(this.Parent.Size.Width / 2 - this.Width / 2, this.Parent.Size.Height / 2 - this.Height / 2);
            this.Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button SubmitCredentialsButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        protected System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Label exitLabel;
        protected System.Windows.Forms.TextBox usernameTextBox;
        protected System.Windows.Forms.TextBox passwordTextBox;
        protected System.Windows.Forms.Label ErrorMessageLabel;
    }
}