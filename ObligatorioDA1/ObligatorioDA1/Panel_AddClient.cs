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
        private ClientLogic _clientLogic = new ClientLogic();
        private Client newClient;
        public Panel_AddClient(Form1 form1)
        {
            _formPrincipal = form1;
            InitializeComponent();
        }
        public void RefreshAddClient()
        {
            newClient = new Client();
            RefreshPage();
        }
        private void btnAddNewClient_Click(object sender, EventArgs e)
        {
            lblNewNameException.Visible = false;
            lblNewPasswordException.Visible = false;
            lblNewConfirmPasswordException.Visible = false;
                try
                {
                    newClient.Name = txbNewClientName.Text;
                    newClient.Password = txbNewClientPassword.Text;
                    if (txbNewClientPassword.Text != txbNewClientRepeatPassword.Text)
                        throw new ArgumentException("Password does not match");
                    _clientLogic.AddClient(newClient);
                    _clientLogic.InitializeSession(newClient);
                    _formPrincipal.GoToGeneral(newClient);
                }
                catch (NameException NameEx)
                {
                    lblNewNameException.Visible = true;
                    lblNewNameException.Text = NameEx.Message;
                }
                catch (PasswordException PassEx)
                {
                    lblNewPasswordException.Visible = true;
                    lblNewPasswordException.Text = PassEx.Message;
                }
                catch (ArgumentException ArgEx)
                {
                    lblNewConfirmPasswordException.Visible = true;
                    lblNewConfirmPasswordException.Text = ArgEx.Message;
                }
        }
            
        private void btnGoBack_Click(object sender, EventArgs e)
        {
            _formPrincipal.GoBackToWelcome();

        }
        private void txbNewClientName_TextChanged(object sender, EventArgs e)
        {
            lblNewNameException.Visible = false;
            try
            {
                newClient.Name = txbNewClientName.Text;
            }
            catch (NameException nameEx)
            {
                lblNewNameException.Visible = true;
                lblNewNameException.Text = nameEx.Message;
            }
            
        }
        private void txbNewClientPassword_TextChanged(object sender, EventArgs e)
        {
            lblNewPasswordException.Visible = false;
            try
            {
                newClient.Password = txbNewClientPassword.Text;
            }
            catch (PasswordException passEx)
            {
                lblNewPasswordException.Visible = true;
                lblNewPasswordException.Text = passEx.Message;
            }
        }
        private void RefreshPage()
        {
            lblNewNameException.Visible = false;
            lblNewPasswordException.Visible = false;
            lblNewConfirmPasswordException.Visible = false;
            txbNewClientName.Clear();
            txbNewClientPassword.Clear();
            txbNewClientRepeatPassword.Clear();
        }
    }
}
