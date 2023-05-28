namespace ObligatorioDA1
{
    partial class Form1
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
            this.flyPanelPrincipal = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbUserName = new System.Windows.Forms.TextBox();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSignIn = new System.Windows.Forms.Button();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.lblNameException = new System.Windows.Forms.Label();
            this.lblPasswordException = new System.Windows.Forms.Label();
            this.btnRenderLogs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flyPanelPrincipal
            // 
            this.flyPanelPrincipal.BackColor = System.Drawing.Color.Transparent;
            this.flyPanelPrincipal.Location = new System.Drawing.Point(1015, 654);
            this.flyPanelPrincipal.MaximumSize = new System.Drawing.Size(1125, 800);
            this.flyPanelPrincipal.MinimumSize = new System.Drawing.Size(1125, 800);
            this.flyPanelPrincipal.Name = "flyPanelPrincipal";
            this.flyPanelPrincipal.Size = new System.Drawing.Size(1125, 800);
            this.flyPanelPrincipal.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(399, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 65);
            this.label1.TabIndex = 3;
            this.label1.Text = "WELCOME!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(45, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 52);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sign In";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(54, 237);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "USERNAME:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(54, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 26);
            this.label4.TabIndex = 6;
            this.label4.Text = "PASSWORD:";
            // 
            // txbUserName
            // 
            this.txbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbUserName.Location = new System.Drawing.Point(57, 266);
            this.txbUserName.Name = "txbUserName";
            this.txbUserName.Size = new System.Drawing.Size(444, 39);
            this.txbUserName.TabIndex = 7;
            // 
            // txbPassword
            // 
            this.txbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbPassword.Location = new System.Drawing.Point(54, 403);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.PasswordChar = '*';
            this.txbPassword.Size = new System.Drawing.Size(444, 39);
            this.txbPassword.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(717, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(344, 40);
            this.label5.TabIndex = 9;
            this.label5.Text = "Don\'t have account?";
            // 
            // btnSignIn
            // 
            this.btnSignIn.Location = new System.Drawing.Point(153, 540);
            this.btnSignIn.Name = "btnSignIn";
            this.btnSignIn.Size = new System.Drawing.Size(231, 55);
            this.btnSignIn.TabIndex = 10;
            this.btnSignIn.Text = "Sign In";
            this.btnSignIn.UseVisualStyleBackColor = true;
            this.btnSignIn.Click += new System.EventHandler(this.btnSignIn_Click);
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(772, 374);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(231, 54);
            this.btnSignUp.TabIndex = 11;
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // lblNameException
            // 
            this.lblNameException.AutoSize = true;
            this.lblNameException.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameException.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNameException.Location = new System.Drawing.Point(57, 311);
            this.lblNameException.Name = "lblNameException";
            this.lblNameException.Size = new System.Drawing.Size(148, 22);
            this.lblNameException.TabIndex = 12;
            this.lblNameException.Text = "*Name Exception";
            // 
            // lblPasswordException
            // 
            this.lblPasswordException.AutoSize = true;
            this.lblPasswordException.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPasswordException.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPasswordException.Location = new System.Drawing.Point(57, 452);
            this.lblPasswordException.Name = "lblPasswordException";
            this.lblPasswordException.Size = new System.Drawing.Size(180, 22);
            this.lblPasswordException.TabIndex = 13;
            this.lblPasswordException.Text = "*Password Exception";
            // 
            // btnRenderLogs
            // 
            this.btnRenderLogs.Location = new System.Drawing.Point(420, 648);
            this.btnRenderLogs.Name = "btnRenderLogs";
            this.btnRenderLogs.Size = new System.Drawing.Size(231, 54);
            this.btnRenderLogs.TabIndex = 14;
            this.btnRenderLogs.Text = "Render logs";
            this.btnRenderLogs.UseVisualStyleBackColor = true;
            this.btnRenderLogs.Click += new System.EventHandler(this.btnRenderLogs_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1092, 714);
            this.Controls.Add(this.btnRenderLogs);
            this.Controls.Add(this.lblPasswordException);
            this.Controls.Add(this.lblNameException);
            this.Controls.Add(this.flyPanelPrincipal);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.btnSignIn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.txbUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(1114, 770);
            this.MinimumSize = new System.Drawing.Size(1114, 770);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flyPanelPrincipal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbUserName;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSignIn;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Label lblNameException;
        private System.Windows.Forms.Label lblPasswordException;
        private System.Windows.Forms.Button btnRenderLogs;
    }
}

