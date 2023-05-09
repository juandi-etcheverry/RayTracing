﻿using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObligatorioDA1.Scene_Panel
{
    public partial class Panel_SceneSetDefaultCamera : UserControl
    {
        private Panel_General _panelGeneral;
        public Panel_SceneSetDefaultCamera(Panel_General panelGeneral)
        {
            _panelGeneral = panelGeneral;
            InitializeComponent();
        }
        public void RefreshSetDefaultCamera()
        {
            ClearPage();
            SetDefaultValues();
        }
        private void ClearPage()
        {
            lblFoVException.Visible = false;
            lblLookExceptions.Visible = false;
            txbLookFromX.Clear();
            txbLookFromY.Clear();
            txbLookFromZ.Clear();
            txbLookAtX.Clear();
            txbLookAtY.Clear();
            txbLookAtZ.Clear();
            txbFoV.Clear();
        }
        private void SetDefaultValues()
        {
            // Set default values
        }
        private void btnReturnDefaultCamera_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToShapeList();
        }
        private void btnSaveDefaultCamera_Click(object sender, EventArgs e)
        {
            try
            {
                SetLookfrom();
                SetLookAt();
                SetFov();
                _panelGeneral.GoToSceneList();
            }
            catch (ArgumentOutOfRangeException outEx)
            {
                lblFoVException.Visible = true;
                lblFoVException.Text = outEx.Message;
            }
            catch (ArgumentException argEx)
            {
                lblLookExceptions.Visible = true;
                lblLookExceptions.Text = argEx.Message;
            }
        }
        private void SetLookfrom()
        {
            decimal x, y, z;
            bool validX = decimal.TryParse(txbLookFromX.Text, out x);
            bool validY = decimal.TryParse(txbLookFromY.Text, out y);
            bool validZ = decimal.TryParse(txbLookFromZ.Text, out z);
            if (!validX || !validY || !validZ) throw new ArgumentException("X, Y, Z must be numbers");
            var tuple = ValueTuple.Create(x, y, z);
            //_scene.LookFrom = tuple;
        }
        private void SetLookAt()
        {
            decimal x, y, z;
            bool validX = decimal.TryParse(txbLookAtX.Text, out x);
            bool validY = decimal.TryParse(txbLookAtY.Text, out y);
            bool validZ = decimal.TryParse(txbLookAtZ.Text, out z);
            if (!validX || !validY || !validZ) throw new ArgumentException("X, Y, Z must be numbers");
            var tuple = ValueTuple.Create(x, y, z);
            //_scene.LookAt = tuple;
        }
        private void SetFov()
        {
            uint x;
            bool validX = uint.TryParse(txbFoV.Text, out x);
            //_scene.FoV = x;
        }
    }
}