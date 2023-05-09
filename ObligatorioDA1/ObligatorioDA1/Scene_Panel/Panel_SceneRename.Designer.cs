namespace ObligatorioDA1.Scene_Panel
{
    partial class Panel_SceneRename
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
            this.lblSceneRenameException = new System.Windows.Forms.Label();
            this.btnRename = new System.Windows.Forms.Button();
            this.txbRenameScene = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReturnRename = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lblSceneRenameException);
            this.panel1.Controls.Add(this.btnRename);
            this.panel1.Controls.Add(this.txbRenameScene);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(106, 250);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 377);
            this.panel1.TabIndex = 5;
            // 
            // lblSceneRenameException
            // 
            this.lblSceneRenameException.AutoSize = true;
            this.lblSceneRenameException.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSceneRenameException.Location = new System.Drawing.Point(142, 192);
            this.lblSceneRenameException.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSceneRenameException.Name = "lblSceneRenameException";
            this.lblSceneRenameException.Size = new System.Drawing.Size(183, 25);
            this.lblSceneRenameException.TabIndex = 3;
            this.lblSceneRenameException.Text = "* Name Exception";
            // 
            // btnRename
            // 
            this.btnRename.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRename.ForeColor = System.Drawing.Color.White;
            this.btnRename.Location = new System.Drawing.Point(278, 262);
            this.btnRename.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(410, 62);
            this.btnRename.TabIndex = 2;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = false;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // txbRenameScene
            // 
            this.txbRenameScene.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbRenameScene.Location = new System.Drawing.Point(148, 135);
            this.txbRenameScene.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbRenameScene.Name = "txbRenameScene";
            this.txbRenameScene.Size = new System.Drawing.Size(672, 49);
            this.txbRenameScene.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(140, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "New name:";
            // 
            // btnReturnRename
            // 
            this.btnReturnRename.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReturnRename.ForeColor = System.Drawing.Color.White;
            this.btnReturnRename.Location = new System.Drawing.Point(106, 150);
            this.btnReturnRename.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReturnRename.Name = "btnReturnRename";
            this.btnReturnRename.Size = new System.Drawing.Size(164, 71);
            this.btnReturnRename.TabIndex = 7;
            this.btnReturnRename.Text = "Return";
            this.btnReturnRename.UseVisualStyleBackColor = false;
            this.btnReturnRename.Click += new System.EventHandler(this.btnReturnRename_Click);
            // 
            // Panel_SceneRename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnReturnRename);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximumSize = new System.Drawing.Size(1200, 1000);
            this.MinimumSize = new System.Drawing.Size(1200, 1000);
            this.Name = "Panel_SceneRename";
            this.Size = new System.Drawing.Size(1200, 1000);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSceneRenameException;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.TextBox txbRenameScene;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReturnRename;
    }
}
