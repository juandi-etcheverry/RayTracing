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

namespace ObligatorioDA1.Scene_Panel
{
    public partial class Panel_SceneRename : UserControl
    {
        private Scene _scene;
        private SceneLogic _sceneLogic = new SceneLogic();
        private Panel_General _panelGeneral;
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
