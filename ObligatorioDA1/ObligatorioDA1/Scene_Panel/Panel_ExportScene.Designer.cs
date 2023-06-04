namespace ObligatorioDA1.Scene_Panel
{
    partial class Panel_ExportScene
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
            this.lblSceneName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.rbtnPPM = new System.Windows.Forms.RadioButton();
            this.rbtnJPG = new System.Windows.Forms.RadioButton();
            this.rbtnPNG = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSceneName
            // 
            this.lblSceneName.AutoSize = true;
            this.lblSceneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSceneName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblSceneName.Location = new System.Drawing.Point(411, 189);
            this.lblSceneName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSceneName.Name = "lblSceneName";
            this.lblSceneName.Size = new System.Drawing.Size(333, 55);
            this.lblSceneName.TabIndex = 9;
            this.lblSceneName.Text = "My first scene";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.rbtnPPM);
            this.panel1.Controls.Add(this.rbtnJPG);
            this.panel1.Controls.Add(this.rbtnPNG);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(169, 275);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 423);
            this.panel1.TabIndex = 10;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Location = new System.Drawing.Point(262, 324);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(313, 70);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "EXPORT";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // rbtnPPM
            // 
            this.rbtnPPM.AutoSize = true;
            this.rbtnPPM.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPPM.Location = new System.Drawing.Point(609, 176);
            this.rbtnPPM.Name = "rbtnPPM";
            this.rbtnPPM.Size = new System.Drawing.Size(147, 55);
            this.rbtnPPM.TabIndex = 3;
            this.rbtnPPM.TabStop = true;
            this.rbtnPPM.Text = "PPM";
            this.rbtnPPM.UseVisualStyleBackColor = true;
            // 
            // rbtnJPG
            // 
            this.rbtnJPG.AutoSize = true;
            this.rbtnJPG.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnJPG.Location = new System.Drawing.Point(350, 176);
            this.rbtnJPG.Name = "rbtnJPG";
            this.rbtnJPG.Size = new System.Drawing.Size(137, 55);
            this.rbtnJPG.TabIndex = 2;
            this.rbtnJPG.TabStop = true;
            this.rbtnJPG.Text = "JPG";
            this.rbtnJPG.UseVisualStyleBackColor = true;
            // 
            // rbtnPNG
            // 
            this.rbtnPNG.AutoSize = true;
            this.rbtnPNG.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtnPNG.Location = new System.Drawing.Point(68, 176);
            this.rbtnPNG.Name = "rbtnPNG";
            this.rbtnPNG.Size = new System.Drawing.Size(146, 55);
            this.rbtnPNG.TabIndex = 1;
            this.rbtnPNG.TabStop = true;
            this.rbtnPNG.Text = "PNG";
            this.rbtnPNG.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(61, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Export as:";
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReturn.ForeColor = System.Drawing.Color.White;
            this.btnReturn.Location = new System.Drawing.Point(64, 55);
            this.btnReturn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(224, 70);
            this.btnReturn.TabIndex = 10;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // Panel_ExportScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSceneName);
            this.MaximumSize = new System.Drawing.Size(1200, 1000);
            this.MinimumSize = new System.Drawing.Size(1200, 1000);
            this.Name = "Panel_ExportScene";
            this.Size = new System.Drawing.Size(1200, 1000);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblSceneName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbtnJPG;
        private System.Windows.Forms.RadioButton rbtnPNG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtnPPM;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnReturn;
    }
}
