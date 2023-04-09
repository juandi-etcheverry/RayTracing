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
            this.btnHome = new System.Windows.Forms.Button();
            this.btnAddClient = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // flyPanelPrincipal
            // 
            this.flyPanelPrincipal.Location = new System.Drawing.Point(300, 1);
            this.flyPanelPrincipal.MaximumSize = new System.Drawing.Size(1175, 931);
            this.flyPanelPrincipal.MinimumSize = new System.Drawing.Size(1175, 931);
            this.flyPanelPrincipal.Name = "flyPanelPrincipal";
            this.flyPanelPrincipal.Size = new System.Drawing.Size(1175, 931);
            this.flyPanelPrincipal.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(29, 107);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(224, 85);
            this.btnHome.TabIndex = 1;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnAddClient
            // 
            this.btnAddClient.Location = new System.Drawing.Point(29, 244);
            this.btnAddClient.Name = "btnAddClient";
            this.btnAddClient.Size = new System.Drawing.Size(224, 85);
            this.btnAddClient.TabIndex = 2;
            this.btnAddClient.Text = "Add Client";
            this.btnAddClient.UseVisualStyleBackColor = true;
            this.btnAddClient.Click += new System.EventHandler(this.btnAddClient_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1474, 929);
            this.Controls.Add(this.btnAddClient);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.flyPanelPrincipal);
            this.MaximumSize = new System.Drawing.Size(1500, 1000);
            this.MinimumSize = new System.Drawing.Size(1500, 1000);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flyPanelPrincipal;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnAddClient;
    }
}

