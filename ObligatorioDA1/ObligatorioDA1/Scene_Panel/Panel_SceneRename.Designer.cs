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
            this.panel1.Location = new System.Drawing.Point(53, 130);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(489, 196);
            this.panel1.TabIndex = 5;
            // 
            // lblSceneRenameException
            // 
            this.lblSceneRenameException.AutoSize = true;
            this.lblSceneRenameException.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblSceneRenameException.Location = new System.Drawing.Point(71, 100);
            this.lblSceneRenameException.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSceneRenameException.Name = "lblSceneRenameException";
            this.lblSceneRenameException.Size = new System.Drawing.Size(92, 13);
            this.lblSceneRenameException.TabIndex = 3;
            this.lblSceneRenameException.Text = "* Name Exception";
            // 
            // btnRename
            // 
            this.btnRename.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRename.ForeColor = System.Drawing.Color.White;
            this.btnRename.Location = new System.Drawing.Point(139, 136);
            this.btnRename.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(205, 32);
            this.btnRename.TabIndex = 2;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = false;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // txbRenameScene
            // 
            this.txbRenameScene.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbRenameScene.Location = new System.Drawing.Point(74, 70);
            this.txbRenameScene.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txbRenameScene.Name = "txbRenameScene";
            this.txbRenameScene.Size = new System.Drawing.Size(338, 28);
            this.txbRenameScene.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "New name:";
            // 
            // btnReturnRename
            // 
            this.btnReturnRename.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReturnRename.ForeColor = System.Drawing.Color.White;
            this.btnReturnRename.Location = new System.Drawing.Point(53, 78);
            this.btnReturnRename.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReturnRename.Name = "btnReturnRename";
            this.btnReturnRename.Size = new System.Drawing.Size(82, 37);
            this.btnReturnRename.TabIndex = 7;
            this.btnReturnRename.Text = "Return";
            this.btnReturnRename.UseVisualStyleBackColor = false;
            this.btnReturnRename.Click += new System.EventHandler(this.btnReturnRename_Click);
            // 
            // Panel_SceneRename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnReturnRename);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(600, 520);
            this.MinimumSize = new System.Drawing.Size(600, 520);
            this.Name = "Panel_SceneRename";
            this.Size = new System.Drawing.Size(600, 520);
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
