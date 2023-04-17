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
        ClientLogic _clientLogic = new ClientLogic();
        public Panel_AddClient(Form1 form1)
        {
            _formPrincipal = form1;
            InitializeComponent();
            lblNewNameException.Visible = false;
            lblNewPasswordException.Visible = false;
            lblNewConfirmPasswordException.Visible = false;
        }

        private void btnAddNewClient_Click(object sender, EventArgs e)
        {
            lblNewNameException.Visible = false;
            lblNewPasswordException.Visible = false;
            lblNewConfirmPasswordException.Visible = false;
            if(txbNewClientPassword.Text == txbNewClientRepeatPassword.Text)
            {
                try
                {
                    Client newClient = new Client()
                    {
                        Name = txbNewClientName.Text,
                        Password = txbNewClientPassword.Text
                    };
                    _clientLogic.AddClient(newClient);
                    refreshAddClient();
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
            }
            else
            {
                lblNewConfirmPasswordException.Visible = true;
                lblNewConfirmPasswordException.Text = "Password does not match";
            }
                
        }
            
        

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            refreshAddClient();
            _formPrincipal.GoBackToWelcome();

        }
        private void refreshAddClient()
        {
            txbNewClientName.Clear();
            txbNewClientPassword.Clear();
            txbNewClientRepeatPassword.Clear();
            lblNewNameException.Visible = false;
            lblNewPasswordException.Visible = false;
            lblNewConfirmPasswordException.Visible = false;
        }
    }
}
