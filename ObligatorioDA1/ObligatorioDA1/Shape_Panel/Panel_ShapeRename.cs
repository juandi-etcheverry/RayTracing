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

namespace ObligatorioDA1
{
    public partial class Panel_ShapeRename : UserControl
    {
        ShapeLogic shapeLogic = new ShapeLogic();
        private Panel_General _panelGeneral;
        private Shape _shape;
        public Panel_ShapeRename(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
            lblRenameException.Visible = false;
        }
        public void refreshShapeRename(Shape shape)
        {
            _shape = shape;
            lblRenameException.Visible = false;
            txbShapeRename.Clear();
        }

        private void btnConfirmRename_Click(object sender, EventArgs e)
        {
            try
            {
                shapeLogic.RenameShape(_shape, txbShapeRename.Text);
                refreshShapeRename(_shape);
                _panelGeneral.goToShapeList();
            }
            catch (NameException nameEx)
            {
                lblRenameException.Visible = true;
                lblRenameException.Text = nameEx.Message;
            }
            
        }

        private void btnReturnRename_Click_1(object sender, EventArgs e)
        {
            _panelGeneral.goToShapeList();
        }
    }
}
