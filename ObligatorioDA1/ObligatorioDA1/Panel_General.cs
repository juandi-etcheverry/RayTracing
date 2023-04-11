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
    public partial class Panel_General : UserControl
    {
        private Form1 _formPrincipal;
        public Panel_General(Form1 form1)
        {
            _formPrincipal = form1;
            InitializeComponent();
            
        }

        private void btnShapes_Click(object sender, EventArgs e)
        {
            //flyGeneral.Controls.Clear();

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            _formPrincipal.SignOut();
        }
    }
}
