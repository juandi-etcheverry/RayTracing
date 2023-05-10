using BusinessLogic;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
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
        private ModelLogic _modelLogic = new ModelLogic();
        private Scene _scene;
        private Panel_General _panelGeneral;
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
            lblLookExceptions.Visible = false;
            lblFoVException.Visible = false;
            RefreshAvailableList();
            RefreshUsedList();
            RefreshLastModified();
            OutDatedRender();
            RefreshLooks();
        }
        private void btnReturnNewScene_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToSceneList();
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
                        Color newColor = GetColour(model);
                        PaintCell(cell, newColor);
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
                _panelGeneral.GoToSceneAddModel(model, _scene);
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
                        Color newColor = GetColour(model);
                        PaintCell(cell, newColor);
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
                String pos = dgvUsedModels.CurrentRow.Cells[4].Value.ToString();
                string[] values = pos.Trim('(', ')').Split(',');
                decimal x = decimal.Parse(values[0]);
                decimal y = decimal.Parse(values[1]);
                decimal z = decimal.Parse(values[2]);
                var tuple = ValueTuple.Create(x, y, z);
                _scene.DeletePositionedModel(modelName, tuple);
                RefreshPage();
            }
        }
        private void RefreshLastModified()
        {
            lblDateLastModified.Text = _scene.LastModificationDate.ToString();
        }
        private void btnRender_Click(object sender, EventArgs e)
        {
            try
            {
                var tupleLookFrom = SetLookfrom();
                var tupleLookAt = SetLookAt();
                uint fov = SetFov();
                SetNewLooksOnRender(tupleLookFrom, tupleLookAt, fov);
                OutDatedRender();
                //Insert render
            }
            catch (ArgumentOutOfRangeException outEx)
            {
                lblFoVException.Visible = true;
                lblFoVException.Text = outEx.Message;
            }
            catch (ArgumentException argEx)
            {
                if(argEx.Message == "X, Y, Z must be numbers")
                {
                    lblLookExceptions.Visible = true;
                    lblLookExceptions.Text = argEx.Message;
                }
                else
                {
                    lblFoVException.Visible = true;
                    lblFoVException.Text = argEx.Message;
                }
            }
        }
        private ValueTuple<decimal, decimal, decimal> SetLookfrom()
        {
            decimal x, y, z;
            bool validX = decimal.TryParse(txbXLookFrom.Text, out x);
            bool validY = decimal.TryParse(txbYLookFrom.Text, out y);
            bool validZ = decimal.TryParse(txbZLookFrom.Text, out z);
            if (!validX || !validY || !validZ) throw new ArgumentException("X, Y, Z must be numbers");
            var tuple = ValueTuple.Create(x, y, z);
            return tuple;
        }
        private ValueTuple<decimal, decimal, decimal> SetLookAt()
        {
            decimal x, y, z;
            bool validX = decimal.TryParse(txbXLookAt.Text, out x);
            bool validY = decimal.TryParse(txbYLookAt.Text, out y);
            bool validZ = decimal.TryParse(txbZLookAt.Text, out z);
            if (!validX || !validY || !validZ) throw new ArgumentException("X, Y, Z must be numbers");
            var tuple = ValueTuple.Create(x, y, z);
            return tuple;
        }
        private uint SetFov()
        {
            uint x;
            bool validX = uint.TryParse(txbFoV.Text, out x);
            if (!validX) throw new ArgumentException("FoV must be a positive number");
            return x;
        }
        private void OutDatedRender()
        {
            lblLastRenderedDate.Text = _scene.LastRenderDate.ToString();
            lblOutdatedImage.Visible = (_scene.LastRenderDate < _scene.LastModificationDate);
        }
        private Color GetColour(Model _model)
        {
            int r = (int)_model.Material.Color.Item1;
            int g = (int)_model.Material.Color.Item2;
            int b = (int)_model.Material.Color.Item3;
            Color newColor = Color.FromArgb(r, g, b);
            return newColor;
        }
        private void PaintCell(DataGridViewCell cell, Color color)
        {
            cell.Style.BackColor = color;
            cell.Style.SelectionBackColor = color;
            cell.Style.ForeColor = color;
            cell.ReadOnly = true;
        }
        private void RefreshLooks()
        {
            ClearLooks();
            SetLooks();
        }
        private void ClearLooks()
        {
            txbXLookFrom.Clear();
            txbYLookFrom.Clear();
            txbZLookFrom.Clear();
            txbXLookAt.Clear();
            txbYLookAt.Clear();
            txbZLookAt.Clear();
            txbFoV.Clear();
        }
        private void SetLooks()
        {
            txbXLookFrom.Text = _scene.ClientScenePreferences.LookFromDefault.Item1.ToString();
            txbYLookFrom.Text = _scene.ClientScenePreferences.LookFromDefault.Item2.ToString();
            txbZLookFrom.Text = _scene.ClientScenePreferences.LookFromDefault.Item3.ToString();
            txbXLookAt.Text = _scene.ClientScenePreferences.LookAtDefault.Item1.ToString();
            txbYLookAt.Text = _scene.ClientScenePreferences.LookAtDefault.Item2.ToString();
            txbZLookAt.Text = _scene.ClientScenePreferences.LookAtDefault.Item3.ToString();
            txbFoV.Text = _scene.ClientScenePreferences.FoVDefault.ToString();
        }
        private void SetNewLooksOnRender(ValueTuple<decimal, decimal, decimal> tuple1, ValueTuple<decimal, decimal, decimal> tuple2, uint fov)
        {
            _scene.ClientScenePreferences.LookFromDefault = tuple1;
            _scene.ClientScenePreferences.LookAtDefault = tuple2;
            _scene.ClientScenePreferences.FoVDefault = fov;
        }
    }
}
