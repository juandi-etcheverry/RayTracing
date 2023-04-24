using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObligatorioDA1
{
    public partial class Panel_SceneEditor : UserControl
    {
        Panel_General _panelGeneral;
        public Panel_SceneEditor(Panel_General panelGeneral)
        {
            _panelGeneral = panelGeneral;
            InitializeComponent();
            
        }

        private void btnReturnNewScene_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToSceneList();
        }
    }
}
