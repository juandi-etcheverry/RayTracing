using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic;
using Domain;
using ImageController;

namespace ObligatorioDA1
{
    public partial class Panel_SceneEditor : UserControl
    {
        private readonly ModelLogic _modelLogic = new ModelLogic();
        private readonly Panel_General _panelGeneral;
        private readonly SceneLogic _sceneLogic = new SceneLogic();
        private Scene _scene;
        private bool editedFirstTime;

        public Panel_SceneEditor(Panel_General panelGeneral)
        {
            _panelGeneral = panelGeneral;
            InitializeComponent();
            InitializeAvailableList();
            InitializeUsedList();
            lblLastRenderedDate.Visible = false;
            lblOutdatedImage.Visible = false;
        }

        public void RefreshSceneEditor(Scene scene)
        {
            _scene = _sceneLogic.GetScene(scene.Id);
            InitializePage();
        }

        private void InitializePage()
        {
            lblNewSceneName.Text = _scene.SceneName;
            lblLookExceptions.Visible = false;
            lblFoVException.Visible = false;
            pnlBlur.Visible = false;
            chkboxBlur.Checked = false;
            pboxRenderedScene.Image = _scene.Preview;
            RefreshAvailableList();
            RefreshUsedList();
            RefreshLastModified();
            OutDatedRender();
            TryLoadPreview();
            RefreshLooks();
            ButtonExport();
        }

        private void TryLoadPreview()
        {
            PreviewController.LoadPreview(_scene);
            if (_scene.Preview is null)
            {
                lblNoFileFound.Text = "No scene render exists";
                lblNoFileFound.Visible = true;
            }
            else
            {
                pboxRenderedScene.Image = _scene.Preview;
            }
        }

        private void RefreshPage()
        {
            lblLookExceptions.Visible = false;
            lblFoVException.Visible = false;
            lblLensAperture.Visible = false;
            RefreshLastModified();
            TryLoadPreview();
            OutDatedRender();
            ButtonExport();
        }

        private void ButtonExport()
        {
            if (_scene.Preview != null) btnExport.Visible = true;
            else btnExport.Visible = false;
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
            dgvUsedModels.Columns.Add("Id", "Id");
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
            dgvUsedModels.Columns["Colour"].DisplayIndex = 0;
            dgvUsedModels.Columns["Preview"].DisplayIndex = 1;
            dgvUsedModels.Columns["Name"].DisplayIndex = 2;
            dgvUsedModels.Columns["Pos"].DisplayIndex = 3;
            dgvUsedModels.Columns["Delete"].DisplayIndex = 4;
            dgvUsedModels.Columns["Id"].DisplayIndex = 5;
            dgvUsedModels.Columns["Id"].Visible = false;
        }

        private void RefreshAvailableList()
        {
            dgvAvailableModelsList.Rows.Clear();
            foreach (var model in _modelLogic.GetClientModels().ToList())
            {
                if (model.WantPreview) PreviewController.LoadPreview(model);
                dgvAvailableModelsList.Rows.Add(model.Preview, null, model.ModelName, null);
            }
        }

        private void RefreshUsedList()
        {
            dgvUsedModels.Rows.Clear();
            _scene = _sceneLogic.GetScene(_scene.Id);
            foreach (var posModel in _scene.Models.ToList())
            {
                if (posModel.Model.WantPreview) PreviewController.LoadPreview(posModel.Model);
                dgvUsedModels.Rows.Add(posModel.Model.Preview, null, posModel.Model.ModelName, null,
                    posModel.GetCoordinates(), posModel.Id);
            }
        }

        private void dgvAvailableModelsList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
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

