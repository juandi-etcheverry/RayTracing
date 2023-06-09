namespace ObligatorioDA1
{
    partial class Panel_ShapeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel_ShapeList));
            this.btnAddShape = new System.Windows.Forms.Button();
            this.dgvShapeList = new System.Windows.Forms.DataGridView();
            this.Rename = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblEliminationException = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShapeList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddShape
            // 
            this.btnAddShape.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddShape.ForeColor = System.Drawing.Color.White;
            this.btnAddShape.Location = new System.Drawing.Point(62, 60);
            this.btnAddShape.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddShape.Name = "btnAddShape";
            this.btnAddShape.Size = new System.Drawing.Size(466, 37);
            this.btnAddShape.TabIndex = 0;
            this.btnAddShape.Text = "ADD SHAPE";
            this.btnAddShape.UseVisualStyleBackColor = false;
            this.btnAddShape.Click += new System.EventHandler(this.btnAddShape_Click);
            // 
            // dgvShapeList
            // 
            this.dgvShapeList.AllowUserToAddRows = false;
            this.dgvShapeList.AllowUserToResizeColumns = false;
            this.dgvShapeList.AllowUserToResizeRows = false;
            this.dgvShapeList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShapeList.BackgroundColor = System.Drawing.Color.White;
            this.dgvShapeList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvShapeList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvShapeList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShapeList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShapeList.ColumnHeadersHeight = 30;
            this.dgvShapeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvShapeList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rename,
            this.Delete});
            this.dgvShapeList.EnableHeadersVisualStyles = false;
            this.dgvShapeList.Location = new System.Drawing.Point(62, 119);
            this.dgvShapeList.Margin = new System.Windows.Forms.Padding(2);
            this.dgvShapeList.Name = "dgvShapeList";
            this.dgvShapeList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvShapeList.RowHeadersVisible = false;
            this.dgvShapeList.RowHeadersWidth = 82;
            this.dgvShapeList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvShapeList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvShapeList.RowTemplate.Height = 33;
            this.dgvShapeList.Size = new System.Drawing.Size(466, 316);
            this.dgvShapeList.TabIndex = 1;
            this.dgvShapeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShapeList_CellClick);
            this.dgvShapeList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvShapeList_CellPainting);
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
            this.lblEliminationException.Location = new System.Drawing.Point(59, 447);
            this.lblEliminationException.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEliminationException.Name = "lblEliminationException";
            this.lblEliminationException.Size = new System.Drawing.Size(147, 18);
            this.lblEliminationException.TabIndex = 7;
            this.lblEliminationException.Text = "Elimination exception";
            // 
            // Panel_ShapeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblEliminationException);
            this.Controls.Add(this.dgvShapeList);
            this.Controls.Add(this.btnAddShape);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(600, 520);
            this.MinimumSize = new System.Drawing.Size(600, 520);
            this.Name = "Panel_ShapeList";
            this.Size = new System.Drawing.Size(600, 520);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShapeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddShape;
        private System.Windows.Forms.DataGridView dgvShapeList;
        private System.Windows.Forms.DataGridViewImageColumn Rename;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.Label lblEliminationException;
    }
}
