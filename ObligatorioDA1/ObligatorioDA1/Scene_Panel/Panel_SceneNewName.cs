using BusinessLogic;
using BusinessLogicExceptions;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObligatorioDA1.Model_Panel
{
    public partial class Panel_SceneNewName : UserControl
    {
        private Scene _newScene;
        private SceneLogic _sceneLogic = new SceneLogic();
        private Panel_General _panelGeneral;
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
            lblSceneNameException.Visible = false;
            txbSceneName.Clear();
        }

        private void btnReturnSceneName_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToSceneList();
        }

        private void btnConfirmSceneName_Click(object sender, EventArgs e)
        {
            try
            {
                _newScene.Name = txbSceneName.Text;
                _sceneLogic.Add(_newScene);
                _panelGeneral.goToSceneEditor();
            }
            catch (NameException nameEx)
            {
                lblSceneNameException.Visible = true;
                lblSceneNameException.Text = nameEx.Message;
            }
        }

        private void txbSceneName_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _newScene.Name = txbSceneName.Text;
            }
            catch (NameException nameEx)
            {
                lblSceneNameException.Visible = true;
                lblSceneNameException.Text = nameEx.Message;
            }
        }
    }
}
