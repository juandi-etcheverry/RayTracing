namespace ObligatorioDA1.Model_Panel
{
    partial class Panel_ModelList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel_ModelList));
            this.btnAddModel = new System.Windows.Forms.Button();
            this.dgvModelList = new System.Windows.Forms.DataGridView();
            this.Rename = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvModelList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddModel
            // 
            this.btnAddModel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddModel.ForeColor = System.Drawing.Color.White;
            this.btnAddModel.Location = new System.Drawing.Point(62, 60);
            this.btnAddModel.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddModel.Name = "btnAddModel";
            this.btnAddModel.Size = new System.Drawing.Size(466, 37);
            this.btnAddModel.TabIndex = 1;
            this.btnAddModel.Text = "ADD MODEL";
            this.btnAddModel.UseVisualStyleBackColor = false;
            // 
            // dgvModelList
            // 
            this.dgvModelList.AllowUserToAddRows = false;
            this.dgvModelList.AllowUserToResizeColumns = false;
            this.dgvModelList.AllowUserToResizeRows = false;
            this.dgvModelList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvModelList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvModelList.BackgroundColor = System.Drawing.Color.White;
            this.dgvModelList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvModelList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvModelList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvModelList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvModelList.ColumnHeadersHeight = 30;
            this.dgvModelList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvModelList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rename,
            this.Delete});
            this.dgvModelList.EnableHeadersVisualStyles = false;
            this.dgvModelList.Location = new System.Drawing.Point(62, 116);
            this.dgvModelList.Margin = new System.Windows.Forms.Padding(2);
            this.dgvModelList.Name = "dgvModelList";
            this.dgvModelList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvModelList.RowHeadersVisible = false;
            this.dgvModelList.RowHeadersWidth = 82;
            this.dgvModelList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvModelList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvModelList.RowTemplate.Height = 33;
            this.dgvModelList.Size = new System.Drawing.Size(466, 316);
            this.dgvModelList.TabIndex = 3;
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
            // Panel_ModelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvModelList);
            this.Controls.Add(this.btnAddModel);
            this.MaximumSize = new System.Drawing.Size(600, 520);
            this.MinimumSize = new System.Drawing.Size(600, 520);
            this.Name = "Panel_ModelList";
            this.Size = new System.Drawing.Size(600, 520);
            ((System.ComponentModel.ISupportInitialize)(this.dgvModelList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddModel;
        private System.Windows.Forms.DataGridView dgvModelList;
        private System.Windows.Forms.DataGridViewImageColumn Rename;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}
