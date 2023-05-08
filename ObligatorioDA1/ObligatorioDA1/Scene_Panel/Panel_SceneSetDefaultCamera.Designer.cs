namespace ObligatorioDA1.Scene_Panel
{
    partial class Panel_SceneSetDefaultCamera
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbSetDefaultCamera = new System.Windows.Forms.Label();
            this.btnReturnDefaultCamera = new System.Windows.Forms.Button();
            this.btnSaveDefaultCamera = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txbLookFromX = new System.Windows.Forms.TextBox();
            this.txbLookFromY = new System.Windows.Forms.TextBox();
            this.txbLookFromZ = new System.Windows.Forms.TextBox();
            this.txbLookAtX = new System.Windows.Forms.TextBox();
            this.txbLookAtY = new System.Windows.Forms.TextBox();
            this.txbLookAtZ = new System.Windows.Forms.TextBox();
            this.txbFoV = new System.Windows.Forms.TextBox();
            this.lblLookExceptions = new System.Windows.Forms.Label();
            this.lblFoVException = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lblFoVException);
            this.panel1.Controls.Add(this.lblLookExceptions);
            this.panel1.Controls.Add(this.txbFoV);
            this.panel1.Controls.Add(this.txbLookAtZ);
            this.panel1.Controls.Add(this.txbLookAtY);
            this.panel1.Controls.Add(this.txbLookAtX);
            this.panel1.Controls.Add(this.txbLookFromZ);
            this.panel1.Controls.Add(this.txbLookFromY);
            this.panel1.Controls.Add(this.txbLookFromX);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnSaveDefaultCamera);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.lbSetDefaultCamera);
            this.panel1.Location = new System.Drawing.Point(83, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1041, 594);
            this.panel1.TabIndex = 0;
            // 
            // lbSetDefaultCamera
            // 
            this.lbSetDefaultCamera.AutoSize = true;
            this.lbSetDefaultCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSetDefaultCamera.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbSetDefaultCamera.Location = new System.Drawing.Point(300, 34);
            this.lbSetDefaultCamera.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbSetDefaultCamera.Name = "lbSetDefaultCamera";
            this.lbSetDefaultCamera.Size = new System.Drawing.Size(445, 55);
            this.lbSetDefaultCamera.TabIndex = 8;
            this.lbSetDefaultCamera.Text = "Set default camera";
            // 
            // btnReturnDefaultCamera
            // 
            this.btnReturnDefaultCamera.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReturnDefaultCamera.ForeColor = System.Drawing.Color.White;
            this.btnReturnDefaultCamera.Location = new System.Drawing.Point(83, 80);
            this.btnReturnDefaultCamera.Margin = new System.Windows.Forms.Padding(4);
            this.btnReturnDefaultCamera.Name = "btnReturnDefaultCamera";
            this.btnReturnDefaultCamera.Size = new System.Drawing.Size(164, 71);
            this.btnReturnDefaultCamera.TabIndex = 17;
            this.btnReturnDefaultCamera.Text = "Return";
            this.btnReturnDefaultCamera.UseVisualStyleBackColor = false;
            this.btnReturnDefaultCamera.Click += new System.EventHandler(this.btnReturnDefaultCamera_Click);
            // 
            // btnSaveDefaultCamera
            // 
            this.btnSaveDefaultCamera.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSaveDefaultCamera.ForeColor = System.Drawing.Color.White;
            this.btnSaveDefaultCamera.Location = new System.Drawing.Point(421, 497);
            this.btnSaveDefaultCamera.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveDefaultCamera.Name = "btnSaveDefaultCamera";
            this.btnSaveDefaultCamera.Size = new System.Drawing.Size(164, 71);
            this.btnSaveDefaultCamera.TabIndex = 18;
            this.btnSaveDefaultCamera.Text = "Save";
            this.btnSaveDefaultCamera.UseVisualStyleBackColor = false;
            this.btnSaveDefaultCamera.Click += new System.EventHandler(this.btnSaveDefaultCamera_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(105, 174);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(170, 37);
            this.label13.TabIndex = 20;
            this.label13.Text = "Look from:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(426, 174);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 37);
            this.label1.TabIndex = 21;
            this.label1.Text = "Look at:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(717, 174);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 37);
            this.label2.TabIndex = 22;
            this.label2.Text = "Fov:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(105, 230);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 37);
            this.label3.TabIndex = 23;
            this.label3.Text = "X:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(105, 291);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 37);
            this.label4.TabIndex = 24;
            this.label4.Text = "Y:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(105, 348);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 37);
            this.label5.TabIndex = 25;
            this.label5.Text = "Z:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(426, 230);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 37);
            this.label6.TabIndex = 26;
            this.label6.Text = "X:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(425, 291);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 37);
            this.label7.TabIndex = 27;
            this.label7.Text = "Y:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(427, 348);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 37);
            this.label8.TabIndex = 28;
            this.label8.Text = "Z:";
            // 
            // txbLookFromX
            // 
            this.txbLookFromX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLookFromX.Location = new System.Drawing.Point(159, 229);
            this.txbLookFromX.Name = "txbLookFromX";
            this.txbLookFromX.Size = new System.Drawing.Size(116, 38);
            this.txbLookFromX.TabIndex = 1;
            // 
            // txbLookFromY
            // 
            this.txbLookFromY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLookFromY.Location = new System.Drawing.Point(159, 290);
            this.txbLookFromY.Name = "txbLookFromY";
            this.txbLookFromY.Size = new System.Drawing.Size(116, 38);
            this.txbLookFromY.TabIndex = 2;
            // 
            // txbLookFromZ
            // 
            this.txbLookFromZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLookFromZ.Location = new System.Drawing.Point(159, 347);
            this.txbLookFromZ.Name = "txbLookFromZ";
            this.txbLookFromZ.Size = new System.Drawing.Size(116, 38);
            this.txbLookFromZ.TabIndex = 3;
            // 
            // txbLookAtX
            // 
            this.txbLookAtX.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLookAtX.Location = new System.Drawing.Point(480, 229);
            this.txbLookAtX.Name = "txbLookAtX";
            this.txbLookAtX.Size = new System.Drawing.Size(116, 38);
            this.txbLookAtX.TabIndex = 4;
            // 
            // txbLookAtY
            // 
            this.txbLookAtY.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLookAtY.Location = new System.Drawing.Point(480, 290);
            this.txbLookAtY.Name = "txbLookAtY";
            this.txbLookAtY.Size = new System.Drawing.Size(116, 38);
            this.txbLookAtY.TabIndex = 5;
            // 
            // txbLookAtZ
            // 
            this.txbLookAtZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbLookAtZ.Location = new System.Drawing.Point(480, 347);
            this.txbLookAtZ.Name = "txbLookAtZ";
            this.txbLookAtZ.Size = new System.Drawing.Size(116, 38);
            this.txbLookAtZ.TabIndex = 6;
            // 
            // txbFoV
            // 
            this.txbFoV.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFoV.Location = new System.Drawing.Point(803, 174);
            this.txbFoV.Name = "txbFoV";
            this.txbFoV.Size = new System.Drawing.Size(116, 38);
            this.txbFoV.TabIndex = 7;
            // 
            // lblLookExceptions
            // 
            this.lblLookExceptions.AutoSize = true;
            this.lblLookExceptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLookExceptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblLookExceptions.Location = new System.Drawing.Point(107, 414);
            this.lblLookExceptions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLookExceptions.Name = "lblLookExceptions";
            this.lblLookExceptions.Size = new System.Drawing.Size(190, 29);
            this.lblLookExceptions.TabIndex = 26;
            this.lblLookExceptions.Text = "Look Exceptions";
            // 
            // lblFoVException
            // 
            this.lblFoVException.AutoSize = true;
            this.lblFoVException.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoVException.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFoVException.Location = new System.Drawing.Point(634, 238);
            this.lblFoVException.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFoVException.Name = "lblFoVException";
            this.lblFoVException.Size = new System.Drawing.Size(181, 29);
            this.lblFoVException.TabIndex = 29;
            this.lblFoVException.Text = "FoV Exceptions";
            // 
            // Panel_SceneSetDefaultCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnReturnDefaultCamera);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(1200, 1000);
            this.MinimumSize = new System.Drawing.Size(1200, 1000);
            this.Name = "Panel_SceneSetDefaultCamera";
            this.Size = new System.Drawing.Size(1200, 1000);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbSetDefaultCamera;
        private System.Windows.Forms.Button btnSaveDefaultCamera;
        private System.Windows.Forms.Button btnReturnDefaultCamera;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbFoV;
        private System.Windows.Forms.TextBox txbLookAtZ;
        private System.Windows.Forms.TextBox txbLookAtY;
        private System.Windows.Forms.TextBox txbLookAtX;
        private System.Windows.Forms.TextBox txbLookFromZ;
        private System.Windows.Forms.TextBox txbLookFromY;
        private System.Windows.Forms.TextBox txbLookFromX;
        private System.Windows.Forms.Label lblFoVException;
        private System.Windows.Forms.Label lblLookExceptions;
    }
}
