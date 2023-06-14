using System;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;

namespace ObligatorioDA1.Scene_Panel
{
    public partial class Panel_SceneRename : UserControl
    {
        private readonly Panel_General _panelGeneral;
        private readonly SceneLogic _sceneLogic = new SceneLogic();
        private Scene _scene;

        public Panel_SceneRename(Panel_General panelGeneral)
        {
            _panelGeneral = panelGeneral;
            InitializeComponent();
        }

        public void RefreshSceneRename(Scene scene)
        {
            _scene = scene;
            RefreshPage();
        }

        private void RefreshPage()
        {
            lblSceneRenameException.Visible = false;
            txbRenameScene.Clear();
        }

        private void btnReturnRename_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToSceneList();
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            try
            {
                _sceneLogic.RenameScene(_scene, txbRenameScene.Text);
                _panelGeneral.GoToSceneList();
            }
            catch (NameException nameEx)
            {
                lblSceneRenameException.Visible = true;
                lblSceneRenameException.Text = nameEx.Message;
            }
        }
    }
}