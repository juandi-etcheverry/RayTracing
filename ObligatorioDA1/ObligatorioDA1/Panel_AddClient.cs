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
    public partial class Panel_AddClient : UserControl
    {
        private Form1 _formPrincipal;
        public Panel_AddClient(Form1 form1)
        {
            _formPrincipal = form1;
            InitializeComponent();
        }

        private void btnAddNewClient_Click(object sender, EventArgs e)
        {
            //flyPanelPrincipal.Controls.Clear();
            //flyPanelPrincipal.Controls.Add(UserControlGeneral);
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            _formPrincipal.GoBackToWelcome();

        }
    }
}
