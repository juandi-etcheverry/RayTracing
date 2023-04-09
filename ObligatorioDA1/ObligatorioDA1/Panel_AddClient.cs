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
        
        public Panel_AddClient()
        {
            InitializeComponent();
        }

        private void btnAddNewClient_Click(object sender, EventArgs e)
        {
            try
            {
                Client newClient = new Client()
                {
                    Name = txbClientName.Text,
                    Password = txbClientPassword.Text,
                };
            }
            catch (NameException nameEx)
            {
                System.Windows.Forms.MessageBox.Show(nameEx.Message);
            }
            catch(PasswordException passEx)
            {
                System.Windows.Forms.MessageBox.Show(passEx.Message);
            }
            
        }
    }
}
