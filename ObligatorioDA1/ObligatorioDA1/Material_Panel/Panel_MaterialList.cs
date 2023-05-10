using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic;
using Domain;

namespace ObligatorioDA1.Material_Panel
{
    public partial class Panel_MaterialList : UserControl
    {
        private readonly MaterialLogic _materialLogic = new MaterialLogic();
        private readonly Panel_General _panelGeneral;

        public Panel_MaterialList(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
            InitializeList();
        }

        public void RefreshMaterialList()
        {
            dgvMaterialList.Rows.Clear();
            foreach (var material in _materialLogic.GetClientMaterials().ToList())
                dgvMaterialList.Rows.Add(null, null, null, material.Name, material.Color.Item1, material.Color.Item2,
                    material.Color.Item3);
        }

        private void InitializeList()
        {
            AddColumns();
            SetDisplayOrderColumns();
            SetWidthColumns();
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToAddNewMaterial();
        }

        private void dgvMaterialList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string materialName;
            Material material;
            if (dgvMaterialList.Columns[e.ColumnIndex].Name == "Delete")
            {
                materialName = dgvMaterialList.CurrentRow.Cells[3].Value.ToString();
                material = _materialLogic.Get(materialName);
                _materialLogic.Remove(material);
                dgvMaterialList.Rows.Remove(dgvMaterialList.CurrentRow);
            }

            if (dgvMaterialList.Columns[e.ColumnIndex].Name == "Rename")
            {
                materialName = dgvMaterialList.CurrentRow.Cells[3].Value.ToString();
                material = _materialLogic.Get(materialName);
                _panelGeneral.GoToMaterialRename(material);
            }
        }

        private void dgvMaterialList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                dgvMaterialList.Rows[e.RowIndex].Height = 50;
                if (dgvMaterialList.Columns[e.ColumnIndex].Name == "Colour1")
                {
                    var cell = dgvMaterialList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    var materialName = dgvMaterialList.Rows[e.RowIndex].Cells[3].Value.ToString();
                    var material = _materialLogic.Get(materialName);
                    var newColor = GetColour(material);
                    PaintCell(cell, newColor);
                }
            }
        }

        private void AddColumns()
        {
            dgvMaterialList.Columns.Add("Colour1", "");
            dgvMaterialList.Columns.Add("Name", "Name");
            dgvMaterialList.Columns.Add("R", "R");
            dgvMaterialList.Columns.Add("G", "G");
            dgvMaterialList.Columns.Add("B", "B");
        }

        private void SetDisplayOrderColumns()
        {
            dgvMaterialList.Columns["Colour1"].DisplayIndex = 0;
            dgvMaterialList.Columns["Name"].DisplayIndex = 1;
            dgvMaterialList.Columns["R"].DisplayIndex = 2;
            dgvMaterialList.Columns["G"].DisplayIndex = 3;
            dgvMaterialList.Columns["B"].DisplayIndex = 4;
            dgvMaterialList.Columns["Rename"].DisplayIndex = 5;
            dgvMaterialList.Columns["Delete"].DisplayIndex = 6;
        }

        private void SetWidthColumns()
        {
            dgvMaterialList.Columns["Colour1"].Width = 30;
            dgvMaterialList.Columns["R"].Width = 20;
            dgvMaterialList.Columns["G"].Width = 20;
            dgvMaterialList.Columns["B"].Width = 20;
        }

        private Color GetColour(Material _material)
        {
            var r = (int)_material.Color.Item1;
            var g = (int)_material.Color.Item2;
            var b = (int)_material.Color.Item3;
            var newColor = Color.FromArgb(r, g, b);
            return newColor;
        }

        private void PaintCell(DataGridViewCell cell, Color color)
        {
            cell.Style.SelectionBackColor = color;
            cell.Style.BackColor = color;
            cell.Style.ForeColor = color;
            cell.ReadOnly = true;
        }
    }
}