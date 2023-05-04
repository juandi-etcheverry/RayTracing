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
            this.txbModelYCoordinates = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbModelXCoordinates = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ModelPreview = new System.Windows.Forms.Panel();
            this.lblModelName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txbModelZCoordinates = new System.Windows.Forms.TextBox();
            this.btnAddToScene = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnReturnAddModel
            // 
            this.btnReturnAddModel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReturnAddModel.ForeColor = System.Drawing.Color.White;
            this.btnReturnAddModel.Location = new System.Drawing.Point(60, 58);
            this.btnReturnAddModel.Margin = new System.Windows.Forms.Padding(2);
            this.btnReturnAddModel.Name = "btnReturnAddModel";
            this.btnReturnAddModel.Size = new System.Drawing.Size(82, 37);
            this.btnReturnAddModel.TabIndex = 7;
            this.btnReturnAddModel.Text = "Return";
            this.btnReturnAddModel.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
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
            this.panel1.Location = new System.Drawing.Point(60, 111);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(492, 301);
            this.panel1.TabIndex = 8;
            // 
            // txbModelYCoordinates
            // 
            this.txbModelYCoordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbModelYCoordinates.Location = new System.Drawing.Point(172, 140);
            this.txbModelYCoordinates.Margin = new System.Windows.Forms.Padding(2);
            this.txbModelYCoordinates.Name = "txbModelYCoordinates";
            this.txbModelYCoordinates.Size = new System.Drawing.Size(61, 26);
            this.txbModelYCoordinates.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(152, 142);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "y:";
            // 
            // txbModelXCoordinates
            // 
            this.txbModelXCoordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbModelXCoordinates.Location = new System.Drawing.Point(62, 140);
            this.txbModelXCoordinates.Margin = new System.Windows.Forms.Padding(2);
            this.txbModelXCoordinates.Name = "txbModelXCoordinates";
            this.txbModelXCoordinates.Size = new System.Drawing.Size(61, 26);
            this.txbModelXCoordinates.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(40, 142);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "x:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(40, 112);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Coordinates:";
            // 
            // ModelPreview
            // 
            this.ModelPreview.BackColor = System.Drawing.Color.White;
            this.ModelPreview.Location = new System.Drawing.Point(116, 39);
            this.ModelPreview.Name = "ModelPreview";
            this.ModelPreview.Size = new System.Drawing.Size(42, 35);
            this.ModelPreview.TabIndex = 10;
            // 
            // lblModelName
            // 
            this.lblModelName.AutoSize = true;
            this.lblModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblModelName.Location = new System.Drawing.Point(163, 44);
            this.lblModelName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblModelName.Name = "lblModelName";
            this.lblModelName.Size = new System.Drawing.Size(159, 24);
            this.lblModelName.TabIndex = 9;
            this.lblModelName.Text = "Add Model Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(266, 143);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "z:";
            // 
            // txbModelZCoordinates
            // 
            this.txbModelZCoordinates.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbModelZCoordinates.Location = new System.Drawing.Point(287, 140);
            this.txbModelZCoordinates.Margin = new System.Windows.Forms.Padding(2);
            this.txbModelZCoordinates.Name = "txbModelZCoordinates";
            this.txbModelZCoordinates.Size = new System.Drawing.Size(61, 26);
            this.txbModelZCoordinates.TabIndex = 16;
            // 
            // btnAddToScene
            // 
            this.btnAddToScene.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddToScene.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddToScene.ForeColor = System.Drawing.Color.White;
            this.btnAddToScene.Location = new System.Drawing.Point(116, 216);
            this.btnAddToScene.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddToScene.Name = "btnAddToScene";
            this.btnAddToScene.Size = new System.Drawing.Size(238, 31);
            this.btnAddToScene.TabIndex = 17;
            this.btnAddToScene.Text = "Add to scene";
            this.btnAddToScene.UseVisualStyleBackColor = false;
            // 
            // Panel_AddModelToScene
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnReturnAddModel);
            this.MaximumSize = new System.Drawing.Size(600, 520);
            this.MinimumSize = new System.Drawing.Size(600, 520);
            this.Name = "Panel_AddModelToScene";
            this.Size = new System.Drawing.Size(600, 520);
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
    }
}
