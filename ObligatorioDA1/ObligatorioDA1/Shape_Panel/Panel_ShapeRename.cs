using System;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;

namespace ObligatorioDA1
{
    public partial class Panel_ShapeRename : UserControl
    {
        private readonly Panel_General _panelGeneral;
        private Shape _shape;
        private readonly ShapeLogic _shapeLogic = new ShapeLogic();

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