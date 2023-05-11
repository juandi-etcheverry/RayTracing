﻿namespace ObligatorioDA1
{
    partial class Panel_SceneEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Panel_SceneEditor));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblNewSceneName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDateLastModified = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblNoFileFound = new System.Windows.Forms.Label();
            this.btnRender = new System.Windows.Forms.Button();
            this.lblOutdatedImage = new System.Windows.Forms.Label();
            this.lblLastRenderedDate = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pboxRenderedScene = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txbXLookFrom = new System.Windows.Forms.TextBox();
            this.txbYLookFrom = new System.Windows.Forms.TextBox();
            this.txbZLookFrom = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txbFoV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txbXLookAt = new System.Windows.Forms.TextBox();
            this.txbYLookAt = new System.Windows.Forms.TextBox();
            this.txbZLookAt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblFoVException = new System.Windows.Forms.Label();
            this.lblLookExceptions = new System.Windows.Forms.Label();
            this.btnReturnNewScene = new System.Windows.Forms.Button();
            this.dgvAvailableModelsList = new System.Windows.Forms.DataGridView();
            this.Img = new System.Windows.Forms.DataGridViewImageColumn();
            this.Add = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvUsedModels = new System.Windows.Forms.DataGridView();
            this.Preview = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxRenderedScene)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableModelsList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsedModels)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNewSceneName
            // 
            this.lblNewSceneName.AutoSize = true;
            this.lblNewSceneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewSceneName.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblNewSceneName.Location = new System.Drawing.Point(141, 17);
            this.lblNewSceneName.Name = "lblNewSceneName";
            this.lblNewSceneName.Size = new System.Drawing.Size(212, 36);
            this.lblNewSceneName.TabIndex = 7;
            this.lblNewSceneName.Text = "My first scene";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(389, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Last modified:";
            // 
            // lblDateLastModified
            // 
            this.lblDateLastModified.AutoSize = true;
            this.lblDateLastModified.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateLastModified.Location = new System.Drawing.Point(535, 26);
            this.lblDateLastModified.Name = "lblDateLastModified";
            this.lblDateLastModified.Size = new System.Drawing.Size(112, 25);
            this.lblDateLastModified.TabIndex = 10;
            this.lblDateLastModified.Text = "20/04/2023";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.lblNoFileFound);
            this.panel1.Controls.Add(this.btnRender);
            this.panel1.Controls.Add(this.lblOutdatedImage);
            this.panel1.Controls.Add(this.lblLastRenderedDate);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Location = new System.Drawing.Point(17, 166);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 422);
            this.panel1.TabIndex = 14;
            // 
            // lblNoFileFound
            // 
            this.lblNoFileFound.AutoSize = true;
            this.lblNoFileFound.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoFileFound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblNoFileFound.Location = new System.Drawing.Point(221, 12);
            this.lblNoFileFound.Name = "lblNoFileFound";
            this.lblNoFileFound.Size = new System.Drawing.Size(185, 17);
            this.lblNoFileFound.TabIndex = 27;
            this.lblNoFileFound.Text = "*New model name exception";
            // 
            // btnRender
            // 
            this.btnRender.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRender.ForeColor = System.Drawing.Color.White;
            this.btnRender.Location = new System.Drawing.Point(257, 363);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(149, 45);
            this.btnRender.TabIndex = 8;
            this.btnRender.Text = "Render";
            this.btnRender.UseVisualStyleBackColor = false;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // lblOutdatedImage
            // 
            this.lblOutdatedImage.AutoSize = true;
            this.lblOutdatedImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutdatedImage.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblOutdatedImage.Location = new System.Drawing.Point(17, 352);
            this.lblOutdatedImage.Name = "lblOutdatedImage";
            this.lblOutdatedImage.Size = new System.Drawing.Size(151, 25);
            this.lblOutdatedImage.TabIndex = 20;
            this.lblOutdatedImage.Text = "Outdated image";
            // 
            // lblLastRenderedDate
            // 
            this.lblLastRenderedDate.AutoSize = true;
            this.lblLastRenderedDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastRenderedDate.Location = new System.Drawing.Point(177, 328);
            this.lblLastRenderedDate.Name = "lblLastRenderedDate";
            this.lblLastRenderedDate.Size = new System.Drawing.Size(112, 25);
            this.lblLastRenderedDate.TabIndex = 19;
            this.lblLastRenderedDate.Text = "20/04/2023";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(17, 328);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(138, 25);
            this.label13.TabIndex = 19;
            this.label13.Text = "Last rendered:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label12.Location = new System.Drawing.Point(16, 4);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 25);
            this.label12.TabIndex = 19;
            this.label12.Text = "Scene";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.pboxRenderedScene);
            this.panel3.Location = new System.Drawing.Point(21, 32);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(385, 292);
            this.panel3.TabIndex = 0;
            // 
            // pboxRenderedScene
            // 
            this.pboxRenderedScene.Location = new System.Drawing.Point(1, 0);
            this.pboxRenderedScene.Name = "pboxRenderedScene";
            this.pboxRenderedScene.Size = new System.Drawing.Size(383, 291);
            this.pboxRenderedScene.TabIndex = 0;
            this.pboxRenderedScene.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "Look from:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(165, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Look at:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(297, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 25);
            this.label5.TabIndex = 3;
            this.label5.Text = "FoV:";
            // 
            // txbXLookFrom
            // 
            this.txbXLookFrom.BackColor = System.Drawing.Color.Gainsboro;
            this.txbXLookFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbXLookFrom.Location = new System.Drawing.Point(9, 47);
            this.txbXLookFrom.Name = "txbXLookFrom";
            this.txbXLookFrom.Size = new System.Drawing.Size(31, 26);
            this.txbXLookFrom.TabIndex = 1;
            // 
            // txbYLookFrom
            // 
            this.txbYLookFrom.BackColor = System.Drawing.Color.Gainsboro;
            this.txbYLookFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbYLookFrom.Location = new System.Drawing.Point(47, 47);
            this.txbYLookFrom.Name = "txbYLookFrom";
            this.txbYLookFrom.Size = new System.Drawing.Size(31, 26);
            this.txbYLookFrom.TabIndex = 2;
            // 
            // txbZLookFrom
            // 
            this.txbZLookFrom.BackColor = System.Drawing.Color.Gainsboro;
            this.txbZLookFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbZLookFrom.Location = new System.Drawing.Point(84, 47);
            this.txbZLookFrom.Name = "txbZLookFrom";
            this.txbZLookFrom.Size = new System.Drawing.Size(31, 26);
            this.txbZLookFrom.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(17, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "x";
            // 
            // txbFoV
            // 
            this.txbFoV.BackColor = System.Drawing.Color.Gainsboro;
            this.txbFoV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbFoV.Location = new System.Drawing.Point(360, 4);
            this.txbFoV.Name = "txbFoV";
            this.txbFoV.Size = new System.Drawing.Size(63, 26);
            this.txbFoV.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(53, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(91, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "z";
            // 
            // txbXLookAt
            // 
            this.txbXLookAt.BackColor = System.Drawing.Color.Gainsboro;
            this.txbXLookAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbXLookAt.Location = new System.Drawing.Point(171, 47);
            this.txbXLookAt.Name = "txbXLookAt";
            this.txbXLookAt.Size = new System.Drawing.Size(31, 26);
            this.txbXLookAt.TabIndex = 4;
            // 
            // txbYLookAt
            // 
            this.txbYLookAt.BackColor = System.Drawing.Color.Gainsboro;
            this.txbYLookAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbYLookAt.Location = new System.Drawing.Point(209, 47);
            this.txbYLookAt.Name = "txbYLookAt";
            this.txbYLookAt.Size = new System.Drawing.Size(31, 26);
            this.txbYLookAt.TabIndex = 5;
            // 
            // txbZLookAt
            // 
            this.txbZLookAt.BackColor = System.Drawing.Color.Gainsboro;
            this.txbZLookAt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbZLookAt.Location = new System.Drawing.Point(247, 47);
            this.txbZLookAt.Name = "txbZLookAt";
            this.txbZLookAt.Size = new System.Drawing.Size(31, 26);
            this.txbZLookAt.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(179, 28);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "x";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(217, 27);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 17);
            this.label10.TabIndex = 23;
            this.label10.Text = "y";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(255, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 17);
            this.label11.TabIndex = 24;
            this.label11.Text = "z";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.Controls.Add(this.lblFoVException);
            this.panel2.Controls.Add(this.lblLookExceptions);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.txbZLookAt);
            this.panel2.Controls.Add(this.txbYLookAt);
            this.panel2.Controls.Add(this.txbXLookAt);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txbFoV);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txbZLookFrom);
            this.panel2.Controls.Add(this.txbYLookFrom);
            this.panel2.Controls.Add(this.txbXLookFrom);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(17, 68);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(432, 91);
            this.panel2.TabIndex = 15;
            // 
            // lblFoVException
            // 
            this.lblFoVException.AutoSize = true;
            this.lblFoVException.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFoVException.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblFoVException.Location = new System.Drawing.Point(289, 30);
            this.lblFoVException.MaximumSize = new System.Drawing.Size(167, 16);
            this.lblFoVException.Name = "lblFoVException";
            this.lblFoVException.Size = new System.Drawing.Size(125, 16);
            this.lblFoVException.TabIndex = 26;
            this.lblFoVException.Text = "*New model name exception";
            // 
            // lblLookExceptions
            // 
            this.lblLookExceptions.AutoSize = true;
            this.lblLookExceptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLookExceptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblLookExceptions.Location = new System.Drawing.Point(6, 73);
            this.lblLookExceptions.Name = "lblLookExceptions";
            this.lblLookExceptions.Size = new System.Drawing.Size(185, 17);
            this.lblLookExceptions.TabIndex = 25;
            this.lblLookExceptions.Text = "*New model name exception";
            // 
            // btnReturnNewScene
            // 
            this.btnReturnNewScene.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnReturnNewScene.ForeColor = System.Drawing.Color.White;
            this.btnReturnNewScene.Location = new System.Drawing.Point(17, 15);
            this.btnReturnNewScene.Name = "btnReturnNewScene";
            this.btnReturnNewScene.Size = new System.Drawing.Size(109, 45);
            this.btnReturnNewScene.TabIndex = 16;
            this.btnReturnNewScene.Text = "Return";
            this.btnReturnNewScene.UseVisualStyleBackColor = false;
            this.btnReturnNewScene.Click += new System.EventHandler(this.btnReturnNewScene_Click);
            // 
            // dgvAvailableModelsList
            // 
            this.dgvAvailableModelsList.AllowUserToAddRows = false;
            this.dgvAvailableModelsList.AllowUserToResizeColumns = false;
            this.dgvAvailableModelsList.AllowUserToResizeRows = false;
            this.dgvAvailableModelsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvailableModelsList.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvAvailableModelsList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAvailableModelsList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvAvailableModelsList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAvailableModelsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAvailableModelsList.ColumnHeadersHeight = 30;
            this.dgvAvailableModelsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAvailableModelsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Img,
            this.Add});
            this.dgvAvailableModelsList.EnableHeadersVisualStyles = false;
            this.dgvAvailableModelsList.Location = new System.Drawing.Point(456, 96);
            this.dgvAvailableModelsList.Name = "dgvAvailableModelsList";
            this.dgvAvailableModelsList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvAvailableModelsList.RowHeadersVisible = false;
            this.dgvAvailableModelsList.RowHeadersWidth = 82;
            this.dgvAvailableModelsList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvAvailableModelsList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAvailableModelsList.RowTemplate.Height = 33;
            this.dgvAvailableModelsList.Size = new System.Drawing.Size(321, 216);
            this.dgvAvailableModelsList.TabIndex = 17;
            this.dgvAvailableModelsList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAvailableModelsList_CellClick);
            this.dgvAvailableModelsList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAvailableModelsList_CellPainting);
            // 
            // Img
            // 
            this.Img.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Img.FillWeight = 187.1795F;
            this.Img.HeaderText = "Img";
            this.Img.Image = ((System.Drawing.Image)(resources.GetObject("Img.Image")));
            this.Img.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Img.MinimumWidth = 10;
            this.Img.Name = "Img";
            this.Img.Width = 43;
            // 
            // Add
            // 
            this.Add.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Add.FillWeight = 12.82051F;
            this.Add.HeaderText = "Add";
            this.Add.Image = ((System.Drawing.Image)(resources.GetObject("Add.Image")));
            this.Add.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Add.MinimumWidth = 10;
            this.Add.Name = "Add";
            this.Add.Width = 45;
            // 
            // dgvUsedModels
            // 
            this.dgvUsedModels.AllowUserToAddRows = false;
            this.dgvUsedModels.AllowUserToResizeColumns = false;
            this.dgvUsedModels.AllowUserToResizeRows = false;
            this.dgvUsedModels.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsedModels.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvUsedModels.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsedModels.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsedModels.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DodgerBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsedModels.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsedModels.ColumnHeadersHeight = 30;
            this.dgvUsedModels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvUsedModels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Preview,
            this.Delete});
            this.dgvUsedModels.EnableHeadersVisualStyles = false;
            this.dgvUsedModels.Location = new System.Drawing.Point(456, 362);
            this.dgvUsedModels.Name = "dgvUsedModels";
            this.dgvUsedModels.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvUsedModels.RowHeadersVisible = false;
            this.dgvUsedModels.RowHeadersWidth = 82;
            this.dgvUsedModels.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvUsedModels.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUsedModels.RowTemplate.Height = 33;
            this.dgvUsedModels.Size = new System.Drawing.Size(321, 227);
            this.dgvUsedModels.TabIndex = 18;
            this.dgvUsedModels.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsedModels_CellClick);
            this.dgvUsedModels.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvUsedModels_CellPainting);
            // 
            // Preview
            // 
            this.Preview.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Preview.FillWeight = 187.1795F;
            this.Preview.HeaderText = "Img";
            this.Preview.Image = ((System.Drawing.Image)(resources.GetObject("Preview.Image")));
            this.Preview.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Preview.MinimumWidth = 10;
            this.Preview.Name = "Preview";
            this.Preview.Width = 43;
            // 
            // Delete
            // 
            this.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Delete.FillWeight = 12.82051F;
            this.Delete.HeaderText = "Del";
            this.Delete.Image = ((System.Drawing.Image)(resources.GetObject("Delete.Image")));
            this.Delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Delete.MinimumWidth = 10;
            this.Delete.Name = "Delete";
            this.Delete.Width = 42;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label14.Location = new System.Drawing.Point(456, 68);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(160, 25);
            this.label14.TabIndex = 21;
            this.label14.Text = "Available models";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label16.Location = new System.Drawing.Point(451, 335);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(126, 25);
            this.label16.TabIndex = 22;
            this.label16.Text = "Used models";
            // 
            // Panel_SceneEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dgvUsedModels);
            this.Controls.Add(this.dgvAvailableModelsList);
            this.Controls.Add(this.btnReturnNewScene);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblDateLastModified);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblNewSceneName);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(800, 640);
            this.MinimumSize = new System.Drawing.Size(800, 640);
            this.Name = "Panel_SceneEditor";
            this.Size = new System.Drawing.Size(800, 640);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxRenderedScene)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailableModelsList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsedModels)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Label lblNewSceneName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDateLastModified;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbXLookFrom;
        private System.Windows.Forms.TextBox txbYLookFrom;
        private System.Windows.Forms.TextBox txbZLookFrom;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txbFoV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbXLookAt;
        private System.Windows.Forms.TextBox txbYLookAt;
        private System.Windows.Forms.TextBox txbZLookAt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnReturnNewScene;
        private System.Windows.Forms.Button btnRender;
        private System.Windows.Forms.Label lblOutdatedImage;
        private System.Windows.Forms.Label lblLastRenderedDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvAvailableModelsList;
        private System.Windows.Forms.DataGridView dgvUsedModels;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewImageColumn Img;
        private System.Windows.Forms.DataGridViewImageColumn Add;
        private System.Windows.Forms.DataGridViewImageColumn Preview;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.Label lblLookExceptions;
        private System.Windows.Forms.Label lblFoVException;
        private System.Windows.Forms.PictureBox pboxRenderedScene;
        private System.Windows.Forms.Label lblNoFileFound;
    }
}
