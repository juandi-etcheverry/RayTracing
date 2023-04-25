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
                dgvModelList.Rows.Add(null, null, null, model.Name, model.Shape.Name, model.Material.Name);
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
            dgvModelList.Columns.Add("Name", "Name");
            dgvModelList.Columns.Add("Shape", "Shape");
            dgvModelList.Columns.Add("Material", "Material");
        }
        private void SetDisplayOrderColumns()
        {
            dgvModelList.Columns["Preview"].DisplayIndex = 0;
            dgvModelList.Columns["Name"].DisplayIndex = 1;
            dgvModelList.Columns["Shape"].DisplayIndex = 2;
            dgvModelList.Columns["Material"].DisplayIndex = 3;
            dgvModelList.Columns["Rename"].DisplayIndex = 4;
            dgvModelList.Columns["Delete"].DisplayIndex = 5;
        }
        private void SetWidthColumns()
        {

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
            }
        }

        private void dgvModelList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String modelName = dgvModelList.CurrentRow.Cells[3].Value.ToString();
            Model model = _modelLogic.Get(modelName);
            if (this.dgvModelList.Columns[e.ColumnIndex].Name == "Delete")
            {
                _modelLogic.Remove(model);
                dgvModelList.Rows.Remove(dgvModelList.CurrentRow);
            }
            if (this.dgvModelList.Columns[e.ColumnIndex].Name == "Rename")
            {
                _panelGeneral.goToModelRename(model);
            }
        }
    }
}
