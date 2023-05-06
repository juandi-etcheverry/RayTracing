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

namespace ObligatorioDA1.Scene_Panel
{
    public partial class Panel_AddModelToScene : UserControl
    {
        private Panel_General _panelGeneral;
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
            lblModelName.Text = _model.Name;
            txbModelXCoordinates.Clear();
            txbModelYCoordinates.Clear();
            txbModelZCoordinates.Clear();
            lblCoordinatesExceptions.Visible = false;
            //put the preview
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
                bool validX = decimal.TryParse(txbModelXCoordinates.Text, out x);
                bool validY = decimal.TryParse(txbModelYCoordinates.Text, out y);
                bool validZ = decimal.TryParse(txbModelZCoordinates.Text, out z);
                if (!validX || !validY || !validZ) throw new ArgumentException("X, Y, Z must be numbers");
                _scene.AddPositionedModel(_model, (x, y, z));
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
