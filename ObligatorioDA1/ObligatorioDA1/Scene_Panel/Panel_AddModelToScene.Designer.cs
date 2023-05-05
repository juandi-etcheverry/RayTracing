namespace ObligatorioDA1.Scene_Panel
{
    partial class Panel_AddModelToScene
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
            this.btnReturnAddModel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddToScene = new System.Windows.Forms.Button();
            this.txbModelZCoordinates = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbModelYCoordinates = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbModelXCoordinates = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ModelPreview = new System.Windows.Forms.Panel();
            this.lblModelName = new System.Windows.Forms.Label();
            this.lblCoordinatesExceptions = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReturnAddModel
            // 
            this.btnReturnAddModel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReturnAddModel.ForeColor = System.Drawing.Color.White;
            this.btnReturnAddModel.Location = new System.Drawing.Point(120, 112);
            this.btnReturnAddModel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnReturnAddModel.Name = "btnReturnAddModel";
            this.btnReturnAddModel.Size = new System.Drawing.Size(164, 71);
            this.btnReturnAddModel.TabIndex = 7;
            this.btnReturnAddModel.Text = "Return";
            this.btnReturnAddModel.UseVisualStyleBackColor = false;
            this.btnReturnAddModel.Click += new System.EventHandler(this.btnReturnAddModel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lblCoordinatesExceptions);
            this.panel1.Controls.Add(this.btnAddToScene);
            this.panel1.Controls.Add(this.txbModelZCoordinates);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txbModelYCoordinates);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txbModelXCoordinates);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ModelPreview);
            this.panel1.Controls.Add(this.lblModelName);
            this.panel1.Location = new System.Drawing.Point(120, 213);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(984, 579);
            this.panel1.TabIndex = 8;
            // 
            // btnAddToScene
            // 
            this.btnAddToScene.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddToScene.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToScene.ForeColor = System.Drawing.Color.White;
            this.btnAddToScene.Location = new System.Drawing.Point(232, 415);
            this.btnAddToScene.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddToScene.Name = "btnAddToScene";
            this.btnAddToScene.Size = new System.Drawing.Size(476, 60);
            this.btnAddToScene.TabIndex = 17;
            this.btnAddToScene.Text = "Add to scene";
            this.btnAddToScene.UseVisualStyleBackColor = false;
            this.btnAddToScene.Click += new System.EventHandler(this.btnAddToScene_Click);
            // 
            // txbModelZCoordinates
            // 
            this.txbModelZCoordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbModelZCoordinates.Location = new System.Drawing.Point(574, 269);
            this.txbModelZCoordinates.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbModelZCoordinates.Name = "txbModelZCoordinates";
            this.txbModelZCoordinates.Size = new System.Drawing.Size(118, 44);
            this.txbModelZCoordinates.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(532, 275);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 37);
            this.label4.TabIndex = 15;
            this.label4.Text = "z:";
            // 
            // txbModelYCoordinates
            // 
            this.txbModelYCoordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbModelYCoordinates.Location = new System.Drawing.Point(344, 269);
            this.txbModelYCoordinates.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbModelYCoordinates.Name = "txbModelYCoordinates";
            this.txbModelYCoordinates.Size = new System.Drawing.Size(118, 44);
            this.txbModelYCoordinates.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(304, 273);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 37);
            this.label3.TabIndex = 13;
            this.label3.Text = "y:";
            // 
            // txbModelXCoordinates
            // 
            this.txbModelXCoordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbModelXCoordinates.Location = new System.Drawing.Point(124, 269);
            this.txbModelXCoordinates.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txbModelXCoordinates.Name = "txbModelXCoordinates";
            this.txbModelXCoordinates.Size = new System.Drawing.Size(118, 44);
            this.txbModelXCoordinates.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 273);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 37);
            this.label2.TabIndex = 11;
            this.label2.Text = "x:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 215);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 37);
            this.label1.TabIndex = 9;
            this.label1.Text = "Coordinates:";
            // 
            // ModelPreview
            // 
            this.ModelPreview.BackColor = System.Drawing.Color.White;
            this.ModelPreview.Location = new System.Drawing.Point(232, 75);
            this.ModelPreview.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ModelPreview.Name = "ModelPreview";
            this.ModelPreview.Size = new System.Drawing.Size(84, 67);
            this.ModelPreview.TabIndex = 10;
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblModelName.Location = new System.Drawing.Point(326, 85);
            this.lblModelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(306, 42);
            this.lblModelName.TabIndex = 9;
            this.lblModelName.Text = "Add Model Name";
            // 
            // lblCoordinatesExceptions
            // 
            this.lblCoordinatesExceptions.AutoSize = true;
            this.lblCoordinatesExceptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCoordinatesExceptions.Location = new System.Drawing.Point(82, 332);
            this.lblCoordinatesExceptions.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCoordinatesExceptions.Name = "lblCoordinatesExceptions";
            this.lblCoordinatesExceptions.Size = new System.Drawing.Size(243, 25);
            this.lblCoordinatesExceptions.TabIndex = 18;
            this.lblCoordinatesExceptions.Text = "* Coordinates Exception";
            // 
            // Panel_AddModelToScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReturnAddModel);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximumSize = new System.Drawing.Size(1200, 1000);
            this.MinimumSize = new System.Drawing.Size(1200, 1000);
            this.Name = "Panel_AddModelToScene";
            this.Size = new System.Drawing.Size(1200, 1000);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnReturnAddModel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblModelName;
        private System.Windows.Forms.Panel ModelPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbModelYCoordinates;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbModelXCoordinates;
        private System.Windows.Forms.TextBox txbModelZCoordinates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddToScene;
        private System.Windows.Forms.Label lblCoordinatesExceptions;
    }
}
