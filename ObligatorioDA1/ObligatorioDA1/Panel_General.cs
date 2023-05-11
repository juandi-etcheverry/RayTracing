using System;
using System.Windows.Forms;
using Domain;
using ObligatorioDA1.Material_Panel;
using ObligatorioDA1.Model_Panel;
using ObligatorioDA1.Scene_Panel;

namespace ObligatorioDA1
{
    public partial class Panel_General : UserControl
    {
        private readonly Form1 _formPrincipal;
        private Client client = new Client();
        private Panel_MaterialAddNew userControlMaterialAddNew;
        private Panel_MaterialList userControlMaterialList;
        private Panel_MaterialRename userControlMaterialRename;
        private Panel_ModelAddNew userControlModelAddNew;
        private Panel_ModelList userControlModelList;
        private Panel_ModelRename userControlModelRename;
        private Panel_AddModelToScene userControlModelToScene;
        private Panel_SceneEditor userControlSceneEditor;
        private Panel_SceneList userControlSceneList;
        private Panel_SceneNewName userControlSceneNewName;
        private Panel_SceneRename userControlSceneRename;
        private Panel_SceneSetDefaultCamera userControlSceneSetDefaultCamera;
        private Panel_ShapeAddNew userControlShapeAddNew;
        private Panel_ShapeList userControlShapeList;
        private Panel_ShapeRename userControlShapeRename;


        public Panel_General(Form1 form1)
        {
            _formPrincipal = form1;
            InitializeComponent();
            InitiallizePanels();
            flyGeneral.Controls.Clear();
            RefreshGeneralPanel(client);
        }

        public void RefreshGeneralPanel(Client _client)
        {
            client = _client;
            lblUsername.Text = _client.Name;
        }

        private void SwitchPanel(UserControl userControl)
        {
            flyGeneral.Controls.Clear();
            flyGeneral.Controls.Add(userControl);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            flyGeneral.Controls.Clear();
            _formPrincipal.SignOut();
        }

        private void btnShapes_Click(object sender, EventArgs e)
        {
            GoToShapeList();
        }

        public void GoToShapeList()
        {
            SwitchPanel(userControlShapeList);
            userControlShapeList.RefreshShapeList();
        }

        public void GoToAddNewShape()
        {
            SwitchPanel(userControlShapeAddNew);
            userControlShapeAddNew.RefreshShapeAddNew();
        }

        public void GoToShapeRename(Shape shape)
        {
            SwitchPanel(userControlShapeRename);
            userControlShapeRename.RefreshShapeRename(shape);
        }

        private void btnMaterials_Click(object sender, EventArgs e)
        {
            GoToMaterialList();
        }

        public void GoToMaterialList()
        {
            SwitchPanel(userControlMaterialList);
            userControlMaterialList.RefreshMaterialList();
        }

        public void GoToAddNewMaterial()
        {
            SwitchPanel(userControlMaterialAddNew);
            userControlMaterialAddNew.RefreshMaterialAddNew();
        }

        public void GoToMaterialRename(Material material)
        {
            SwitchPanel(userControlMaterialRename);
            userControlMaterialRename.RefreshMaterialRename(material);
        }

        private void btnModels_Click(object sender, EventArgs e)
        {
            GoToModelList();
        }

        public void GoToModelList()
        {
            SwitchPanel(userControlModelList);
            userControlModelList.RefreshModelList();
        }

        public void GoToAddNewModel()
        {
            SwitchPanel(userControlModelAddNew);
            userControlModelAddNew.RefreshModelAddNew();
        }

        public void GoToModelRename(Model model)
        {
            SwitchPanel(userControlModelRename);
            userControlModelRename.RefreshModelRename(model);
        }

        private void btnScenes_Click(object sender, EventArgs e)
        {
            GoToSceneList();
        }

        public void GoToSceneList()
        {
            SwitchPanel(userControlSceneList);
            userControlSceneList.RefreshSceneList();
        }

        public void GoToSceneEditor(Scene scene)
        {
            SwitchPanel(userControlSceneEditor);
            userControlSceneEditor.RefreshSceneEditor(scene);
        }

        public void GoToNewSceneName()
        {
            SwitchPanel(userControlSceneNewName);
            userControlSceneNewName.RefreshSceneNewName();
        }

        public void GoToSceneRename(Scene scene)
        {
            SwitchPanel(userControlSceneRename);
            userControlSceneRename.RefreshSceneRename(scene);
        }

        public void GoToSceneAddModel(Model model, Scene scene)
        {
            SwitchPanel(userControlModelToScene);
            userControlModelToScene.RefreshModelToScene(model, scene);
        }

        public void GoToSetCameraDefault()
        {
            SwitchPanel(userControlSceneSetDefaultCamera);
            userControlSceneSetDefaultCamera.RefreshSetDefaultCamera(client);
        }

        private void InitiallizePanels()
        {
            userControlShapeList = new Panel_ShapeList(this);
            userControlShapeAddNew = new Panel_ShapeAddNew(this);
            userControlShapeRename = new Panel_ShapeRename(this);
            userControlMaterialList = new Panel_MaterialList(this);
            userControlMaterialAddNew = new Panel_MaterialAddNew(this);
            userControlMaterialRename = new Panel_MaterialRename(this);
            userControlModelList = new Panel_ModelList(this);
            userControlModelAddNew = new Panel_ModelAddNew(this);
            userControlModelRename = new Panel_ModelRename(this);
            userControlSceneList = new Panel_SceneList(this);
            userControlSceneEditor = new Panel_SceneEditor(this);
            userControlSceneRename = new Panel_SceneRename(this);
            userControlSceneNewName = new Panel_SceneNewName(this);
            userControlModelToScene = new Panel_AddModelToScene(this);
            userControlSceneSetDefaultCamera = new Panel_SceneSetDefaultCamera(this);
        }
    }
}