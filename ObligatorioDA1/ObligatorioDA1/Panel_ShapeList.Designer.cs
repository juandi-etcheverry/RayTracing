﻿namespace ObligatorioDA1
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
            this.btnAddShape = new System.Windows.Forms.Button();
            this.dgvShapeList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShapeList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddShape
            // 
            this.btnAddShape.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddShape.ForeColor = System.Drawing.Color.White;
            this.btnAddShape.Location = new System.Drawing.Point(124, 116);
            this.btnAddShape.Name = "btnAddShape";
            this.btnAddShape.Size = new System.Drawing.Size(933, 72);
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
            this.dgvShapeList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dgvShapeList.EnableHeadersVisualStyles = false;
            this.dgvShapeList.Location = new System.Drawing.Point(124, 228);
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
            this.dgvShapeList.Size = new System.Drawing.Size(933, 608);
            this.dgvShapeList.TabIndex = 1;
            this.dgvShapeList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShapeList_CellClick);
            this.dgvShapeList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvShapeList_CellPainting);
            // 
            // Panel_ShapeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.dgvShapeList);
            this.Controls.Add(this.btnAddShape);
            this.MaximumSize = new System.Drawing.Size(1200, 1000);
            this.MinimumSize = new System.Drawing.Size(1200, 1000);
            this.Name = "Panel_ShapeList";
            this.Size = new System.Drawing.Size(1200, 1000);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShapeList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddShape;
        private System.Windows.Forms.DataGridView dgvShapeList;
    }
}
