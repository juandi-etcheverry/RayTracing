﻿using BusinessLogic;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObligatorioDA1.Model_Panel
{
    public partial class Panel_ModelList : UserControl
    {
        private Client _client;
        private ModelLogic _modelLogic = new ModelLogic();
        private Panel_General _panelGeneral;
        public Panel_ModelList(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
            InitializeModelList();
        }
        public void RefreshModelList(Client client)
        {
            _client = client;
            dgvModelList.Rows.Clear();
            foreach (Model model in _modelLogic.GetClientModels().ToList())
            {
                dgvModelList.Rows.Add(null, null, null, null, model.Name, model.Shape.Name, model.Material.Name);
            }
        }
        private void InitializeModelList()
        {
            AddColumns();
            SetDisplayOrderColumns();
            SetWidthColumns();
        }
        private void AddColumns()
        {
            dgvModelList.Columns.Add("Colour", " ");
            dgvModelList.Columns.Add("Name", "Name");
            dgvModelList.Columns.Add("Shape", "Shape");
            dgvModelList.Columns.Add("Material", "Material");
        }
        private void SetDisplayOrderColumns()
        {
            dgvModelList.Columns["Colour"].DisplayIndex = 0;
            dgvModelList.Columns["Preview"].DisplayIndex = 1;
            dgvModelList.Columns["Name"].DisplayIndex = 2;
            dgvModelList.Columns["Shape"].DisplayIndex = 3;
            dgvModelList.Columns["Material"].DisplayIndex = 4;
            dgvModelList.Columns["Rename"].DisplayIndex = 5;
            dgvModelList.Columns["Delete"].DisplayIndex = 6;
        }
        private void SetWidthColumns()
        {
            dgvModelList.Columns["Name"].Width = 100;
            dgvModelList.Columns["Colour"].Width = 5;
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToAddNewModel();
        }

        private void dgvModelList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                this.dgvModelList.Rows[e.RowIndex].Height = 50;
                if(this.dgvModelList.Columns[e.ColumnIndex].Name == "Colour")
                {
                    DataGridViewCell cell = this.dgvModelList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    String modelName = dgvModelList.Rows[e.RowIndex].Cells[4].Value.ToString();
                    Model model = _modelLogic.Get(modelName);
                    if (!model.WantPreview)
                    {
                        int r = (int)model.Material.Color.Item1;
                        int g = (int)model.Material.Color.Item2;
                        int b = (int)model.Material.Color.Item3;
                        Color newColor = Color.FromArgb(r, g, b);
                        cell.Style.BackColor = newColor;
                        cell.Style.SelectionBackColor = newColor;
                        cell.Style.ForeColor = newColor;
                        cell.ReadOnly = true;
                    }
                }
                if(this.dgvModelList.Columns[e.ColumnIndex].Name == "Preview")
                {
                    DataGridViewCell cell = this.dgvModelList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    String modelName = dgvModelList.Rows[e.RowIndex].Cells[4].Value.ToString();
                    Model model = _modelLogic.Get(modelName);
                    if (model.WantPreview)
                    {
                        // Insert preview on cell
                    }
                }
            }
        }

        private void dgvModelList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String modelName;
            Model model;
            if (this.dgvModelList.Columns[e.ColumnIndex].Name == "Delete")
            {
                modelName = dgvModelList.CurrentRow.Cells[4].Value.ToString();
                model = _modelLogic.Get(modelName);
                _modelLogic.Remove(model);
                dgvModelList.Rows.Remove(dgvModelList.CurrentRow);
            }
            if (this.dgvModelList.Columns[e.ColumnIndex].Name == "Rename")
            {
                 modelName = dgvModelList.CurrentRow.Cells[4].Value.ToString();
                 model = _modelLogic.Get(modelName);
                _panelGeneral.goToModelRename(model);
            }
        }
    }
}