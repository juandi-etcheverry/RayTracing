using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic;
using Domain;
using GraphicsEngine;
using Color = System.Drawing.Color;

namespace ObligatorioDA1
{
    public partial class Panel_SceneEditor : UserControl
    {
        private readonly ModelLogic _modelLogic = new ModelLogic();
        private readonly Panel_General _panelGeneral;
        private Scene _scene;

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
            lblNewSceneName.Text = _scene.SceneName;
            lblLookExceptions.Visible = false;
            lblFoVException.Visible = false;
            lblFoVException.Visible = false;
            RefreshAvailableList();
            RefreshUsedList();
            RefreshLastModified();
            RecoverSceneRender();
            OutDatedRender();
            RefreshLooks();
        }

        private void btnReturnNewScene_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToSceneList();
        }

        private void InitializeAvailableList()
        {
            dgvAvailableModelsList.Columns.Add("MaterialName", "MaterialName");
            dgvAvailableModelsList.Columns.Add("Colour", " ");
            SetDisplayOrderColumnsAvailable();
            dgvAvailableModelsList.Columns["Colour"].Width = 5;
        }

        private void InitializeUsedList()
        {
            dgvUsedModels.Columns.Add("MaterialName", "MaterialName");
            dgvUsedModels.Columns.Add("Colour", " ");
            dgvUsedModels.Columns.Add("Pos", "Pos");
            SetDisplayOrderColumnsUsed();
            dgvUsedModels.Columns["Colour"].Width = 5;
        }

        private void SetDisplayOrderColumnsAvailable()
        {
            dgvAvailableModelsList.Columns["Colour"].DisplayIndex = 0;
            dgvAvailableModelsList.Columns["Img"].DisplayIndex = 1;
            dgvAvailableModelsList.Columns["MaterialName"].DisplayIndex = 2;
            dgvAvailableModelsList.Columns["Add"].DisplayIndex = 3;
        }

        private void SetDisplayOrderColumnsUsed()
        {
            dgvUsedModels.Columns["Colour"].DisplayIndex = 0;
            dgvUsedModels.Columns["Preview"].DisplayIndex = 1;
            dgvUsedModels.Columns["MaterialName"].DisplayIndex = 2;
            dgvUsedModels.Columns["Pos"].DisplayIndex = 3;
            dgvUsedModels.Columns["Delete"].DisplayIndex = 4;
        }

        private void RefreshAvailableList()
        {
            dgvAvailableModelsList.Rows.Clear();
            foreach (var model in _modelLogic.GetClientModels().ToList())
                dgvAvailableModelsList.Rows.Add(model.Preview, null, model.Name, null);
        }

        private void RefreshUsedList()
        {
            dgvUsedModels.Rows.Clear();
            foreach (var posModel in _scene.Models.ToList())
                dgvUsedModels.Rows.Add(posModel.Preview, null, posModel.Name, null, posModel.Coordinates);
        }

        private void dgvAvailableModelsList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dgvAvailableModelsList.Columns[e.ColumnIndex].Name == "Colour")
                {
                    var cell = dgvAvailableModelsList.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    var modelName = dgvAvailableModelsList.Rows[e.RowIndex].Cells[2].Value.ToString();
                    var model = _modelLogic.Get(modelName);
                    if (!model.WantPreview)
                    {
                        var newColor = GetColour(model);
                        PaintCell(cell, newColor);
                    }
                }
            }
        }

        private void dgvAvailableModelsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAvailableModelsList.Columns[e.ColumnIndex].Name == "Add")
            {
                var modelName = dgvAvailableModelsList.CurrentRow.Cells[2].Value.ToString();
                var model = _modelLogic.Get(modelName);
                _panelGeneral.GoToSceneAddModel(model, _scene);
            }
        }

        private void dgvUsedModels_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dgvUsedModels.Columns[e.ColumnIndex].Name == "Colour")
                {
                    var cell = dgvUsedModels.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    var modelName = dgvUsedModels.Rows[e.RowIndex].Cells[2].Value.ToString();
                    var model = _modelLogic.Get(modelName);
                    if (!model.WantPreview)
                    {
                        var newColor = GetColour(model);
                        PaintCell(cell, newColor);
                    }
                }
            }
        }

        private void dgvUsedModels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvUsedModels.Columns[e.ColumnIndex].Name == "Delete")
            {
                var modelName = dgvUsedModels.CurrentRow.Cells[2].Value.ToString();
                var pos = dgvUsedModels.CurrentRow.Cells[4].Value.ToString();
                var values = pos.Trim('(', ')').Split(',');
                var x = decimal.Parse(values[0]);
                var y = decimal.Parse(values[1]);
                var z = decimal.Parse(values[2]);
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
                var fov = SetFov();
                SetNewLooksOnRender(tupleLookFrom, tupleLookAt, fov);
                OutDatedRender();


                GraphicsEngine.GraphicsEngine engine = new GraphicsEngine.GraphicsEngine()
                {
                    Width = 300
                };


                Cursor.Current = Cursors.WaitCursor;
                PPMImage renderedImage = engine.Render(_scene);
                _scene.LastRenderDate = DateTime.Now;
                int sceneDateTime = ImageParser.HashDate(_scene.LastRenderDate);
                string sceneFileName = $"{_scene.OwnerName}_{sceneDateTime}.ppm";
                renderedImage.SaveFile(sceneFileName);
                RecoverSceneRender();
                Cursor.Current = Cursors.Arrow;
            }
            catch (ArgumentOutOfRangeException outEx)
            {
                lblFoVException.Visible = true;
                lblFoVException.Text = outEx.Message;
            }
            catch (ArgumentException argEx)
            {
                if (argEx.Message == "X, Y, Z must be numbers")
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

        private void RecoverSceneRender()
        {
            int sceneDateTime = ImageParser.HashDate(_scene.LastRenderDate);
            string sceneFileName = $"{_scene.OwnerName}_{sceneDateTime}.ppm";
            Bitmap renderedImage = RecoverSceneImage(sceneFileName);
            pboxRenderedScene.Image = renderedImage;
            _scene.Preview = renderedImage;
        }

        private Bitmap RecoverSceneImage(string filename)
        {
            try
            {
                Bitmap renderedImage = ImageParser.ConvertPpmToBitmap(filename);
                lblNoFileFound.Visible = false;
                return renderedImage;
            }
            catch (FileNotFoundException noFle)
            {
                lblNoFileFound.Text = "No scene render exists";
                lblNoFileFound.Visible = true;
                return null;
            }
        }

        private ValueTuple<decimal, decimal, decimal> SetLookfrom()
        {
            decimal x, y, z;
            var validX = decimal.TryParse(txbXLookFrom.Text, out x);
            var validY = decimal.TryParse(txbYLookFrom.Text, out y);
            var validZ = decimal.TryParse(txbZLookFrom.Text, out z);
            if (!validX || !validY || !validZ) throw new ArgumentException("X, Y, Z must be numbers");
            var tuple = ValueTuple.Create(x, y, z);
            return tuple;
        }

        private ValueTuple<decimal, decimal, decimal> SetLookAt()
        {
            decimal x, y, z;
            var validX = decimal.TryParse(txbXLookAt.Text, out x);
            var validY = decimal.TryParse(txbYLookAt.Text, out y);
            var validZ = decimal.TryParse(txbZLookAt.Text, out z);
            if (!validX || !validY || !validZ) throw new ArgumentException("X, Y, Z must be numbers");
            var tuple = ValueTuple.Create(x, y, z);
            return tuple;
        }

        private uint SetFov()
        {
            uint x;
            var validX = uint.TryParse(txbFoV.Text, out x);
            if (!validX) throw new ArgumentException("FoV must be a positive number");
            return x;
        }

        private void OutDatedRender()
        {
            lblLastRenderedDate.Text = _scene.LastRenderDate.ToString();
            lblOutdatedImage.Visible = _scene.LastRenderDate < _scene.LastModificationDate;
        }

        private Color GetColour(Model _model)
        {
            var r = (int)_model.Material.Color.Item1;
            var g = (int)_model.Material.Color.Item2;
            var b = (int)_model.Material.Color.Item3;
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

        private void SetNewLooksOnRender(ValueTuple<decimal, decimal, decimal> tuple1,
            ValueTuple<decimal, decimal, decimal> tuple2, uint fov)
        {
            _scene.ClientScenePreferences.LookFromDefault = tuple1;
            _scene.ClientScenePreferences.LookAtDefault = tuple2;
            _scene.ClientScenePreferences.FoVDefault = fov;
        }
    }
}