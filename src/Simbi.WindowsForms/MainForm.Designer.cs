
namespace Simbi.WindowsForms
{
    partial class MainForm
    {   
        private System.ComponentModel.IContainer components = null;       
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openLoginFormButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.testLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openLoginFormButton
            // 
            this.openLoginFormButton.Location = new System.Drawing.Point(693, 0);
            this.openLoginFormButton.Name = "openLoginFormButton";
            this.openLoginFormButton.Size = new System.Drawing.Size(108, 29);
            this.openLoginFormButton.TabIndex = 0;
            this.openLoginFormButton.Text = "Admin Panel";
            this.openLoginFormButton.UseVisualStyleBackColor = true;
            this.openLoginFormButton.Click += new System.EventHandler(this.OpenLoginFormButton_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(134, 111);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(526, 219);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // testLabel
            // 
            this.testLabel.AutoSize = true;
            this.testLabel.Location = new System.Drawing.Point(381, 376);
            this.testLabel.Name = "testLabel";
            this.testLabel.Size = new System.Drawing.Size(46, 17);
            this.testLabel.TabIndex = 2;
            this.testLabel.Text = "label1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.testLabel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.openLoginFormButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button openLoginFormButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label testLabel;
    }
}

