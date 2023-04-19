using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObligatorioDA1.Material_Panel
{
    public partial class Panel_MaterialRename : UserControl
    {
        private Panel_General _panelGeneral;
        public Panel_MaterialRename(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
        }

        private void btnReturnRename_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToMaterialList();
        }

        private void btnConfirmRename_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToMaterialList();
        }
    }
}
