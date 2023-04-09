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
            this.txbClientName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txbClientPassword = new System.Windows.Forms.TextBox();
            this.btnAddNewClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAddClient
            // 
            this.lblAddClient.AutoSize = true;
            this.lblAddClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddClient.Location = new System.Drawing.Point(454, 118);
            this.lblAddClient.Name = "lblAddClient";
            this.lblAddClient.Size = new System.Drawing.Size(245, 55);
            this.lblAddClient.TabIndex = 0;
            this.lblAddClient.Text = "Add Client";
            // 
            // txbClientName
            // 
            this.txbClientName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbClientName.Location = new System.Drawing.Point(268, 292);
            this.txbClientName.Name = "txbClientName";
            this.txbClientName.Size = new System.Drawing.Size(501, 38);
            this.txbClientName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(134, 295);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(94, 31);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(86, 395);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(142, 31);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";
            // 
            // txbClientPassword
            // 
            this.txbClientPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbClientPassword.Location = new System.Drawing.Point(268, 392);
            this.txbClientPassword.Name = "txbClientPassword";
            this.txbClientPassword.Size = new System.Drawing.Size(501, 38);
            this.txbClientPassword.TabIndex = 3;
            // 
            // btnAddNewClient
            // 
            this.btnAddNewClient.Location = new System.Drawing.Point(630, 523);
            this.btnAddNewClient.Name = "btnAddNewClient";
            this.btnAddNewClient.Size = new System.Drawing.Size(139, 53);
            this.btnAddNewClient.TabIndex = 5;
            this.btnAddNewClient.Text = "Save";
            this.btnAddNewClient.UseVisualStyleBackColor = true;
            this.btnAddNewClient.Click += new System.EventHandler(this.btnAddNewClient_Click);
            // 
            // Panel_AddClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.btnAddNewClient);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txbClientPassword);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txbClientName);
            this.Controls.Add(this.lblAddClient);
            this.MaximumSize = new System.Drawing.Size(1175, 931);
            this.MinimumSize = new System.Drawing.Size(1175, 931);
            this.Name = "Panel_AddClient";
            this.Size = new System.Drawing.Size(1175, 931);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAddClient;
        private System.Windows.Forms.TextBox txbClientName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txbClientPassword;
        private System.Windows.Forms.Button btnAddNewClient;
    }
}
