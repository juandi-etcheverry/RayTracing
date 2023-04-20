namespace ObligatorioDA1.Model_Panel
{
    partial class Panel_ModelRename
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
            this.lblRenameException = new System.Windows.Forms.Label();
            this.btnConfirmRename = new System.Windows.Forms.Button();
            this.txbModellRename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReturnRename = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lblRenameException);
            this.panel1.Controls.Add(this.btnConfirmRename);
            this.panel1.Controls.Add(this.txbModellRename);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(55, 111);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(489, 196);
            this.panel1.TabIndex = 3;
            // 
            // lblRenameException
            // 
            this.lblRenameException.AutoSize = true;
            this.lblRenameException.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblRenameException.Location = new System.Drawing.Point(71, 100);
            this.lblRenameException.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRenameException.Name = "lblRenameException";
            this.lblRenameException.Size = new System.Drawing.Size(92, 13);
            this.lblRenameException.TabIndex = 3;
            this.lblRenameException.Text = "* Name Exception";
            // 
            // btnConfirmRename
            // 
            this.btnConfirmRename.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnConfirmRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmRename.ForeColor = System.Drawing.Color.White;
            this.btnConfirmRename.Location = new System.Drawing.Point(167, 134);
            this.btnConfirmRename.Margin = new System.Windows.Forms.Padding(2);
            this.btnConfirmRename.Name = "btnConfirmRename";
            this.btnConfirmRename.Size = new System.Drawing.Size(168, 32);
            this.btnConfirmRename.TabIndex = 2;
            this.btnConfirmRename.Text = "Rename";
            this.btnConfirmRename.UseVisualStyleBackColor = false;
            // 
            // txbModellRename
            // 
            this.txbModellRename.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbModellRename.Location = new System.Drawing.Point(74, 70);
            this.txbModellRename.Margin = new System.Windows.Forms.Padding(2);
            this.txbModellRename.Name = "txbModellRename";
            this.txbModellRename.Size = new System.Drawing.Size(338, 28);
            this.txbModellRename.TabIndex = 1;
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
            this.btnReturnRename.Location = new System.Drawing.Point(55, 60);
            this.btnReturnRename.Margin = new System.Windows.Forms.Padding(2);
            this.btnReturnRename.Name = "btnReturnRename";
            this.btnReturnRename.Size = new System.Drawing.Size(82, 37);
            this.btnReturnRename.TabIndex = 5;
            this.btnReturnRename.Text = "Return";
            this.btnReturnRename.UseVisualStyleBackColor = false;
            // 
            // Panel_ModelRename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnReturnRename);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(600, 520);
            this.MinimumSize = new System.Drawing.Size(600, 520);
            this.Name = "Panel_ModelRename";
            this.Size = new System.Drawing.Size(600, 520);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRenameException;
        private System.Windows.Forms.Button btnConfirmRename;
        private System.Windows.Forms.TextBox txbModellRename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReturnRename;
    }
}
