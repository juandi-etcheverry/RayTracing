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
    public partial class Panel_SceneSetDefaultCamera : UserControl
    {
        private Client _client;
        private Panel_General _panelGeneral;
        public Panel_SceneSetDefaultCamera(Panel_General panelGeneral)
        {
            _panelGeneral = panelGeneral;
            InitializeComponent();
        }
        public void RefreshSetDefaultCamera(Client client)
        {
            _client = client;
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
            txbLookFromX.Text = _client.ClientScenePreferences.LookFromDefault.Item1.ToString();
            txbLookFromY.Text = _client.ClientScenePreferences.LookFromDefault.Item2.ToString();
            txbLookFromZ.Text = _client.ClientScenePreferences.LookFromDefault.Item3.ToString();
            txbLookAtX.Text = _client.ClientScenePreferences.LookAtDefault.Item1.ToString();
            txbLookAtY.Text = _client.ClientScenePreferences.LookAtDefault.Item2.ToString();
            txbLookAtZ.Text = _client.ClientScenePreferences.LookAtDefault.Item3.ToString();
            txbFoV.Text = _client.ClientScenePreferences.FoVDefault.ToString();
        }
        private void btnReturnDefaultCamera_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToShapeList();
        }
        private void btnSaveDefaultCamera_Click(object sender, EventArgs e)
        {
            try
            {
                var tupleLookFrom = SetLookfrom();
                var tupleLookAt = SetLookAt();
                var newFoV = SetFov();
                SetNewDefaults(tupleLookFrom, tupleLookAt, newFoV);
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
        private ValueTuple<decimal, decimal, decimal> SetLookfrom()
        {
            decimal x, y, z;
            bool validX = decimal.TryParse(txbLookFromX.Text, out x);
            bool validY = decimal.TryParse(txbLookFromY.Text, out y);
            bool validZ = decimal.TryParse(txbLookFromZ.Text, out z);
            if (!validX || !validY || !validZ) throw new ArgumentException("X, Y, Z must be numbers");
            var tuple = ValueTuple.Create(x, y, z);
            return tuple;
            
        }
        private ValueTuple<decimal, decimal, decimal> SetLookAt()
        {
            decimal x, y, z;
            bool validX = decimal.TryParse(txbLookAtX.Text, out x);
            bool validY = decimal.TryParse(txbLookAtY.Text, out y);
            bool validZ = decimal.TryParse(txbLookAtZ.Text, out z);
            if (!validX || !validY || !validZ) throw new ArgumentException("X, Y, Z must be numbers");
            var tuple = ValueTuple.Create(x, y, z);
            return tuple;
            
        }
        private uint SetFov()
        {
            uint x;
            bool validX = uint.TryParse(txbFoV.Text, out x);
            return x;
        }
        private void SetNewDefaults(ValueTuple<decimal, decimal, decimal> tuple1, ValueTuple<decimal, decimal, decimal> tuple2, uint fov)
        {
            _client.ClientScenePreferences.LookFromDefault = tuple1;
            _client.ClientScenePreferences.LookAtDefault = tuple2;
            _client.ClientScenePreferences.FoVDefault = fov;
        }
    }
}
