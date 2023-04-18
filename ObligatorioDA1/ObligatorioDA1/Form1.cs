using BusinessLogic;
using BusinessLogicExceptions;
using Domain;
using RepositoryInMemory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObligatorioDA1
{
    public partial class Form1 : Form
    {
        private UserControl userControlWelcome;
        private UserControl userControlAddClient;
        private Panel_General userControlGeneral;
        ClientLogic _clientLogic = new ClientLogic();


        public Form1()
        {
            InitializeComponent();
            userControlWelcome = new Panel_Welcome();
            userControlAddClient = new Panel_AddClient(this);
            userControlGeneral = new Panel_General(this);
            GoBackToWelcome();
            flyPanelPrincipal.Dock = DockStyle.Fill;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            flyPanelPrincipal.Visible = true;
            flyPanelPrincipal.Controls.Add(userControlAddClient);
            refreshWelcome();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            lblNameException.Visible = false;
            lblPasswordException.Visible = false;
            try
            {
                Client newClient = new Client()
                {
                    Name = txbUserName.Text,
                    Password = txbPassword.Text
                };
                _clientLogic.InitializeSession(newClient);
                GoToGeneral(_clientLogic.GetLoggedClient());
            } 
            catch (NotFoundException notEx)
            {
                lblNameException.Text = notEx.Message;
                lblNameException.Visible = true;
            }
            catch (PasswordException passwordEx)
            {
                lblPasswordException.Text = passwordEx.Message;
                lblPasswordException.Visible = true;
            }
            catch (SessionException sessEx)
            {
                lblNameException.Text = sessEx.Message;
                lblNameException.Visible = true;
            }
            catch (NameException nameEx)
            {
                lblNameException.Text = nameEx.Message;
                lblNameException.Visible = true;
            }
        }

        public void GoBackToWelcome()
        {
            refreshWelcome();
            flyPanelPrincipal.Controls.Clear();
            flyPanelPrincipal.Visible = false;
            lblNameException.Visible = false;
            lblPasswordException.Visible = false;
        }
        public void SignOut()
        {
            _clientLogic.Logout();
            refreshWelcome();
            flyPanelPrincipal.Controls.Clear();
            flyPanelPrincipal.Visible = false;
        }
        public void GoToGeneral(Client client)
        {
            flyPanelPrincipal.Controls.Clear();
            flyPanelPrincipal.Visible = true;
            userControlGeneral.refreshGeneralPanel(client);
            flyPanelPrincipal.Controls.Add(userControlGeneral);
        }
        private void refreshWelcome()
        {
            txbPassword.Clear();
            txbUserName.Clear();
            lblNameException.Visible = false;
            lblPasswordException.Visible = false;
        }
    }
    

}
