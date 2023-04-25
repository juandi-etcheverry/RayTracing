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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObligatorioDA1
{
    public partial class Panel_ShapeAddNew : UserControl
    {
        Sphere newSphere;
        ShapeLogic _shapeLogic = new ShapeLogic();
        private Panel_General _panelGeneral;
        private Client _client;
        public Panel_ShapeAddNew(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
            refreshShapeAddNew(_client);
        }
        public void refreshShapeAddNew(Client client)
        {
            _client = client;
            newSphere = new Sphere();
            RefreshPanel();
        }

        private void btnShowAllShapes_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToShapeList();
        }

        private void btnNewShape_Click(object sender, EventArgs e)
        {
            lblNewShapeNameException.Visible = false;
            lblNewShapeRadiusException.Visible = false;
            try
            {
                double radius;
                bool validRadius = Double.TryParse(txbNewShapeRadius.Text, out radius);
                if (!validRadius) throw new ArgumentException("Radius must be a decimal number");
                newSphere.Name = txbNewShapeName.Text;
                newSphere.OwnerName = _client.Name;
                newSphere.Radius = radius;
                RefreshPanel();
                _shapeLogic.AddShape(newSphere);
                _panelGeneral.goToShapeList();
            }
            catch (NameException nameEx)
            {
                lblNewShapeNameException.Visible = true;
                lblNewShapeNameException.Text = nameEx.Message;
            }
            catch (ArgumentException radEx)
            {
                lblNewShapeRadiusException.Visible = true;
                lblNewShapeRadiusException.Text = radEx.Message;
            }
            catch (NonPositiveRadiusException negRadEx)
            {
                lblNewShapeRadiusException.Visible = true;
                lblNewShapeRadiusException.Text = negRadEx.Message;
            }
        }
        private void txbNewShapeName_TextChanged(object sender, EventArgs e)
        {
            lblNewShapeNameException.Visible = false;
            try
            {
                newSphere.Name = txbNewShapeName.Text;
            }
            catch (NameException nameEx)
            {
                lblNewShapeNameException.Visible = true;
                lblNewShapeNameException.Text = nameEx.Message;
            }
        }
        private void txbNewShapeRadius_TextChanged(object sender, EventArgs e)
        {
            lblNewShapeRadiusException.Visible = false;
            try
            {
                double radius;
                bool validRadius = Double.TryParse(txbNewShapeRadius.Text, out radius);
                if (!validRadius) throw new ArgumentException("Radius must be a decimal number");
                newSphere.Radius = radius;
            }
            catch (ArgumentException argEx)
            {
                lblNewShapeRadiusException.Visible = true;
                lblNewShapeRadiusException.Text = argEx.Message;
            }
            catch (NonPositiveRadiusException negRadEx)
            {
                lblNewShapeRadiusException.Visible = true;
                lblNewShapeRadiusException.Text = negRadEx.Message;
            }
        }
        private void RefreshPanel()
        {
            lblNewShapeNameException.Visible = false;
            lblNewShapeRadiusException.Visible = false;
            txbNewShapeName.Clear();
            txbNewShapeRadius.Clear();
        }
    }
}
