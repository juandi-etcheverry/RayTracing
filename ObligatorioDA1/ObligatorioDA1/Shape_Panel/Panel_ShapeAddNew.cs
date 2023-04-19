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
        ShapeLogic shapeLogic = new ShapeLogic();
        private Panel_General _panelGeneral;
        private Client _client;
        public Panel_ShapeAddNew(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
            lblNewShapeNameException.Visible = false;
            lblNewShapeRadiusException.Visible = false;
        }
        public void refreshShapeAddNew(Client client)
        {
            _client = client;
            lblNewShapeNameException.Visible = false;
            lblNewShapeRadiusException.Visible = false;
            txbNewShapeName.Clear();
            txbNewShapeRadius.Clear();
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
                bool validRadius = Double.TryParse(txbNewShapeRadius.Text,out radius);
                if (!validRadius) throw new ArgumentException("Radius must be a decimal number");
                Sphere newSphere = new Sphere()
                {
                    Name = txbNewShapeName.Text,
                    Radius = radius,
                    OwnerName = _client.Name
                };
                shapeLogic.AddShape(newSphere);
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
            catch (NegativeRadiusException negRadEx)
            {
                lblNewShapeRadiusException.Visible = true;
                lblNewShapeRadiusException.Text = negRadEx.Message;
            }
            
        }
    }
}
