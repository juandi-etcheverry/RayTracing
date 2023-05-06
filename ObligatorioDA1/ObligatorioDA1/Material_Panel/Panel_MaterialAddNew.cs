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
        Material newMaterial;
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
            newMaterial = new Material();
            _client = client;
            RefreshPanel();
        }

        private void btnShowAllMaterials_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToMaterialList();
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
                if (!validR || !validG || !validB) throw new ArgumentException("RGB must be numbers between 0 and 255");
                newMaterial.Name = txbNewMaterialName.Text;
                newMaterial.Color = (r, g, b);
                _materialLogic.Add(newMaterial);
                RefreshPanel();
                _panelGeneral.GoToMaterialList();
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
        private void txbNewMaterialName_TextChanged(object sender, EventArgs e)
        {
            lblNewMaterialNameException.Visible = false;
            try
            {
                newMaterial.Name = txbNewMaterialName.Text;
            }
            catch (NameException nameEx)
            {
                lblNewMaterialNameException.Visible = true;
                lblNewMaterialNameException.Text = nameEx.Message;
            }
        }

        private void txbNewRMaterial_TextChanged(object sender, EventArgs e)
        {
            lblNewRGBException.Visible = false;
            try
            {
                uint r;
                bool validR = uint.TryParse(txbNewRMaterial.Text, out r) && r<=255 && r>=0;
                if (!validR) throw new ArgumentException("RGB must be numbers between 0 and 255");
            }
            catch (ArgumentException argEx)
            {
                lblNewRGBException.Visible = true;
                lblNewRGBException.Text = argEx.Message;
            }
        }

        private void txbNewGMaterial_TextChanged(object sender, EventArgs e)
        {
            lblNewRGBException.Visible = false;
            try
            {
                uint g;
                bool validG = uint.TryParse(txbNewGMaterial.Text, out g) && g <= 255 && g>=0;
                if (!validG) throw new ArgumentException("RGB must be numbers between 0 and 255");
            }
            catch (ArgumentException argEx)
            {
                lblNewRGBException.Visible = true;
                lblNewRGBException.Text = argEx.Message;
            }
        }

        private void txbNewBMaterial_TextChanged(object sender, EventArgs e)
        {
            lblNewRGBException.Visible = false;
            try
            {
                uint b;
                bool validB = uint.TryParse(txbNewBMaterial.Text, out b) && b <= 255 && b >= 0;
                if (!validB) throw new ArgumentException("RGB must be numbers between 0 and 255");
            }
            catch (ArgumentException argEx)
            {
                lblNewRGBException.Visible = true;
                lblNewRGBException.Text = argEx.Message;
            }
        }
        private void RefreshPanel()
        {
            lblNewMaterialNameException.Visible = false;
            lblNewRGBException.Visible = false;
            txbNewMaterialName.Clear();
            txbNewRMaterial.Clear();
            txbNewGMaterial.Clear();
            txbNewBMaterial.Clear();
        }
    }
}
