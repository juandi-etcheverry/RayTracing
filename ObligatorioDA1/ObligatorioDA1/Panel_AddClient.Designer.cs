namespace ObligatorioDA1
{
    partial class Panel_AddClient
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblAddClient = new System.Windows.Forms.Label();
            this.txbNewClientName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.btnAddNewClient = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txbNewClientPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txbNewClientRepeatPassword = new System.Windows.Forms.TextBox();
            this.btnGoBack = new System.Windows.Forms.Button();
            this.lblNewNameException = new System.Windows.Forms.Label();
            this.lblNewPasswordException = new System.Windows.Forms.Label();
            this.lblNewConfirmPasswordException = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAddClient
            // 
            this.lblAddClient.AutoSize = true;
            this.lblAddClient.BackColor = System.Drawing.Color.Transparent;
            this.lblAddClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddClient.ForeColor = System.Drawing.Color.Transparent;
            this.lblAddClient.Location = new System.Drawing.Point(309, 53);
            this.lblAddClient.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddClient.Name = "lblAddClient";
            this.lblAddClient.Size = new System.Drawing.Size(138, 36);
            this.lblAddClient.TabIndex = 0;
            this.lblAddClient.Text = "SIGN UP";
            // 
            // txbNewClientName
            // 
            this.txbNewClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNewClientName.Location = new System.Drawing.Point(116, 150);
            this.txbNewClientName.Margin = new System.Windows.Forms.Padding(2);
            this.txbNewClientName.Name = "txbNewClientName";
            this.txbNewClientName.Size = new System.Drawing.Size(410, 28);
            this.txbNewClientName.TabIndex = 1;
            this.txbNewClientName.TextChanged += new System.EventHandler(this.txbNewClientName_TextChanged);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.White;
            this.lblName.Location = new System.Drawing.Point(112, 129);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(55, 20);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // btnAddNewClient
            // 
            this.btnAddNewClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewClient.Location = new System.Drawing.Point(308, 383);
            this.btnAddNewClient.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddNewClient.Name = "btnAddNewClient";
            this.btnAddNewClient.Size = new System.Drawing.Size(132, 35);
            this.btnAddNewClient.TabIndex = 4;
            this.btnAddNewClient.Text = "Save";
            this.btnAddNewClient.UseVisualStyleBackColor = true;
            this.btnAddNewClient.Click += new System.EventHandler(this.btnAddNewClient_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(112, 204);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Password";
            // 
            // txbNewClientPassword
            // 
            this.txbNewClientPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNewClientPassword.Location = new System.Drawing.Point(116, 225);
            this.txbNewClientPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txbNewClientPassword.Name = "txbNewClientPassword";
            this.txbNewClientPassword.PasswordChar = '*';
            this.txbNewClientPassword.Size = new System.Drawing.Size(410, 28);
            this.txbNewClientPassword.TabIndex = 2;
            this.txbNewClientPassword.TextChanged += new System.EventHandler(this.txbNewClientPassword_TextChanged);
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.lblConfirmPassword.Location = new System.Drawing.Point(112, 287);
            this.lblConfirmPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(134, 20);
            this.lblConfirmPassword.TabIndex = 8;
            this.lblConfirmPassword.Text = "Repeat password";
            // 
            // txbNewClientRepeatPassword
            // 
            this.txbNewClientRepeatPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNewClientRepeatPassword.Location = new System.Drawing.Point(116, 307);
            this.txbNewClientRepeatPassword.Margin = new System.Windows.Forms.Padding(2);
            this.txbNewClientRepeatPassword.Name = "txbNewClientRepeatPassword";
            this.txbNewClientRepeatPassword.PasswordChar = '*';
            this.txbNewClientRepeatPassword.Size = new System.Drawing.Size(410, 28);
            this.txbNewClientRepeatPassword.TabIndex = 3;
            // 
            // btnGoBack
            // 
            this.btnGoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoBack.Location = new System.Drawing.Point(21, 24);
            this.btnGoBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnGoBack.Name = "btnGoBack";
            this.btnGoBack.Size = new System.Drawing.Size(77, 35);
            this.btnGoBack.TabIndex = 5;
            this.btnGoBack.Text = "Return";
            this.btnGoBack.UseVisualStyleBackColor = true;
            this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
            // 
            // lblNewNameException
            // 
            this.lblNewNameException.AutoSize = true;
            this.lblNewNameException.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewNameException.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNewNameException.Location = new System.Drawing.Point(113, 177);
            this.lblNewNameException.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewNameException.Name = "lblNewNameException";
            this.lblNewNameException.Size = new System.Drawing.Size(131, 15);
            this.lblNewNameException.TabIndex = 11;
            this.lblNewNameException.Text = "* New name exception";
            // 
            // lblNewPasswordException
            // 
            this.lblNewPasswordException.AutoSize = true;
            this.lblNewPasswordException.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPasswordException.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNewPasswordException.Location = new System.Drawing.Point(113, 252);
            this.lblNewPasswordException.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewPasswordException.Name = "lblNewPasswordException";
            this.lblNewPasswordException.Size = new System.Drawing.Size(152, 15);
            this.lblNewPasswordException.TabIndex = 12;
            this.lblNewPasswordException.Text = "* New password exception";
            // 
            // lblNewConfirmPasswordException
            // 
            this.lblNewConfirmPasswordException.AutoSize = true;
            this.lblNewConfirmPasswordException.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewConfirmPasswordException.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNewConfirmPasswordException.Location = new System.Drawing.Point(113, 334);
            this.lblNewConfirmPasswordException.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewConfirmPasswordException.Name = "lblNewConfirmPasswordException";
            this.lblNewConfirmPasswordException.Size = new System.Drawing.Size(196, 15);
            this.lblNewConfirmPasswordException.TabIndex = 13;
            this.lblNewConfirmPasswordException.Text = "* New confirm password exception";
            // 
            // Panel_AddClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.Controls.Add(this.lblNewConfirmPasswordException);
            this.Controls.Add(this.lblNewPasswordException);
            this.Controls.Add(this.lblNewNameException);
            this.Controls.Add(this.btnGoBack);
            this.Controls.Add(this.txbNewClientRepeatPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.txbNewClientPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddNewClient);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txbNewClientName);
            this.Controls.Add(this.lblAddClient);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(750, 520);
            this.MinimumSize = new System.Drawing.Size(750, 520);
            this.Name = "Panel_AddClient";
            this.Size = new System.Drawing.Size(750, 520);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddClient;
        private System.Windows.Forms.TextBox txbNewClientName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnAddNewClient;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbNewClientPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txbNewClientRepeatPassword;
        private System.Windows.Forms.Button btnGoBack;
        private System.Windows.Forms.Label lblNewNameException;
        private System.Windows.Forms.Label lblNewPasswordException;
        private System.Windows.Forms.Label lblNewConfirmPasswordException;
    }
}
