using BusinessLogic;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObligatorioDA1.Material_Panel
{
    public partial class Panel_MaterialList : UserControl
    {
        private Panel_General _panelGeneral;
        private Client _client;
        MaterialLogic _materialLogic = new MaterialLogic();
        public Panel_MaterialList(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
            initializeList();
        }
        private void initializeList()
        {
            addColumns();
            setDisplayOrderColumns();
            setWidthColumns();
            //refreshMaterialList(_client);
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToAddNewMaterial();
        }
        public void refreshMaterialList(Client _client)
        {
            dgvMaterialList.Rows.Clear();
            foreach (Material material in _materialLogic.GetClientMaterials().ToList())
            {
                if (material.OwnerName == _client.Name)
                {
                    dgvMaterialList.Rows.Add(null, null, null, material.Name, material.Color.Item1, material.Color.Item2, material.Color.Item3);
                }
            }
        }

        private void dgvMaterialList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String materialName;
            Material material;
            if (this.dgvMaterialList.Columns[e.ColumnIndex].Name == "Delete")
            {
                 materialName = dgvMaterialList.CurrentRow.Cells[3].Value.ToString();
                 material = _materialLogic.Get(materialName);
                _materialLogic.Remove(material);
                dgvMaterialList.Rows.Remove(dgvMaterialList.CurrentRow);
            }
            if (this.dgvMaterialList.Columns[e.ColumnIndex].Name == "Rename")
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
                this.dgvMaterialList.Rows[e.RowIndex].Height = 50;
                if (this.dgvMaterialList.Columns[e.ColumnIndex].Name == "Colour1")
                {
                    DataGridViewCell cell = this.dgvMaterialList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    String materialName = dgvMaterialList.Rows[e.RowIndex].Cells[3].Value.ToString();
                    Material material = _materialLogic.Get(materialName);
                    int r = (int) material.Color.Item1;
                    int g = (int) material.Color.Item2;
                    int b = (int) material.Color.Item3;
                    Color newColor = Color.FromArgb(r, g, b);

                    cell.Style.SelectionBackColor = newColor;
                    cell.Style.BackColor = newColor;
                    cell.Style.ForeColor = newColor;
                    cell.ReadOnly = true;
                }
            }
                

        }
        private void addColumns()
        {
            dgvMaterialList.Columns.Add("Colour1", "");
            dgvMaterialList.Columns.Add("Name", "Name");
            dgvMaterialList.Columns.Add("R", "R");
            dgvMaterialList.Columns.Add("G", "G");
            dgvMaterialList.Columns.Add("B", "B");
        }
        private void setDisplayOrderColumns()
        {
            dgvMaterialList.Columns["Colour1"].DisplayIndex = 0;
            dgvMaterialList.Columns["Name"].DisplayIndex = 1;
            dgvMaterialList.Columns["R"].DisplayIndex = 2;
            dgvMaterialList.Columns["G"].DisplayIndex = 3;
            dgvMaterialList.Columns["B"].DisplayIndex = 4;
            dgvMaterialList.Columns["Rename"].DisplayIndex = 5;
            dgvMaterialList.Columns["Delete"].DisplayIndex = 6;
        }
        private void setWidthColumns()
        {
            dgvMaterialList.Columns["Colour1"].Width = 30;
            dgvMaterialList.Columns["R"].Width = 20;
            dgvMaterialList.Columns["G"].Width = 20;
            dgvMaterialList.Columns["B"].Width = 20;
        }
    }
}
