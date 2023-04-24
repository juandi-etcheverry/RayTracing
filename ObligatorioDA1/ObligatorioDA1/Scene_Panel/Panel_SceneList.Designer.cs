namespace ObligatorioDA1.Scene_Panel
{
    partial class Panel_SceneList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel_SceneList));
            this.btnAddNewScene = new System.Windows.Forms.Button();
            this.dgvSceneList = new System.Windows.Forms.DataGridView();
            this.Img = new System.Windows.Forms.DataGridViewImageColumn();
            this.Rename = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSceneList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNewScene
            // 
            this.btnAddNewScene.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddNewScene.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewScene.ForeColor = System.Drawing.Color.White;
            this.btnAddNewScene.Location = new System.Drawing.Point(62, 59);
            this.btnAddNewScene.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddNewScene.Name = "btnAddNewScene";
            this.btnAddNewScene.Size = new System.Drawing.Size(466, 37);
            this.btnAddNewScene.TabIndex = 2;
            this.btnAddNewScene.Text = "ADD NEW SCENE";
            this.btnAddNewScene.UseVisualStyleBackColor = false;
            this.btnAddNewScene.Click += new System.EventHandler(this.btnAddNewScene_Click);
            // 
            // dgvSceneList
            // 
            this.dgvSceneList.AllowUserToAddRows = false;
            this.dgvSceneList.AllowUserToResizeColumns = false;
            this.dgvSceneList.AllowUserToResizeRows = false;
            this.dgvSceneList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSceneList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSceneList.BackgroundColor = System.Drawing.Color.White;
            this.dgvSceneList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSceneList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSceneList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSceneList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSceneList.ColumnHeadersHeight = 30;
            this.dgvSceneList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSceneList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Img,
            this.Rename,
            this.Delete});
            this.dgvSceneList.EnableHeadersVisualStyles = false;
            this.dgvSceneList.Location = new System.Drawing.Point(62, 117);
            this.dgvSceneList.Margin = new System.Windows.Forms.Padding(2);
            this.dgvSceneList.Name = "dgvSceneList";
            this.dgvSceneList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSceneList.RowHeadersVisible = false;
            this.dgvSceneList.RowHeadersWidth = 82;
            this.dgvSceneList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSceneList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSceneList.RowTemplate.Height = 33;
            this.dgvSceneList.Size = new System.Drawing.Size(466, 316);
            this.dgvSceneList.TabIndex = 3;
            // 
            // Img
            // 
            this.Img.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Img.HeaderText = "Img";
            this.Img.Name = "Img";
            this.Img.ReadOnly = true;
            this.Img.Width = 30;
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
            // Panel_SceneList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvSceneList);
            this.Controls.Add(this.btnAddNewScene);
            this.MaximumSize = new System.Drawing.Size(600, 520);
            this.MinimumSize = new System.Drawing.Size(600, 520);
            this.Name = "Panel_SceneList";
            this.Size = new System.Drawing.Size(600, 520);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSceneList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewScene;
        private System.Windows.Forms.DataGridView dgvSceneList;
        private System.Windows.Forms.DataGridViewImageColumn Img;
        private System.Windows.Forms.DataGridViewImageColumn Rename;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}
