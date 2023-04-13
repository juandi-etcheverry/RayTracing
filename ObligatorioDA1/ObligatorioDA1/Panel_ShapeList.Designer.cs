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
            this.btnAddShape = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddShape
            // 
            this.btnAddShape.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddShape.ForeColor = System.Drawing.Color.White;
            this.btnAddShape.Location = new System.Drawing.Point(164, 116);
            this.btnAddShape.Name = "btnAddShape";
            this.btnAddShape.Size = new System.Drawing.Size(868, 72);
            this.btnAddShape.TabIndex = 0;
            this.btnAddShape.Text = "ADD SHAPE";
            this.btnAddShape.UseVisualStyleBackColor = false;
            this.btnAddShape.Click += new System.EventHandler(this.btnAddShape_Click);
            // 
            // Panel_ShapeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnAddShape);
            this.MaximumSize = new System.Drawing.Size(1200, 1000);
            this.MinimumSize = new System.Drawing.Size(1200, 1000);
            this.Name = "Panel_ShapeList";
            this.Size = new System.Drawing.Size(1200, 1000);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddShape;
    }
}
