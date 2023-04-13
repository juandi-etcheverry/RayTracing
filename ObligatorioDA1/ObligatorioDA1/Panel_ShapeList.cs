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
    public partial class Panel_ShapeList : UserControl
    {
        private Panel_General _panelGeneral;
        public Panel_ShapeList(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
        }

        private void btnAddShape_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToAddNewShape();
        }
    }
}
