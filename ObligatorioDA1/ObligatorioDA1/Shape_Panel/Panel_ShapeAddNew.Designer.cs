﻿namespace ObligatorioDA1
{
    partial class Panel_ShapeAddNew
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
            this.btnShowAllShapes = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNewShape = new System.Windows.Forms.Button();
            this.lblNewShapeRadiusException = new System.Windows.Forms.Label();
            this.lblNewShapeNameException = new System.Windows.Forms.Label();
            this.txbNewShapeRadius = new System.Windows.Forms.TextBox();
            this.txbNewShapeName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShowAllShapes
            // 
            this.btnShowAllShapes.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnShowAllShapes.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAllShapes.ForeColor = System.Drawing.Color.White;
            this.btnShowAllShapes.Location = new System.Drawing.Point(82, 60);
            this.btnShowAllShapes.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowAllShapes.Name = "btnShowAllShapes";
            this.btnShowAllShapes.Size = new System.Drawing.Size(434, 37);
            this.btnShowAllShapes.TabIndex = 1;
            this.btnShowAllShapes.Text = "SHOW ALL SHAPES";
            this.btnShowAllShapes.UseVisualStyleBackColor = false;
            this.btnShowAllShapes.Click += new System.EventHandler(this.btnShowAllShapes_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.btnNewShape);
            this.panel1.Controls.Add(this.lblNewShapeRadiusException);
            this.panel1.Controls.Add(this.lblNewShapeNameException);
            this.panel1.Controls.Add(this.txbNewShapeRadius);
            this.panel1.Controls.Add(this.txbNewShapeName);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(82, 116);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 304);
            this.panel1.TabIndex = 2;
            // 
            // btnNewShape
            // 
            this.btnNewShape.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnNewShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewShape.ForeColor = System.Drawing.Color.White;
            this.btnNewShape.Location = new System.Drawing.Point(98, 244);
            this.btnNewShape.Margin = new System.Windows.Forms.Padding(2);
            this.btnNewShape.Name = "btnNewShape";
            this.btnNewShape.Size = new System.Drawing.Size(238, 31);
            this.btnNewShape.TabIndex = 3;
            this.btnNewShape.Text = "Add Shape";
            this.btnNewShape.UseVisualStyleBackColor = false;
            this.btnNewShape.Click += new System.EventHandler(this.btnNewShape_Click);
            // 
            // lblNewShapeRadiusException
            // 
            this.lblNewShapeRadiusException.AutoSize = true;
            this.lblNewShapeRadiusException.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewShapeRadiusException.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNewShapeRadiusException.Location = new System.Drawing.Point(49, 202);
            this.lblNewShapeRadiusException.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewShapeRadiusException.Name = "lblNewShapeRadiusException";
            this.lblNewShapeRadiusException.Size = new System.Drawing.Size(167, 15);
            this.lblNewShapeRadiusException.TabIndex = 6;
            this.lblNewShapeRadiusException.Text = "*New shape radius exception";
            // 
            // lblNewShapeNameException
            // 
            this.lblNewShapeNameException.AutoSize = true;
            this.lblNewShapeNameException.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewShapeNameException.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNewShapeNameException.Location = new System.Drawing.Point(49, 118);
            this.lblNewShapeNameException.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewShapeNameException.Name = "lblNewShapeNameException";
            this.lblNewShapeNameException.Size = new System.Drawing.Size(165, 15);
            this.lblNewShapeNameException.TabIndex = 5;
            this.lblNewShapeNameException.Text = "*New shape name exception";
            // 
            // txbNewShapeRadius
            // 
            this.txbNewShapeRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNewShapeRadius.Location = new System.Drawing.Point(52, 175);
            this.txbNewShapeRadius.Margin = new System.Windows.Forms.Padding(2);
            this.txbNewShapeRadius.Name = "txbNewShapeRadius";
            this.txbNewShapeRadius.Size = new System.Drawing.Size(337, 26);
            this.txbNewShapeRadius.TabIndex = 2;
            this.txbNewShapeRadius.TextChanged += new System.EventHandler(this.txbNewShapeRadius_TextChanged);
            // 
            // txbNewShapeName
            // 
            this.txbNewShapeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbNewShapeName.Location = new System.Drawing.Point(52, 91);
            this.txbNewShapeName.Margin = new System.Windows.Forms.Padding(2);
            this.txbNewShapeName.Name = "txbNewShapeName";
            this.txbNewShapeName.Size = new System.Drawing.Size(337, 26);
            this.txbNewShapeName.TabIndex = 1;
            this.txbNewShapeName.TextChanged += new System.EventHandler(this.txbNewShapeName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label3.Location = new System.Drawing.Point(170, 29);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "New Shape";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(48, 154);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Radius:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // Panel_ShapeAddNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnShowAllShapes);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(600, 520);
            this.MinimumSize = new System.Drawing.Size(600, 520);
            this.Name = "Panel_ShapeAddNew";
            this.Size = new System.Drawing.Size(600, 520);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowAllShapes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNewShape;
        private System.Windows.Forms.Label lblNewShapeRadiusException;
        private System.Windows.Forms.Label lblNewShapeNameException;
        private System.Windows.Forms.TextBox txbNewShapeRadius;
        private System.Windows.Forms.TextBox txbNewShapeName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}