﻿using System;
using System.Windows.Forms;
using BusinessLogic;
using Domain;

namespace ObligatorioDA1.Scene_Panel
{
    public partial class Panel_AddModelToScene : UserControl
    {
        private readonly Panel_General _panelGeneral;
        private readonly SceneLogic _sceneLogic = new SceneLogic();
        private Model _model;
        private Scene _scene;

        public Panel_AddModelToScene(Panel_General panelGeneral)
        {
            _panelGeneral = panelGeneral;
            InitializeComponent();
        }

        public void RefreshModelToScene(Model model, Scene scene)
        {
            _model = model;
            _scene = scene;
            RefreshPage();
        }

        private void RefreshPage()
        {
            lblModelName.Text = _model.ModelName;
            txbModelXCoordinates.Clear();
            txbModelYCoordinates.Clear();
            txbModelZCoordinates.Clear();
            lblCoordinatesExceptions.Visible = false;
            pboxModelPreview.Image = _model.Preview;
            pboxModelPreview.SizeMode = PictureBoxSizeMode.CenterImage;
        }

        private void btnReturnAddModel_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToSceneEditor(_scene);
        }

        private void btnAddToScene_Click(object sender, EventArgs e)
        {
            try
            {
                decimal x, y, z;
                var validX = decimal.TryParse(txbModelXCoordinates.Text, out x);
                var validY = decimal.TryParse(txbModelYCoordinates.Text, out y);
                var validZ = decimal.TryParse(txbModelZCoordinates.Text, out z);
                if (!validX || !validY || !validZ) throw new ArgumentException("X, Y, Z must be numbers");
                _sceneLogic.AddPositionedModel(_model, (x, y, z), _scene.Id);
                _panelGeneral.GoToSceneEditor(_scene);
            }
            catch (ArgumentException argEx)
            {
                lblCoordinatesExceptions.Visible = true;
                lblCoordinatesExceptions.Text = argEx.Message;
            }
        }
    }
}