using BusinessLogic;
using BusinessLogicExceptions;
using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObligatorioDA1.Material_Panel
{
    public partial class Panel_MaterialAddNew : UserControl
    {
        MaterialLogic _materialLogic = new MaterialLogic();
        private Panel_General _panelGeneral;
        private Client _client;
        public Panel_MaterialAddNew(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
            refreshMaterialAddNew(_client);
        }
        public void refreshMaterialAddNew(Client client)
        {
            _client = client;
            lblNewMaterialNameException.Visible = false;
            lblNewRGBException.Visible = false;
            txbNewMaterialName.Clear();
            txbNewRMaterial.Clear();
            txbNewGMaterial.Clear();
            txbNewBMaterial.Clear();
        }

        private void btnShowAllMaterials_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToMaterialList();
        }

        private void btnNewMaterial_Click(object sender, EventArgs e)
        {
            lblNewMaterialNameException.Visible = false;
            lblNewRGBException.Visible = false;
            try
            {
                uint r, g, b;
                bool validR = uint.TryParse(txbNewRMaterial.Text, out r);
                bool validG = uint.TryParse(txbNewGMaterial.Text, out g);
                bool validB = uint.TryParse(txbNewBMaterial.Text, out b);
                if (!validR || !validG || !validB) throw new ArgumentException("RGB must be numbers");

                Material newMaterial = new Material()
                {
                    Name = txbNewMaterialName.Text,
                    Color = (r, g, b)
                };
                _materialLogic.Add(newMaterial);
                _panelGeneral.goToMaterialList();
            }
            catch (NameException nameEx)
            {
                lblNewMaterialNameException.Visible = true;
                lblNewMaterialNameException.Text = nameEx.Message;
            }
            catch (ArgumentException arEex)
            {
                lblNewRGBException.Visible = true;
                lblNewRGBException.Text = arEex.Message;
            }
            
        }
    }
}
