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
    public partial class Form1 : Form
    {
        private UserControl userControlWelcome;
        private UserControl userControlAddClient;

        public Form1()
        {
            InitializeComponent();
            userControlWelcome = new Panel_Welcome();
            userControlAddClient = new Panel_AddClient();

            flyPanelPrincipal.Controls.Add(userControlWelcome);
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            flyPanelPrincipal.Controls.Clear();
            flyPanelPrincipal.Controls.Add(userControlAddClient);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            flyPanelPrincipal.Controls.Clear();
            flyPanelPrincipal.Controls.Add(userControlWelcome);

        }
    }
}
