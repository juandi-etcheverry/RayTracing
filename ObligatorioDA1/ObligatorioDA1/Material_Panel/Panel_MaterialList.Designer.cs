namespace ObligatorioDA1.Material_Panel
{
    partial class Panel_MaterialList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel_MaterialList));
            this.btnAddMaterial = new System.Windows.Forms.Button();
            this.dgvMaterialList = new System.Windows.Forms.DataGridView();
            this.Rename = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblEliminationException = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddMaterial
            // 
            this.btnAddMaterial.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMaterial.ForeColor = System.Drawing.Color.White;
            this.btnAddMaterial.Location = new System.Drawing.Point(63, 59);
            this.btnAddMaterial.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddMaterial.Name = "btnAddMaterial";
            this.btnAddMaterial.Size = new System.Drawing.Size(466, 37);
            this.btnAddMaterial.TabIndex = 1;
            this.btnAddMaterial.Text = "ADD MATERIAL";
            this.btnAddMaterial.UseVisualStyleBackColor = false;
            this.btnAddMaterial.Click += new System.EventHandler(this.btnAddMaterial_Click);
            // 
            // dgvMaterialList
            // 
            this.dgvMaterialList.AllowUserToAddRows = false;
            this.dgvMaterialList.AllowUserToResizeColumns = false;
            this.dgvMaterialList.AllowUserToResizeRows = false;
            this.dgvMaterialList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMaterialList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMaterialList.BackgroundColor = System.Drawing.Color.White;
            this.dgvMaterialList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMaterialList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvMaterialList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMaterialList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMaterialList.ColumnHeadersHeight = 30;
            this.dgvMaterialList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMaterialList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rename,
            this.Delete});
            this.dgvMaterialList.EnableHeadersVisualStyles = false;
            this.dgvMaterialList.Location = new System.Drawing.Point(63, 117);
            this.dgvMaterialList.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMaterialList.Name = "dgvMaterialList";
            this.dgvMaterialList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvMaterialList.RowHeadersVisible = false;
            this.dgvMaterialList.RowHeadersWidth = 82;
            this.dgvMaterialList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvMaterialList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvMaterialList.RowTemplate.Height = 33;
            this.dgvMaterialList.Size = new System.Drawing.Size(466, 316);
            this.dgvMaterialList.TabIndex = 2;
            this.dgvMaterialList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterialList_CellClick);
            this.dgvMaterialList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvMaterialList_CellPainting);
            // 
            // Rename
            // 
            this.Rename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Rename.FillWeight = 187.1795F;
            this.Rename.HeaderText = "Rename";
            this.Rename.Image = ((System.Drawing.Image)(resources.GetObject("Rename.Image")));
            this.Rename.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Rename.MinimumWidth = 10;
            this.Rename.Name = "Rename";
            this.Rename.Width = 71;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Delete.FillWeight = 12.82051F;
            this.Delete.HeaderText = "Delete";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Delete.MinimumWidth = 10;
            this.Delete.Name = "Delete";
            this.Delete.Width = 59;
            // 
            // lblEliminationException
            // 
            this.lblEliminationException.AutoSize = true;
            this.lblEliminationException.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEliminationException.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEliminationException.Location = new System.Drawing.Point(60, 445);
            this.lblEliminationException.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEliminationException.Name = "lblEliminationException";
            this.lblEliminationException.Size = new System.Drawing.Size(147, 18);
            this.lblEliminationException.TabIndex = 6;
            this.lblEliminationException.Text = "Elimination exception";
            // 
            // Panel_MaterialList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblEliminationException);
            this.Controls.Add(this.dgvMaterialList);
            this.Controls.Add(this.btnAddMaterial);
            this.MaximumSize = new System.Drawing.Size(600, 520);
            this.MinimumSize = new System.Drawing.Size(600, 520);
            this.Name = "Panel_MaterialList";
            this.Size = new System.Drawing.Size(600, 520);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterialList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddMaterial;
        private System.Windows.Forms.DataGridView dgvMaterialList;
        private System.Windows.Forms.DataGridViewImageColumn Rename;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.Label lblEliminationException;
    }
}
