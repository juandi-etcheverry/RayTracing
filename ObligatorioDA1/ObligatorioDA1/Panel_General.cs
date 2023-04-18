using BusinessLogic;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObligatorioDA1
{
    public partial class Panel_General : UserControl
    {
        private Panel_ShapeList userControlShapeList;
        private Panel_ShapeAddNew userControlShapeAddNew;
        private Panel_ShapeRename userControlShapeRename;
        private Form1 _formPrincipal;
        private Client client = new Client(); 
        
        public Panel_General(Form1 form1)
        {
            _formPrincipal = form1;
            InitializeComponent();
            userControlShapeList = new Panel_ShapeList(this);
            userControlShapeAddNew = new Panel_ShapeAddNew(this);
            userControlShapeRename = new Panel_ShapeRename(this);
            flyGeneral.Controls.Clear();
            refreshGeneralPanel(client);
        }
        private void btnShapes_Click(object sender, EventArgs e)
        {
            goToShapeList();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            flyGeneral.Controls.Clear();
            _formPrincipal.SignOut();
        }
        public void goToAddNewShape()
        {
            flyGeneral.Controls.Clear();
            flyGeneral.Controls.Add(userControlShapeAddNew);
            userControlShapeAddNew.refreshShapeAddNew(client);
        }
        public void goToShapeList()
        {
            flyGeneral.Controls.Clear();
            flyGeneral.Controls.Add(userControlShapeList);
            userControlShapeList.refreshShapeList(client);
        }
        public void goToShapeRename(Shape shape)
        {
            flyGeneral.Controls.Clear();
            flyGeneral.Controls.Add(userControlShapeRename);
            userControlShapeRename.refreshShapeRename(shape);
        }
        public void refreshGeneralPanel(Client _client)
        {
           this.client = _client;
           lblUsername.Text = _client.Name;
        }
    }
}
