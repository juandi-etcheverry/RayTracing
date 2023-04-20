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
    public partial class Panel_ModelAddNew : UserControl
    {
        private Panel_General _panelGeneral;
        public Panel_ModelAddNew(Panel_General panelGeneral)
        {
            _panelGeneral = panelGeneral;
            InitializeComponent();
            
        }

        private void btnShowAllModels_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToModelList();
        }

        private void btnNewModel_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToModelList();
        }
    }
}
