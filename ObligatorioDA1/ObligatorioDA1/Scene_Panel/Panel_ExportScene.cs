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
    public partial class Panel_ExportScene : UserControl
    {
        private Scene _scene;
        private readonly Panel_General _panelGeneral;
        public Panel_ExportScene(Panel_General panelGeneral)
        {
            InitializeComponent();
            _panelGeneral = panelGeneral;
        }
        public void RefreshSceneExport(Scene newScene)
        {
            _scene = newScene;
            lblSceneName.Text = _scene.Name;
            rbtnPNG.Checked = true;
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToSceneEditor(_scene);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToSceneEditor(_scene);
        }
    }
}
