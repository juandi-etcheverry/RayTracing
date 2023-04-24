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
    public partial class Panel_SceneList : UserControl
    {
        private Panel_General _panelGeneral;
        public Panel_SceneList(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
        }

        private void btnAddNewScene_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToNewSceneName();
        }
    }
}
