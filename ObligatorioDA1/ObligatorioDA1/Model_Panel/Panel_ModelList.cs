﻿using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;
using ImageController;

namespace ObligatorioDA1.Model_Panel
{
    public partial class Panel_ModelList : UserControl
    {
        private readonly ModelLogic _modelLogic = new ModelLogic();
        private readonly Panel_General _panelGeneral;
        private readonly SceneLogic _sceneLogic = new SceneLogic();

        public Panel_ModelList(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
            InitializeModelList();
        }

        public void RefreshModelList()
        {
            lblEliminationException.Visible = false;
            dgvModelList.Rows.Clear();
            foreach (var model in _modelLogic.GetClientModels().ToList())
            {
                if (model.WantPreview) PreviewController.LoadPreview(model);
                dgvModelList.Rows.Add(model.Preview, null, null, null, model.ModelName, model.Shape.ShapeName,
                    model.Material.MaterialName);
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
            _panelGeneral.GoToAddNewModel();
        }

        private void dgvModelList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                dgvModelList.Rows[e.RowIndex].Height = 50;
                if (dgvModelList.Columns[e.ColumnIndex].Name == "Colour")
                {
                    var cell = dgvModelList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    var modelName = dgvModelList.Rows[e.RowIndex].Cells[4].Value.ToString();
                    var model = _modelLogic.Get(modelName);
                    if (!model.WantPreview)
                    {
                        var newColor = GetColour(model);
                        PaintCell(cell, newColor);
                    }
                }
            }
        }

        private void dgvModelList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                string modelName;
                Model model;
                if (dgvModelList.Columns[e.ColumnIndex].Name == "Delete")
                    try
                    {
                        modelName = dgvModelList.CurrentRow.Cells[4].Value.ToString();
                        model = _modelLogic.Get(modelName);
                        _modelLogic.Remove(model);
                        dgvModelList.Rows.Remove(dgvModelList.CurrentRow);
                        lblEliminationException.Visible = false;
                    }
                    catch (AssociationException AssEx)
                    {
                        lblEliminationException.Visible = true;
                        lblEliminationException.Text = AssEx.Message;
                    }

                if (dgvModelList.Columns[e.ColumnIndex].Name == "Rename")
                {
                    modelName = dgvModelList.CurrentRow.Cells[4].Value.ToString();
                    model = _modelLogic.Get(modelName);
                    _panelGeneral.GoToModelRename(model);
                }
            }
        }

        private Color GetColour(Model _model)
        {
            var r = _model.Material.ColorX;
            var g = _model.Material.ColorY;
            var b = _model.Material.ColorZ;
            var newColor = Color.FromArgb(r, g, b);
            return newColor;
        }

        private void PaintCell(DataGridViewCell cell, Color color)
        {
            cell.Style.BackColor = color;
            cell.Style.SelectionBackColor = color;
            cell.Style.ForeColor = color;
            cell.ReadOnly = true;
        }
    }
}