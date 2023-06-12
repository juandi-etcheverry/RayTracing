using System;
using System.Windows.Forms;
using BusinessLogic;
using Domain;

namespace ObligatorioDA1.Scene_Panel
{
    public partial class Panel_SceneSetDefaultCamera : UserControl
    {
        private Client _client;
        private readonly Panel_General _panelGeneral;
        private readonly ClientLogic _clientLogic = new ClientLogic();

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
            txbLookFromX.Text = _client.ClientScenePreferences.LookFromDefaultX.ToString();
            txbLookFromY.Text = _client.ClientScenePreferences.LookFromDefaultY.ToString();
            txbLookFromZ.Text = _client.ClientScenePreferences.LookFromDefaultZ.ToString();
            txbLookAtX.Text = _client.ClientScenePreferences.LookAtDefaultX.ToString();
            txbLookAtY.Text = _client.ClientScenePreferences.LookAtDefaultY.ToString();
            txbLookAtZ.Text = _client.ClientScenePreferences.LookAtDefaultZ.ToString();
            txbFoV.Text = _client.ClientScenePreferences.FoVDefault.ToString();
        }

        private void btnReturnDefaultCamera_Click(object sender, EventArgs e)
        {
            _panelGeneral.GoToSceneList();
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
                if (argEx.Message == "X, Y, Z must be numbers")
                {
                    lblLookExceptions.Visible = true;
                    lblLookExceptions.Text = argEx.Message;
                }
                else
                {
                    lblFoVException.Visible = true;
                    lblFoVException.Text = argEx.Message;
                }
            }
        }

        private ValueTuple<decimal, decimal, decimal> SetLookfrom()
        {
            decimal x, y, z;
            var validX = decimal.TryParse(txbLookFromX.Text, out x);
            var validY = decimal.TryParse(txbLookFromY.Text, out y);
            var validZ = decimal.TryParse(txbLookFromZ.Text, out z);
            if (!validX || !validY || !validZ) throw new ArgumentException("X, Y, Z must be numbers");
            var tuple = ValueTuple.Create(x, y, z);
            return tuple;
        }

        private ValueTuple<decimal, decimal, decimal> SetLookAt()
        {
            decimal x, y, z;
            var validX = decimal.TryParse(txbLookAtX.Text, out x);
            var validY = decimal.TryParse(txbLookAtY.Text, out y);
            var validZ = decimal.TryParse(txbLookAtZ.Text, out z);
            if (!validX || !validY || !validZ) throw new ArgumentException("X, Y, Z must be numbers");
            var tuple = ValueTuple.Create(x, y, z);
            return tuple;
        }

        private int SetFov()
        {
            int x;
            var validX = int.TryParse(txbFoV.Text, out x);
            if (!validX) throw new ArgumentException("FoV must be a positive number");
            return x;
        }

        private void SetNewDefaults(ValueTuple<decimal, decimal, decimal> tuple1,
            ValueTuple<decimal, decimal, decimal> tuple2, int fov)
        {
            _client.ClientScenePreferences.SetLookFromDefault(tuple1);
            _client.ClientScenePreferences.SetLookAtDefault(tuple2);;
            _client.ClientScenePreferences.FoVDefault = fov;
            _clientLogic.Update(_client);
        }
    }
}