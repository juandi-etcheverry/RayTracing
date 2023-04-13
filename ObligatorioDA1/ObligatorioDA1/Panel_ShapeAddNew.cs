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
    public partial class Panel_ShapeAddNew : UserControl
    {
        private Panel_General _panelGeneral;
        public Panel_ShapeAddNew(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
            lblNewShapeNameException.Visible = false;
            lblNewShapeRadiusException.Visible = false;
        }

        private void btnShowAllShapes_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToShapeList();
        }

        private void btnNewShape_Click(object sender, EventArgs e)
        {
            //Add new shape
            _panelGeneral.goToShapeList();
        }
    }
}
