using System;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;

namespace ObligatorioDA1.Model_Panel
{
    public partial class Panel_SceneNewName : UserControl
    {
        private readonly Panel_General _panelGeneral;
        private readonly SceneLogic _sceneLogic = new SceneLogic();
        private Scene _newScene;

        public Panel_SceneNewName(Panel_General panelGeneral)
        {
            _panelGeneral = panelGeneral;
            InitializeComponent();
        }

        public void RefreshSceneNewName()
        {
            _newScene = new Scene();
            RefreshPage();
        }

        public void RefreshPage()
        {
            txbSceneName.Clear();
            lblSceneNameException.Visible = false;
        }

        private void btnReturnSceneName_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToSceneList();
        }

        private void btnConfirmSceneName_Click(object sender, EventArgs e)
        {
            try
            {
                _newScene.SceneName = txbSceneName.Text;
                _sceneLogic.Add(_newScene);
                _panelGeneral.GoToSceneEditor(_newScene);
            }
            catch (NameException nameEx)
            {
                lblSceneNameException.Visible = true;
                lblSceneNameException.Text = nameEx.Message;
            }
        }

        private void txbSceneName_TextChanged(object sender, EventArgs e)
        {
            lblSceneNameException.Visible = false;
            try
            {
                _newScene.SceneName = txbSceneName.Text;
            }
            catch (NameException nameEx)
            {
                lblSceneNameException.Visible = true;
                lblSceneNameException.Text = nameEx.Message;
            }
        }
    }
}