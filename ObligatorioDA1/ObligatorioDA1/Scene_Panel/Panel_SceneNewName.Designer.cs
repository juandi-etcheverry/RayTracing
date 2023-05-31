namespace ObligatorioDA1.Model_Panel
{
    partial class Panel_SceneNewName
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSceneNameException = new System.Windows.Forms.Label();
            this.btnConfirmSceneName = new System.Windows.Forms.Button();
            this.txbSceneName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReturnSceneName = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lblSceneNameException);
            this.panel1.Controls.Add(this.btnConfirmSceneName);
            this.panel1.Controls.Add(this.txbSceneName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(112, 237);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 377);
            this.panel1.TabIndex = 4;
            // 
            // lblSceneNameException
            // 
            this.lblSceneNameException.AutoSize = true;
            this.lblSceneNameException.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSceneNameException.Location = new System.Drawing.Point(142, 192);
            this.lblSceneNameException.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSceneNameException.Name = "lblSceneNameException";
            this.lblSceneNameException.Size = new System.Drawing.Size(183, 25);
            this.lblSceneNameException.TabIndex = 3;
            this.lblSceneNameException.Text = "* MaterialName Exception";
            // 
            // btnConfirmSceneName
            // 
            this.btnConfirmSceneName.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnConfirmSceneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmSceneName.ForeColor = System.Drawing.Color.White;
            this.btnConfirmSceneName.Location = new System.Drawing.Point(278, 262);
            this.btnConfirmSceneName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConfirmSceneName.Name = "btnConfirmSceneName";
            this.btnConfirmSceneName.Size = new System.Drawing.Size(410, 62);
            this.btnConfirmSceneName.TabIndex = 2;
            this.btnConfirmSceneName.Text = "Create new scene";
            this.btnConfirmSceneName.UseVisualStyleBackColor = false;
            this.btnConfirmSceneName.Click += new System.EventHandler(this.btnConfirmSceneName_Click);
            // 
            // txbSceneName
            // 
            this.txbSceneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbSceneName.Location = new System.Drawing.Point(148, 135);
            this.txbSceneName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbSceneName.Name = "txbSceneName";
            this.txbSceneName.Size = new System.Drawing.Size(672, 49);
            this.txbSceneName.TabIndex = 1;
            this.txbSceneName.TextChanged += new System.EventHandler(this.txbSceneName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "New scene name:";
            // 
            // btnReturnSceneName
            // 
            this.btnReturnSceneName.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReturnSceneName.ForeColor = System.Drawing.Color.White;
            this.btnReturnSceneName.Location = new System.Drawing.Point(112, 138);
            this.btnReturnSceneName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReturnSceneName.Name = "btnReturnSceneName";
            this.btnReturnSceneName.Size = new System.Drawing.Size(164, 71);
            this.btnReturnSceneName.TabIndex = 6;
            this.btnReturnSceneName.Text = "Return";
            this.btnReturnSceneName.UseVisualStyleBackColor = false;
            this.btnReturnSceneName.Click += new System.EventHandler(this.btnReturnSceneName_Click);
            // 
            // Panel_SceneNewName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnReturnSceneName);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximumSize = new System.Drawing.Size(1200, 1000);
            this.MinimumSize = new System.Drawing.Size(1200, 1000);
            this.Name = "Panel_SceneNewName";
            this.Size = new System.Drawing.Size(1200, 1000);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSceneNameException;
        private System.Windows.Forms.Button btnConfirmSceneName;
        private System.Windows.Forms.TextBox txbSceneName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReturnSceneName;
    }
}
