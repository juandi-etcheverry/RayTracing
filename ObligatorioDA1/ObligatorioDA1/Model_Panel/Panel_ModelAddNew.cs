using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;
using GraphicsEngine;

namespace ObligatorioDA1.Model_Panel
{
    public partial class Panel_ModelAddNew : UserControl
    {
        private readonly MaterialLogic _materialLogic = new MaterialLogic();
        private readonly ModelLogic _modelLogic = new ModelLogic();
        private Model _newModel;
        private readonly Panel_General _panelGeneral;
        private readonly ShapeLogic _shapeLogic = new ShapeLogic();
        private readonly SceneLogic _sceneLogic = new SceneLogic();

        public Panel_ModelAddNew(Panel_General panelGeneral)
        {
            _panelGeneral = panelGeneral;
            InitializeComponent();
        }

        public void RefreshModelAddNew()
        {
            _newModel = new Model();
            RefreshPage();
        }

        private void btnShowAllModels_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToModelList();
        }

        private void btnNewModel_Click(object sender, EventArgs e)
        {
            lblModelSelectShape.Visible = false;
            lblNewModelNameException.Visible = false;
            try
            {
                if (cmbNewModelMaterial.SelectedItem == null)
                    throw new ArgumentException("Must select a material");
                if (cmbNewModelShape.SelectedItem == null)
                    throw new ArgumentException("Must select a shape");
                _newModel.ModelName = txbNewModelName.Text;
                _newModel.Material = _materialLogic.Get(cmbNewModelMaterial.SelectedItem.ToString());
                _newModel.Shape = _shapeLogic.GetShape(cmbNewModelShape.SelectedItem.ToString());
                _newModel.WantPreview = ckbModelPreview.Checked;
                _modelLogic.Add(_newModel);

                if (_newModel.WantPreview) SetPreviewForNewModel(_newModel);

                _panelGeneral.GoToModelList();
            }
            catch (NameException nameEx)
            {
                lblNewModelNameException.Visible = true;
                lblNewModelNameException.Text = nameEx.Message;
            }
            catch (ArgumentException argEx)
            {
                if (argEx.Message == "Must select a material")
                {
                    lblModelSelectMaterial.Visible = true;
                    lblModelSelectMaterial.Text = argEx.Message;
                }
                else
                {
                    lblModelSelectShape.Visible = true;
                    lblModelSelectShape.Text = argEx.Message;
                }
            }
        }

        private void SetPreviewForNewModel(Model model)
        {
            ClientLogic clientLogic = new ClientLogic();
            Client loggedInClient = clientLogic.GetLoggedClient();
            Scene previewScene = new Scene()
            {
                LastRenderDate = DateTime.Now,
                SceneName = "Preview - " + model.ModelName,
            };
            previewScene.ClientScenePreferences = loggedInClient.ClientScenePreferences;
            Scene addedScene = _sceneLogic.Add(previewScene);

            _sceneLogic.AddPositionedModel(model, (0, 2, 10), addedScene.Id);
            Scene updatedScene = _sceneLogic.GetScene(addedScene.Id);
            updatedScene.LastRenderDate = DateTime.Now;
            string modelFileName = $"{model.Id}.ppm";
            GraphicsEngine.GraphicsEngine engine = new GraphicsEngine.GraphicsEngine(updatedScene)
            {
                Width = 30
            };
            Cursor.Current = Cursors.WaitCursor;
            PPMImage renderedPreview = engine.Render();
            renderedPreview.SaveFile(modelFileName);
            Bitmap preview = ImageParser.ConvertPpmToBitmap(modelFileName);
            model.Preview = preview;
            Cursor.Current = Cursors.Arrow;
            _sceneLogic.RemoveScene(updatedScene);
        }

        private void RefreshShapeCombo()
        {
            cmbNewModelShape.Items.Clear();
            foreach (var s in _shapeLogic.GetClientShapes())
                cmbNewModelShape.Items.Add(s.ShapeName);
            cmbNewModelShape.Text = "";
        }

        private void RefreshMaterialCombo()
        {
            cmbNewModelMaterial.Items.Clear();
            foreach (var m in _materialLogic.GetClientMaterials())
                cmbNewModelMaterial.Items.Add(m.MaterialName);
            cmbNewModelMaterial.Text = "";
        }

        private void RefreshPage()
        {
            txbNewModelName.Clear();
            lblNewModelNameException.Visible = false;
            lblModelSelectShape.Visible = false;
            lblModelSelectMaterial.Visible = false;
            ckbModelPreview.Checked = false;
            RefreshShapeCombo();
            RefreshMaterialCombo();
        }

        private void txbNewModelName_TextChanged(object sender, EventArgs e)
        {
            lblNewModelNameException.Visible = false;
            try
            {
                _newModel.ModelName = txbNewModelName.Text;
            }
            catch (NameException nameEx)
            {
                lblNewModelNameException.Visible = true;
                lblNewModelNameException.Text = nameEx.Message;
            }
        }
    }
}