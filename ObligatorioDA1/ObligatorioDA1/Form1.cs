using BusinessLogic;
using RepositoryInMemory;
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
        private UserControl userControlGeneral;
        
        public Form1()
        {
            InitializeComponent();
            userControlWelcome = new Panel_Welcome();
            userControlGeneral = new Panel_General(this);
            userControlAddClient = new Panel_AddClient(this);

            flyPanelPrincipal.Controls.Clear();
            flyPanelPrincipal.Visible = false;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            flyPanelPrincipal.Visible = true;
            flyPanelPrincipal.Controls.Add(userControlAddClient);
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            //Sign in validation
            GoToGeneral();
        }

        public void GoBackToWelcome()
        {
            flyPanelPrincipal.Controls.Clear();
            flyPanelPrincipal.Visible = false;
        }
        public void SignOut()
        {
            flyPanelPrincipal.Controls.Clear();
            flyPanelPrincipal.Visible = false;
        }
        public void GoToGeneral()
        {
            flyPanelPrincipal.Controls.Clear();
            flyPanelPrincipal.Visible = true;
            flyPanelPrincipal.Controls.Add(userControlGeneral);
        }
    }

}
