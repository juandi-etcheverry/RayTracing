using BusinessLogic;
using Domain;
using ObligatorioDA1.Material_Panel;
using ObligatorioDA1.Model_Panel;
using ObligatorioDA1.Scene_Panel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObligatorioDA1
{
    public partial class Panel_General : UserControl
    {
        private Form1 _formPrincipal;
        private Client client = new Client();
        private Panel_ShapeList userControlShapeList;
        private Panel_ShapeAddNew userControlShapeAddNew;
        private Panel_ShapeRename userControlShapeRename;
        private Panel_MaterialList userControlMaterialList;
        private Panel_MaterialAddNew userControlMaterialAddNew;
        private Panel_MaterialRename userControlMaterialRename;
        private Panel_ModelList userControlModelList;
        private Panel_ModelAddNew userControlModelAddNew;
        private Panel_ModelRename userControlModelRename;
        private Panel_SceneList userControlSceneList;
        private Panel_SceneEditor userControlSceneEditor;
        private Panel_SceneRename userControlSceneRename;
        private Panel_SceneNewName userControlSceneNewName;
        private Panel_AddModelToScene userControlModelToScene;
        
        
        public Panel_General(Form1 form1)
        {
            _formPrincipal = form1;
            InitializeComponent();
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
            //userControlModelToScene = new Panel_AddModelToScene(this);
            flyGeneral.Controls.Clear();
            refreshGeneralPanel(client);
        }
        public void refreshGeneralPanel(Client _client)
        {
            this.client = _client;
            lblUsername.Text = _client.Name;
        }
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            flyGeneral.Controls.Clear();
            _formPrincipal.SignOut();
        }
        private void switchPanel(UserControl userControl)
        {
            flyGeneral.Controls.Clear();
            flyGeneral.Controls.Add(userControl);
        }
        private void btnShapes_Click(object sender, EventArgs e)
        {
            goToShapeList();
        }
        public void goToShapeList()
        {
            switchPanel(userControlShapeList);
            userControlShapeList.refreshShapeList(client);
        }
        public void goToAddNewShape()
        {
            switchPanel(userControlShapeAddNew);
            userControlShapeAddNew.refreshShapeAddNew(client);
        }
        public void goToShapeRename(Shape shape)
        {
            switchPanel(userControlShapeRename);
            userControlShapeRename.refreshShapeRename(shape);
        }
        private void btnMaterials_Click(object sender, EventArgs e)
        {
            goToMaterialList();
        }
        public void goToMaterialList()
        {
            switchPanel(userControlMaterialList);
           userControlMaterialList.refreshMaterialList(client);
        }
        public void goToAddNewMaterial()
        {
            switchPanel(userControlMaterialAddNew);
            userControlMaterialAddNew.refreshMaterialAddNew(client);
        }
        public void goToMaterialRename(Material material)
        {
            switchPanel(userControlMaterialRename);
            userControlMaterialRename.refreshMaterialRename(material);
        }

        private void btnModels_Click(object sender, EventArgs e)
        {
            goToModelList();
        }
        public void goToModelList()
        {
            switchPanel(userControlModelList);
            userControlModelList.RefreshModelList();
        }
        public void goToAddNewModel()
        {
            switchPanel(userControlModelAddNew);
            userControlModelAddNew.refreshModelAddNew();
        }
        public void goToModelRename(Model model)
        {
           switchPanel(userControlModelRename);
           userControlModelRename.RefreshModelRename(model);
        }
        private void btnScenes_Click(object sender, EventArgs e)
        {
            goToSceneList();
        }
        public void goToSceneList()
        {
            switchPanel(userControlSceneList);
            userControlSceneList.RefreshSceneList();
        }
        public void goToSceneEditor()
        {
            switchPanel(userControlSceneEditor);
        }
        public void goToNewSceneName()
        {
            switchPanel(userControlSceneNewName);
            userControlSceneNewName.RefreshSceneNewName();
        }
        public void goToSceneRename(Scene scene)
        {
            switchPanel(userControlSceneRename);
            userControlSceneRename.RefreshSceneRename(scene);
        }
        

    }
}
