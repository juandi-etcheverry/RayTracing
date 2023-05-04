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

namespace ObligatorioDA1.Model_Panel
{
    public partial class Panel_ModelRename : UserControl
    {
        private Model _model;
        private ModelLogic _modelLogic = new ModelLogic();
        private Panel_General _panelGeneral;
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
        private void btnConfirmRename_Click(object sender, EventArgs e)
        {
            try
            {
                _modelLogic.Rename(_model, txbModelRename.Text);
                _panelGeneral.goToModelList();
            }
            catch (NameException nameEx)
            {
                lblRenameException.Visible = true;
                lblRenameException.Text = nameEx.Message;
            }
        }

        private void btnReturnRename_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToModelList();
        }
        private void RefreshPage()
        {
            lblRenameException.Visible = false;
            txbModelRename.Clear();
        }
    }
}
