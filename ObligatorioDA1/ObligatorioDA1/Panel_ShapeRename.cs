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
    public partial class Panel_ShapeRename : UserControl
    {
        private Panel_General _panelGeneral;
        public Panel_ShapeRename(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
            lblRenameException.Visible = false;
        }

        private void btnConfirmRename_Click(object sender, EventArgs e)
        {
            //Rename
            _panelGeneral.goToShapeList();
        }

        private void btnReturnRename_Click_1(object sender, EventArgs e)
        {
            _panelGeneral.goToShapeList();
        }
    }
}
