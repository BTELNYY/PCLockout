namespace PCLockout.Forms
{

    partial class PasswordForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.acceptButton = new System.Windows.Forms.Button();
            this.PasswordEnterBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.ChangePW = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(260, 42);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(75, 23);
            this.acceptButton.TabIndex = 0;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // PasswordEnterBox
            // 
            this.PasswordEnterBox.Location = new System.Drawing.Point(0, 42);
            this.PasswordEnterBox.Name = "PasswordEnterBox";
            this.PasswordEnterBox.PasswordChar = '•';
            this.PasswordEnterBox.Size = new System.Drawing.Size(254, 23);
            this.PasswordEnterBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter Passowrd";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(260, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // ChangePW
            // 
            this.ChangePW.AutoSize = true;
            this.ChangePW.Location = new System.Drawing.Point(153, 9);
            this.ChangePW.Name = "ChangePW";
            this.ChangePW.Size = new System.Drawing.Size(101, 15);
            this.ChangePW.TabIndex = 4;
            this.ChangePW.TabStop = true;
            this.ChangePW.Text = "Change Password";
            this.ChangePW.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ChangePW_LinkClicked);
            // 
            // PasswordForm
            // 
            this.AcceptButton = this.acceptButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 69);
            this.Controls.Add(this.ChangePW);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PasswordEnterBox);
            this.Controls.Add(this.acceptButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordForm";
            this.Text = "Enter Password";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MyForm_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button acceptButton;
        private TextBox PasswordEnterBox;
        private Label label1;
        private Button cancelButton;
        private LinkLabel ChangePW;
    }
}
