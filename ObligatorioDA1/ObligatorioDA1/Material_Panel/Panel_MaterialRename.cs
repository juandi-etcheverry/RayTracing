﻿using BusinessLogic;
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

namespace ObligatorioDA1.Material_Panel
{
    public partial class Panel_MaterialRename : UserControl
    {
        MaterialLogic _materialLogic = new MaterialLogic();
        private Panel_General _panelGeneral;
        private Material _material;
        public Panel_MaterialRename(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
            refreshMaterialRename(_material);
        }
        public void refreshMaterialRename(Material material)
        {
            _material = material;
            lblRenameException.Visible = false;
            txbMaterialRename.Clear();
        }

        private void btnReturnRename_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToMaterialList();
        }

        private void btnConfirmRename_Click(object sender, EventArgs e)
        {
            try
            {
                _materialLogic.Rename(_material, txbMaterialRename.Text);
                _panelGeneral.goToMaterialList();
            }
            catch (NameException nameEx)
            {
                lblRenameException.Visible = true;
                lblRenameException.Text = nameEx.Message;
            }
            
        }
    }
}