        private void dgvAvailableModelsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAvailableModelsList.Columns[e.ColumnIndex].Name == "Add")
            {
                var modelName = dgvAvailableModelsList.CurrentRow.Cells[2].Value.ToString();
                var model = _modelLogic.Get(modelName);
                _panelGeneral.GoToSceneAddModel(model, _scene);
                editedFirstTime = true;
                RefreshPage();
            }
        }

        private void dgvUsedModels_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
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

        private void dgvUsedModels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                if (dgvUsedModels.Columns[e.ColumnIndex].Name == "Delete")
                {
                    var idModel = int.Parse(dgvUsedModels.CurrentRow.Cells[5].Value.ToString());
                    _sceneLogic.DeletePositionedModel(idModel, _scene.Id);
                    dgvUsedModels.Rows.Remove(dgvUsedModels.CurrentRow);
                    _scene.LastModificationDate = DateTime.Now;
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
                Cursor.Current = Cursors.WaitCursor;
                if (chkboxBlur.Checked)
                {
                    decimal blur;
                    var validBlur = decimal.TryParse(txbBlur.Text, out blur) && blur >= 0;
                    if (!validBlur) throw new ArgumentException("Aperture must be > 0,0");
                    PreviewController.Render(_scene, blur);
                }
                else
                {
                    PreviewController.Render(_scene);
                }

                Cursor.Current = Cursors.Arrow;
                lblLastRenderedDate.Visible = true;
                lblRendered.Visible = true;
                lblNoFileFound.Visible = false;
                pboxRenderedScene.Image = _scene.Preview;
                RefreshPage();
            }
            catch (ArgumentOutOfRangeException outEx)
            {
                lblFoVException.Visible = true;
                lblFoVException.Text = outEx.Message;
            }
            catch (ArgumentException argEx)
            {
                if (argEx.Message == "Aperture must be > 0,0")
                {
                    lblLensAperture.Visible = true;
                    lblLensAperture.Text = argEx.Message;
                }
                else if (argEx.Message == "X, Y, Z must be numbers")
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
            var validX = decimal.TryParse(txbXLookFrom.Text, out x);
            var validY = decimal.TryParse(txbYLookFrom.Text, out y);
            var validZ = decimal.TryParse(txbZLookFrom.Text, out z);
            if (!validX || !validY || !validZ) throw new ArgumentException("X, Y, Z must be numbers > 0");
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

        private int SetFov()
        {
            int x;
            var validX = int.TryParse(txbFoV.Text, out x);
            if (!validX) throw new ArgumentException("FoV must be a positive number");
            return x;
        }

        private void OutDatedRender()
        {
            lblLastRenderedDate.Text = _scene.LastRenderDate.ToString();
            if (editedFirstTime) lblOutdatedImage.Visible = _scene.LastRenderDate < _scene.LastModificationDate;
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
            txbXLookFrom.Text = _scene.ClientScenePreferences.LookFromDefaultX.ToString();
            txbYLookFrom.Text = _scene.ClientScenePreferences.LookFromDefaultY.ToString();
            txbZLookFrom.Text = _scene.ClientScenePreferences.LookFromDefaultZ.ToString();
            txbXLookAt.Text = _scene.ClientScenePreferences.LookAtDefaultX.ToString();
            txbYLookAt.Text = _scene.ClientScenePreferences.LookAtDefaultY.ToString();
            txbZLookAt.Text = _scene.ClientScenePreferences.LookAtDefaultZ.ToString();
            txbFoV.Text = _scene.ClientScenePreferences.FoVDefault.ToString();
        }

        private void SetNewLooksOnRender(ValueTuple<decimal, decimal, decimal> tuple1,
            ValueTuple<decimal, decimal, decimal> tuple2, int fov)
        {
            _scene.ClientScenePreferences.SetLookFromDefault(tuple1);
            _scene.ClientScenePreferences.SetLookAtDefault(tuple2);
            _scene.ClientScenePreferences.FoVDefault = fov;
        }

        private void chkboxBlur_CheckedChanged(object sender, EventArgs e)
        {
            lblLensAperture.Visible = false;
            pnlBlur.Visible = chkboxBlur.Checked;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToExportScene(_scene);
        }
    }
}