
namespace Simbi.WindowsForms
{
    partial class RegisterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
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
            this.SuspendLayout();
            // 
            // SubmitCredentialsButton
            // 
            this.SubmitCredentialsButton.Location = new System.Drawing.Point(24, 400);
            this.SubmitCredentialsButton.Size = new System.Drawing.Size(264, 44);            
            // 
            // titleLabel
            // 
            this.titleLabel.Location = new System.Drawing.Point(49, 139);
            this.titleLabel.Size = new System.Drawing.Size(214, 57);
            this.titleLabel.Text = "Register";
            // 
            // ErrorMessageLabel
            // 
            this.ErrorMessageLabel.Location = new System.Drawing.Point(80, 373);
            this.ErrorMessageLabel.Size = new System.Drawing.Size(168, 17);
            this.ErrorMessageLabel.Text = "That user already exists!";
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 492);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}