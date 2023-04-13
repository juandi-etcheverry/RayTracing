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
    public partial class Panel_General : UserControl
    {
        private UserControl userControlShapeList;
        private UserControl userControlShapeAddNew;
        private UserControl userControlShapeRename;
        private Form1 _formPrincipal;
        public Panel_General(Form1 form1)
        {
            _formPrincipal = form1;
            InitializeComponent();
            userControlShapeList = new Panel_ShapeList(this);
            userControlShapeAddNew = new Panel_ShapeAddNew(this);
            userControlShapeRename = new Panel_ShapeRename(this);
            flyGeneral.Controls.Clear();

        }
        private void btnShapes_Click(object sender, EventArgs e)
        {
            goToShapeList();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            _formPrincipal.SignOut();
        }
        public void goToAddNewShape()
        {
            flyGeneral.Controls.Clear();
            flyGeneral.Controls.Add(userControlShapeAddNew);
        }
        public void goToShapeList()
        {
            flyGeneral.Controls.Clear();
            flyGeneral.Controls.Add(userControlShapeList);
        }
        public void goToShapeRename(String name)
        {
            flyGeneral.Controls.Clear();
            flyGeneral.Controls.Add(userControlShapeRename);
        }
    }
}
