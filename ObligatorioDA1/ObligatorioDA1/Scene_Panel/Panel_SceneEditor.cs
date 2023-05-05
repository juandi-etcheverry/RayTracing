using BusinessLogic;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObligatorioDA1
{
    public partial class Panel_SceneEditor : UserControl
    {
        private SceneLogic _sceneLogic = new SceneLogic();
        private ModelLogic _modelLogic = new ModelLogic();
        private Scene _scene;
        Panel_General _panelGeneral;
        public Panel_SceneEditor(Panel_General panelGeneral)
        {
            _panelGeneral = panelGeneral;
            InitializeComponent();
            InitializeAvailableList();
            InitializeUsedList();
        }
        public void RefreshSceneEditor(Scene scene)
        {
            _scene = scene;
            RefreshPage();
        }
        private void RefreshPage()
        {
            lblNewSceneName.Text = _scene.Name;
            RefreshAvailableList();
            RefreshUsedList();
            RefreshLastModified();
        }

        private void btnReturnNewScene_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToSceneList();
        }
        private void InitializeAvailableList()
        {
            dgvAvailableModelsList.Columns.Add("Name", "Name");
            dgvAvailableModelsList.Columns.Add("Colour", " ");
            SetDisplayOrderColumnsAvailable();
            dgvAvailableModelsList.Columns["Colour"].Width = 5;
        }
        private void InitializeUsedList()
        {
            dgvUsedModels.Columns.Add("Name", "Name");
            dgvUsedModels.Columns.Add("Colour", " ");
            dgvUsedModels.Columns.Add("Pos", "Pos");
            SetDisplayOrderColumnsUsed();
            dgvUsedModels.Columns["Colour"].Width = 5;
        }
        private void SetDisplayOrderColumnsAvailable()
        {
            dgvAvailableModelsList.Columns["Colour"].DisplayIndex = 0;
            dgvAvailableModelsList.Columns["Img"].DisplayIndex = 1;
            dgvAvailableModelsList.Columns["Name"].DisplayIndex = 2;
            dgvAvailableModelsList.Columns["Add"].DisplayIndex = 3;
        }
        private void SetDisplayOrderColumnsUsed()
        {
            dgvUsedModels.Columns["Colour"].DisplayIndex=0;
            dgvUsedModels.Columns["Preview"].DisplayIndex = 1;
            dgvUsedModels.Columns["Name"].DisplayIndex = 2;
            dgvUsedModels.Columns["Pos"].DisplayIndex = 3;
            dgvUsedModels.Columns["Delete"].DisplayIndex = 4;
        }
        private void RefreshAvailableList()
        {
            dgvAvailableModelsList.Rows.Clear();
            foreach (Model model in _modelLogic.GetClientModels().ToList())
            {
                dgvAvailableModelsList.Rows.Add(null, null, model.Name, null);
            }
        }
        private void RefreshUsedList()
        {
            dgvUsedModels.Rows.Clear();
            foreach (PositionedModel posModel in _scene.Models.ToList())
            {
                dgvUsedModels.Rows.Add(null, null, posModel.Name, null, posModel.Coordinates);
            }
        }

        private void dgvAvailableModelsList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (this.dgvAvailableModelsList.Columns[e.ColumnIndex].Name == "Colour")
                {
                    DataGridViewCell cell = this.dgvAvailableModelsList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    String modelName = dgvAvailableModelsList.Rows[e.RowIndex].Cells[2].Value.ToString();
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
                if (this.dgvAvailableModelsList.Columns[e.ColumnIndex].Name == "Img")
                {
                    DataGridViewCell cell = this.dgvAvailableModelsList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    String modelName = dgvAvailableModelsList.Rows[e.RowIndex].Cells[2].Value.ToString();
                    Model model = _modelLogic.Get(modelName);
                    if (model.WantPreview)
                    {
                        // Insert preview on cell
                    }
                }
            }
        }

        private void dgvAvailableModelsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvAvailableModelsList.Columns[e.ColumnIndex].Name == "Add")
            {
                String modelName = dgvAvailableModelsList.CurrentRow.Cells[2].Value.ToString();
                Model model = _modelLogic.Get(modelName);
                _panelGeneral.goToSceneAddModel(model, _scene);
            }
        }

        private void dgvUsedModels_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (this.dgvUsedModels.Columns[e.ColumnIndex].Name == "Colour")
                {
                    DataGridViewCell cell = this.dgvUsedModels.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    String modelName = dgvUsedModels.Rows[e.RowIndex].Cells[2].Value.ToString();
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
                if (this.dgvUsedModels.Columns[e.ColumnIndex].Name == "Img")
                {
                    DataGridViewCell cell = this.dgvUsedModels.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    String modelName = dgvUsedModels.Rows[e.RowIndex].Cells[2].Value.ToString();
                    Model model = _modelLogic.Get(modelName);
                    if (model.WantPreview)
                    {
                        // Insert preview on cell
                    }
                }
            }
        }
        private void dgvUsedModels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvUsedModels.Columns[e.ColumnIndex].Name == "Delete")
            {
                String modelName = dgvUsedModels.CurrentRow.Cells[2].Value.ToString();
                Model model = _modelLogic.Get(modelName);
                String pos = dgvUsedModels.CurrentRow.Cells[4].Value.ToString();
                string[] values = pos.Trim('(', ')').Split(',');
                decimal x = decimal.Parse(values[0]);
                decimal y = decimal.Parse(values[1]);
                decimal z = decimal.Parse(values[2]);
                var tuple = ValueTuple.Create(x, y, z);
                _scene.DeletePositionedModel(modelName, tuple);
                //dgvUsedModels.Rows.Remove(dgvUsedModels.CurrentRow);
                RefreshPage();
            }
        }
        private void RefreshLastModified()
        {
            lblDateLastModified.Text = _scene.LastModificationDate.ToString();
        }
    }
}
