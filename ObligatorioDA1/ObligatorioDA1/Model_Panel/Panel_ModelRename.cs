using System;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;

namespace ObligatorioDA1.Model_Panel
{
    public partial class Panel_ModelRename : UserControl
    {
        private readonly ModelLogic _modelLogic = new ModelLogic();
        private readonly Panel_General _panelGeneral;
        private Model _model;

        public Panel_ModelRename(Panel_General panelGeneral)
        {
            _panelGeneral = panelGeneral;
            InitializeComponent();
        }

        public void RefreshModelRename(Model model)
        {
            _model = model;
            RefreshPage();
        }

        private void RefreshPage()
        {
            lblRenameException.Visible = false;
            txbModelRename.Clear();
        }

        private void btnConfirmRename_Click(object sender, EventArgs e)
        {
            try
            {
                _modelLogic.Rename(_model, txbModelRename.Text);
                _panelGeneral.GoToModelList();
            }
            catch (NameException nameEx)
            {
                lblRenameException.Visible = true;
                lblRenameException.Text = nameEx.Message;
            }
        }

        private void btnReturnRename_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToModelList();
        }
    }
}