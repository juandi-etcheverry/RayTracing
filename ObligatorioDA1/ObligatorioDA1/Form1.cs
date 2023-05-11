using System;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;

namespace ObligatorioDA1
{
    public partial class Form1 : Form
    {
        private readonly ClientLogic _clientLogic = new ClientLogic();
        private readonly Panel_AddClient userControlAddClient;
        private readonly Panel_General userControlGeneral;


        public Form1()
        {
            InitializeComponent();
            userControlAddClient = new Panel_AddClient(this);
            userControlGeneral = new Panel_General(this);
            GoBackToWelcome();
            flyPanelPrincipal.Dock = DockStyle.Fill;
        }

        public void GoBackToWelcome()
        {
            RefreshWelcome();
            flyPanelPrincipal.Controls.Clear();
            flyPanelPrincipal.Visible = false;
        }

        public void SignOut()
        {
            _clientLogic.Logout();
            GoBackToWelcome();
        }

        public void GoToGeneral(Client client)
        {
            flyPanelPrincipal.Controls.Clear();
            flyPanelPrincipal.Visible = true;
            userControlGeneral.RefreshGeneralPanel(client);
            flyPanelPrincipal.Controls.Add(userControlGeneral);
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            flyPanelPrincipal.Visible = true;
            flyPanelPrincipal.Controls.Add(userControlAddClient);
            userControlAddClient.RefreshAddClient();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            lblNameException.Visible = false;
            lblPasswordException.Visible = false;
            try
            {
                var client = _clientLogic.GetClient(txbUserName.Text);
                _clientLogic.ThrowIfIncorrectPassword(txbPassword.Text);
                _clientLogic.InitializeSession(client);
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
                lblPasswordException.Text = sessEx.Message;
                lblPasswordException.Visible = true;
            }
            catch (NameException nameEx)
            {
                lblNameException.Text = nameEx.Message;
                lblNameException.Visible = true;
            }
        }

        private void RefreshWelcome()
        {
            txbPassword.Clear();
            txbUserName.Clear();
            lblNameException.Visible = false;
            lblPasswordException.Visible = false;
        }
    }
}