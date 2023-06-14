using System;
using System.Windows.Forms;
using BusinessLogic;
using BusinessLogicExceptions;
using Domain;

namespace ObligatorioDA1.Material_Panel
{
    public partial class Panel_MaterialAddNew : UserControl
    {
        private readonly MaterialLogic _materialLogic = new MaterialLogic();
        private readonly Panel_General _panelGeneral;
        private Material _material;

        public Panel_MaterialAddNew(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
        }

        public void RefreshMaterialAddNew()
        {
            _material = new Material();
            RefreshPanel();
        }

        private void RefreshPanel()
        {
            txbNewMaterialName.Clear();
            txbNewRMaterial.Clear();
            txbNewGMaterial.Clear();
            txbNewBMaterial.Clear();
            lblNewMaterialNameException.Visible = false;
            lblNewRGBException.Visible = false;
            pnlTypePreferences.Visible = false;
            rbtnLambertian.Checked = true;
            rbtnMetalic.Checked = false;
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
                int r, g, b;
                var validR = int.TryParse(txbNewRMaterial.Text, out r);
                var validG = int.TryParse(txbNewGMaterial.Text, out g);
                var validB = int.TryParse(txbNewBMaterial.Text, out b);
                if (!validR || !validG || !validB) throw new ArgumentException("RGB must be numbers between 0 and 255");
                _material.MaterialName = txbNewMaterialName.Text;
                _material.SetColor(r, g, b);
                if (rbtnMetalic.Checked)
                {
                    MetallicMaterial metallicMaterial = new MetallicMaterial()
                    {
                        MaterialName = _material.MaterialName,
                    };
                    metallicMaterial.SetColor(r, g, b);
                    decimal blur;
                    var validBlur = decimal.TryParse(txbBlur.Text, out blur) && blur>=0;
                    if (!validBlur)
                        throw new ArgumentException("Blur must be a non negative number");
                    metallicMaterial.Blur = blur;
                    _materialLogic.Add(metallicMaterial);
                    _panelGeneral.GoToMaterialList();
                    return;
                }
                _materialLogic.Add(_material);
                _panelGeneral.GoToMaterialList();
            }
            catch (NameException nameEx)
            {
                lblNewMaterialNameException.Visible = true;
                lblNewMaterialNameException.Text = nameEx.Message;
            }
            catch (ArgumentOutOfRangeException arORex)
            {
                lblBlurException.Visible = true;
                lblBlurException.Text = arORex.Message;
            }
            catch (ArgumentException arEex)
            {
                if(arEex.Message == "RGB must be numbers between 0 and 255")
                {
                    lblNewRGBException.Visible = true;
                    lblNewRGBException.Text = arEex.Message;
                }
                else
                {
                    lblBlurException.Visible = true;
                    lblBlurException.Text = arEex.Message;
                }
                
            }
        }

        private void txbNewMaterialName_TextChanged(object sender, EventArgs e)
        {
            lblNewMaterialNameException.Visible = false;
            try
            {
                _material.MaterialName = txbNewMaterialName.Text;
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
                var validR = uint.TryParse(txbNewRMaterial.Text, out r) && r <= 255 && r >= 0;
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
                var validG = uint.TryParse(txbNewGMaterial.Text, out g) && g <= 255 && g >= 0;
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
                var validB = uint.TryParse(txbNewBMaterial.Text, out b) && b <= 255 && b >= 0;
                if (!validB) throw new ArgumentException("RGB must be numbers between 0 and 255");
            }
            catch (ArgumentException argEx)
            {
                lblNewRGBException.Visible = true;
                lblNewRGBException.Text = argEx.Message;
            }
        }

        private void rbtnMetalic_CheckedChanged(object sender, EventArgs e)
        {
            pnlTypePreferences.Visible = true;
            lblBlurException.Visible = false;
        }

        private void rbtnLambertian_CheckedChanged(object sender, EventArgs e)
        {
            pnlTypePreferences.Visible = false;
        }
    }
}