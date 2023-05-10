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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel_SceneList));
            this.btnAddNewScene = new System.Windows.Forms.Button();
            this.dgvSceneList = new System.Windows.Forms.DataGridView();
            this.Preview = new System.Windows.Forms.DataGridViewImageColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Rename = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnSetings = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSceneList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNewScene
            // 
            this.btnAddNewScene.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddNewScene.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewScene.ForeColor = System.Drawing.Color.White;
            this.btnAddNewScene.Location = new System.Drawing.Point(46, 116);
            this.btnAddNewScene.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddNewScene.Name = "btnAddNewScene";
            this.btnAddNewScene.Size = new System.Drawing.Size(899, 71);
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSceneList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvSceneList.ColumnHeadersHeight = 30;
            this.dgvSceneList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvSceneList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Preview,
            this.Edit,
            this.Rename,
            this.Delete});
            this.dgvSceneList.EnableHeadersVisualStyles = false;
            this.dgvSceneList.Location = new System.Drawing.Point(46, 225);
            this.dgvSceneList.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSceneList.Name = "dgvSceneList";
            this.dgvSceneList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvSceneList.RowHeadersVisible = false;
            this.dgvSceneList.RowHeadersWidth = 82;
            this.dgvSceneList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSceneList.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvSceneList.RowTemplate.Height = 33;
            this.dgvSceneList.Size = new System.Drawing.Size(1095, 608);
            this.dgvSceneList.TabIndex = 3;
            this.dgvSceneList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSceneList_CellContentClick);
            this.dgvSceneList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvSceneList_CellPainting);
            // 
            // Preview
            // 
            this.Preview.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Preview.HeaderText = "Preview";
            this.Preview.Image = ((System.Drawing.Image)(resources.GetObject("Preview.Image")));
            this.Preview.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Preview.MinimumWidth = 10;
            this.Preview.Name = "Preview";
            this.Preview.ReadOnly = true;
            this.Preview.Width = 122;
            // 
            // Edit
            // 
            this.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Edit.HeaderText = "Edit";
            this.Edit.Image = ((System.Drawing.Image)(resources.GetObject("Edit.Image")));
            this.Edit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Edit.MinimumWidth = 10;
            this.Edit.Name = "Edit";
            this.Edit.Width = 69;
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
            this.Rename.Width = 126;
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
            this.Delete.Width = 103;
            // 
            // btnSetings
            // 
            this.btnSetings.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSetings.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetings.ForeColor = System.Drawing.Color.White;
            this.btnSetings.Location = new System.Drawing.Point(953, 116);
            this.btnSetings.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetings.Name = "btnSetings";
            this.btnSetings.Size = new System.Drawing.Size(188, 71);
            this.btnSetings.TabIndex = 4;
            this.btnSetings.Text = "SETTINGS";
            this.btnSetings.UseVisualStyleBackColor = false;
            this.btnSetings.Click += new System.EventHandler(this.btnSetings_Click);
            // 
            // Panel_SceneList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnSetings);
            this.Controls.Add(this.dgvSceneList);
            this.Controls.Add(this.btnAddNewScene);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximumSize = new System.Drawing.Size(1200, 1000);
            this.MinimumSize = new System.Drawing.Size(1200, 1000);
            this.Name = "Panel_SceneList";
            this.Size = new System.Drawing.Size(1200, 1000);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSceneList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewScene;
        private System.Windows.Forms.DataGridView dgvSceneList;
        private System.Windows.Forms.DataGridViewImageColumn Preview;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Rename;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.Button btnSetings;
    }
}
