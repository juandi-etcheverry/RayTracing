using System;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;

namespace ObligatorioDA1.Material_Panel
{
    public partial class Panel_MaterialRename : UserControl
    {
        private Material _material;
        private readonly MaterialLogic _materialLogic = new MaterialLogic();
        private readonly Panel_General _panelGeneral;

        public Panel_MaterialRename(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
        }

        public void RefreshMaterialRename(Material material)
        {
            _material = material;
            RefreshPage();
        }

        private void RefreshPage()
        {
            lblRenameException.Visible = false;
            txbMaterialRename.Clear();
        }

        private void btnReturnRename_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToMaterialList();
        }

        private void btnConfirmRename_Click(object sender, EventArgs e)
        {
            try
            {
                _materialLogic.Rename(_material, txbMaterialRename.Text);
                _panelGeneral.GoToMaterialList();
            }
            catch (NameException nameEx)
            {
                lblRenameException.Visible = true;
                lblRenameException.Text = nameEx.Message;
            }
        }
    }
}