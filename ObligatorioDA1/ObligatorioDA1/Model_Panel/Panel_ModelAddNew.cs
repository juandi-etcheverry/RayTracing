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

namespace ObligatorioDA1.Model_Panel
{
    public partial class Panel_ModelAddNew : UserControl
    {
        private Model _newModel;
        private ModelLogic _modelLogic = new ModelLogic();
        private MaterialLogic _materialLogic = new MaterialLogic();
        private ShapeLogic _shapeLogic = new ShapeLogic();
        private Panel_General _panelGeneral;
        public Panel_ModelAddNew(Panel_General panelGeneral)
        {
            _panelGeneral = panelGeneral;
            InitializeComponent();
        }
        public void RefreshModelAddNew()
        {
            _newModel = new Model();
            RefreshPage();
        }
        private void btnShowAllModels_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToModelList();
        }
        private void btnNewModel_Click(object sender, EventArgs e)
        {
            lblModelSelectShape.Visible = false;
            lblNewModelNameException.Visible = false;
            try
            {
                if (cmbNewModelMaterial.SelectedItem == null)
                    throw new ArgumentException("Must select a material");
                if (cmbNewModelShape.SelectedItem == null)
                    throw new ArgumentException("Must select a shape");
                _newModel.Name = txbNewModelName.Text;
                _newModel.Material = _materialLogic.Get(cmbNewModelMaterial.SelectedItem.ToString());
                _newModel.Shape = _shapeLogic.GetShape(cmbNewModelShape.SelectedItem.ToString());
                _newModel.WantPreview = ckbModelPreview.Checked;
                _modelLogic.Add(_newModel);
                _panelGeneral.GoToModelList();
            }
            catch (NameException nameEx)
            {
                lblNewModelNameException.Visible = true;
                lblNewModelNameException.Text = nameEx.Message;
            }
            catch (ArgumentException argEx)
            {
                if(argEx.Message == "Must select a material")
                {
                    lblModelSelectMaterial.Visible = true;
                    lblModelSelectMaterial.Text = argEx.Message;
                }
                else
                {
                    lblModelSelectShape.Visible = true;
                    lblModelSelectShape.Text = argEx.Message;
                }
            }
        }
        private void RefreshShapeCombo()
        {
            cmbNewModelShape.Items.Clear();
            foreach (Shape s in _shapeLogic.GetClientShapes())
                cmbNewModelShape.Items.Add(s.Name);
        }
        private void RefreshMaterialCombo()
        {
            cmbNewModelMaterial.Items.Clear();
            foreach (Material m in _materialLogic.GetClientMaterials())
                cmbNewModelMaterial.Items.Add(m.Name);
        }
        private void RefreshPage()
        {
            lblNewModelNameException.Visible = false;
            lblModelSelectShape.Visible = false;
            lblModelSelectMaterial.Visible = false;
            txbNewModelName.Clear();
            ckbModelPreview.Checked = false;
            RefreshShapeCombo();
            RefreshMaterialCombo();
        }
        private void txbNewModelName_TextChanged(object sender, EventArgs e)
        {
            lblNewModelNameException.Visible = false;
            try
            {
                _newModel.Name = txbNewModelName.Text;
            }
            catch (NameException nameEx)
            {
                lblNewModelNameException.Visible = true;
                lblNewModelNameException.Text = nameEx.Message;
            }
        }
    }
}
