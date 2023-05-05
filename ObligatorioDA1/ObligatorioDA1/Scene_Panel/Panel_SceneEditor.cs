using BusinessLogic;
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
        private void SetDisplayOrderColumnsAvailable()
        {
            dgvAvailableModelsList.Columns["Colour"].DisplayIndex = 0;
            dgvAvailableModelsList.Columns["Img"].DisplayIndex = 1;
            dgvAvailableModelsList.Columns["Name"].DisplayIndex = 2;
            dgvAvailableModelsList.Columns["Add"].DisplayIndex = 3;
        }
        private void RefreshAvailableList()
        {
            dgvAvailableModelsList.Rows.Clear();
            foreach (Model model in _modelLogic.GetClientModels().ToList())
            {
                dgvAvailableModelsList.Rows.Add(null, null, model.Name, null);
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
    }
}
