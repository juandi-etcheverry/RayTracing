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
        private ShapeLogic _shapeLogic = new ShapeLogic();
        private Panel_General _panelGeneral;
        private Shape _shape;
        public Panel_ShapeRename(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
        }
        public void RefreshShapeRename(Shape shape)
        {
            _shape = shape;
            RefreshPage();
        }
        private void RefreshPage()
        {
            lblRenameException.Visible = false;
            txbShapeRename.Clear();
        }
        private void btnConfirmRename_Click(object sender, EventArgs e)
        {
            try
            {
                _shapeLogic.RenameShape(_shape, txbShapeRename.Text);
                _panelGeneral.GoToShapeList();
            }
            catch (NameException nameEx)
            {
                lblRenameException.Visible = true;
                lblRenameException.Text = nameEx.Message;
            }
        }
        private void btnReturnRename_Click_1(object sender, EventArgs e)
        {
            _panelGeneral.GoToShapeList();
        }
    }
}
