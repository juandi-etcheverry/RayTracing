namespace ObligatorioDA1
{
    partial class Panel_General
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
            this.flyGeneral = new System.Windows.Forms.FlowLayoutPanel();
            this.btnShapes = new System.Windows.Forms.Button();
            this.btnMaterials = new System.Windows.Forms.Button();
            this.btnModels = new System.Windows.Forms.Button();
            this.btnScenes = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lblUsername = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flyGeneral
            // 
            this.flyGeneral.BackColor = System.Drawing.Color.White;
            this.flyGeneral.Location = new System.Drawing.Point(299, 0);
            this.flyGeneral.MaximumSize = new System.Drawing.Size(1200, 1000);
            this.flyGeneral.MinimumSize = new System.Drawing.Size(1200, 1000);
            this.flyGeneral.Name = "flyGeneral";
            this.flyGeneral.Size = new System.Drawing.Size(1200, 1000);
            this.flyGeneral.TabIndex = 0;
            // 
            // btnShapes
            // 
            this.btnShapes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShapes.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnShapes.Location = new System.Drawing.Point(34, 236);
            this.btnShapes.Name = "btnShapes";
            this.btnShapes.Size = new System.Drawing.Size(225, 70);
            this.btnShapes.TabIndex = 1;
            this.btnShapes.Text = "Shapes";
            this.btnShapes.UseVisualStyleBackColor = true;
            this.btnShapes.Click += new System.EventHandler(this.btnShapes_Click);
            // 
            // btnMaterials
            // 
            this.btnMaterials.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaterials.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnMaterials.Location = new System.Drawing.Point(34, 330);
            this.btnMaterials.Name = "btnMaterials";
            this.btnMaterials.Size = new System.Drawing.Size(225, 70);
            this.btnMaterials.TabIndex = 2;
            this.btnMaterials.Text = "Materials";
            this.btnMaterials.UseVisualStyleBackColor = true;
            // 
            // btnModels
            // 
            this.btnModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModels.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnModels.Location = new System.Drawing.Point(34, 426);
            this.btnModels.Name = "btnModels";
            this.btnModels.Size = new System.Drawing.Size(225, 70);
            this.btnModels.TabIndex = 3;
            this.btnModels.Text = "Models";
            this.btnModels.UseVisualStyleBackColor = true;
            // 
            // btnScenes
            // 
            this.btnScenes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScenes.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnScenes.Location = new System.Drawing.Point(34, 521);
            this.btnScenes.Name = "btnScenes";
            this.btnScenes.Size = new System.Drawing.Size(225, 70);
            this.btnScenes.TabIndex = 4;
            this.btnScenes.Text = "Scenes";
            this.btnScenes.UseVisualStyleBackColor = true;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnLogOut.Location = new System.Drawing.Point(34, 749);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(225, 70);
            this.btnLogOut.TabIndex = 5;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(98, 59);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(84, 37);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "User";
            // 
            // Panel_General
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DodgerBlue;
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnScenes);
            this.Controls.Add(this.btnModels);
            this.Controls.Add(this.btnMaterials);
            this.Controls.Add(this.btnShapes);
            this.Controls.Add(this.flyGeneral);
            this.MaximumSize = new System.Drawing.Size(1500, 1000);
            this.MinimumSize = new System.Drawing.Size(1500, 1000);
            this.Name = "Panel_General";
            this.Size = new System.Drawing.Size(1500, 1000);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flyGeneral;
        private System.Windows.Forms.Button btnShapes;
        private System.Windows.Forms.Button btnMaterials;
        private System.Windows.Forms.Button btnModels;
        private System.Windows.Forms.Button btnScenes;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblUsername;
    }
}
