namespace ObligatorioDA1.Model_Panel
{
    partial class Panel_ModelAddNew
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
            this.btnShowAllModels = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblModelSelectMaterial = new System.Windows.Forms.Label();
            this.lblModelSelectShape = new System.Windows.Forms.Label();
            this.ckbModelPreview = new System.Windows.Forms.CheckBox();
            this.cmbNewModelMaterial = new System.Windows.Forms.ComboBox();
            this.cmbNewModelShape = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnNewModel = new System.Windows.Forms.Button();
            this.lblNewModelNameException = new System.Windows.Forms.Label();
            this.txbNewModelName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowAllModels
            // 
            this.btnShowAllModels.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnShowAllModels.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAllModels.ForeColor = System.Drawing.Color.White;
            this.btnShowAllModels.Location = new System.Drawing.Point(82, 59);
            this.btnShowAllModels.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowAllModels.Name = "btnShowAllModels";
            this.btnShowAllModels.Size = new System.Drawing.Size(434, 37);
            this.btnShowAllModels.TabIndex = 6;
            this.btnShowAllModels.Text = "SHOW ALL MODELS";
            this.btnShowAllModels.UseVisualStyleBackColor = false;
            this.btnShowAllModels.Click += new System.EventHandler(this.btnShowAllModels_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lblModelSelectMaterial);
            this.panel1.Controls.Add(this.lblModelSelectShape);
            this.panel1.Controls.Add(this.ckbModelPreview);
            this.panel1.Controls.Add(this.cmbNewModelMaterial);
            this.panel1.Controls.Add(this.cmbNewModelShape);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnNewModel);
            this.panel1.Controls.Add(this.lblNewModelNameException);
            this.panel1.Controls.Add(this.txbNewModelName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(82, 114);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 332);
            this.panel1.TabIndex = 4;
            // 
            // lblModelSelectMaterial
            // 
            this.lblModelSelectMaterial.AutoSize = true;
            this.lblModelSelectMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelSelectMaterial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblModelSelectMaterial.Location = new System.Drawing.Point(246, 207);
            this.lblModelSelectMaterial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblModelSelectMaterial.Name = "lblModelSelectMaterial";
            this.lblModelSelectMaterial.Size = new System.Drawing.Size(93, 15);
            this.lblModelSelectMaterial.TabIndex = 12;
            this.lblModelSelectMaterial.Text = "Must select one";
            // 
            // lblModelSelectShape
            // 
            this.lblModelSelectShape.AutoSize = true;
            this.lblModelSelectShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModelSelectShape.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblModelSelectShape.Location = new System.Drawing.Point(49, 207);
            this.lblModelSelectShape.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblModelSelectShape.Name = "lblModelSelectShape";
            this.lblModelSelectShape.Size = new System.Drawing.Size(93, 15);
            this.lblModelSelectShape.TabIndex = 11;
            this.lblModelSelectShape.Text = "Must select one";
            // 
            // ckbModelPreview
            // 
            this.ckbModelPreview.AutoSize = true;
            this.ckbModelPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ckbModelPreview.Location = new System.Drawing.Point(52, 245);
            this.ckbModelPreview.Name = "ckbModelPreview";
            this.ckbModelPreview.Size = new System.Drawing.Size(212, 24);
            this.ckbModelPreview.TabIndex = 4;
            this.ckbModelPreview.Text = "Generate preview on save";
            this.ckbModelPreview.UseVisualStyleBackColor = true;
            // 
            // cmbNewModelMaterial
            // 
            this.cmbNewModelMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNewModelMaterial.FormattingEnabled = true;
            this.cmbNewModelMaterial.Location = new System.Drawing.Point(249, 175);
            this.cmbNewModelMaterial.Name = "cmbNewModelMaterial";
            this.cmbNewModelMaterial.Size = new System.Drawing.Size(140, 28);
            this.cmbNewModelMaterial.TabIndex = 3;
            // 
            // cmbNewModelShape
            // 
            this.cmbNewModelShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNewModelShape.FormattingEnabled = true;
            this.cmbNewModelShape.Location = new System.Drawing.Point(52, 175);
            this.cmbNewModelShape.Name = "cmbNewModelShape";
            this.cmbNewModelShape.Size = new System.Drawing.Size(140, 28);
            this.cmbNewModelShape.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(245, 152);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Material:";
            // 
            // btnNewModel
            // 
            this.btnNewModel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnNewModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewModel.ForeColor = System.Drawing.Color.White;
            this.btnNewModel.Location = new System.Drawing.Point(98, 285);
            this.btnNewModel.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewModel.Name = "btnNewModel";
            this.btnNewModel.Size = new System.Drawing.Size(238, 31);
            this.btnNewModel.TabIndex = 5;
            this.btnNewModel.Text = "Add Model";
            this.btnNewModel.UseVisualStyleBackColor = false;
            this.btnNewModel.Click += new System.EventHandler(this.btnNewModel_Click);
            // 
            // lblNewModelNameException
            // 
            this.lblNewModelNameException.AutoSize = true;
            this.lblNewModelNameException.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewModelNameException.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNewModelNameException.Location = new System.Drawing.Point(49, 117);
            this.lblNewModelNameException.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewModelNameException.Name = "lblNewModelNameException";
            this.lblNewModelNameException.Size = new System.Drawing.Size(166, 15);
            this.lblNewModelNameException.TabIndex = 5;
            this.lblNewModelNameException.Text = "*New model name exception";
            // 
            // txbNewModelName
            // 
            this.txbNewModelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNewModelName.Location = new System.Drawing.Point(52, 89);
            this.txbNewModelName.Margin = new System.Windows.Forms.Padding(2);
            this.txbNewModelName.Name = "txbNewModelName";
            this.txbNewModelName.Size = new System.Drawing.Size(337, 26);
            this.txbNewModelName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(170, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "New Model";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 152);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Shape:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 69);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // Panel_ModelAddNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnShowAllModels);
            this.MaximumSize = new System.Drawing.Size(600, 520);
            this.MinimumSize = new System.Drawing.Size(600, 520);
            this.Name = "Panel_ModelAddNew";
            this.Size = new System.Drawing.Size(600, 520);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowAllModels;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNewModel;
        private System.Windows.Forms.Label lblNewModelNameException;
        private System.Windows.Forms.TextBox txbNewModelName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblModelSelectShape;
        private System.Windows.Forms.CheckBox ckbModelPreview;
        private System.Windows.Forms.ComboBox cmbNewModelMaterial;
        private System.Windows.Forms.ComboBox cmbNewModelShape;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblModelSelectMaterial;
    }
}
