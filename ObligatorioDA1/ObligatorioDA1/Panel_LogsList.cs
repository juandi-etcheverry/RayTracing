using System;
using System.Linq;
using System.Windows.Forms;
using BusinessLogic;

namespace ObligatorioDA1
{
    public partial class Panel_LogsList : UserControl
    {
        private readonly Form1 _formPrincipal;
        private readonly RenderLogLogic _logLogic = new RenderLogLogic();

        public Panel_LogsList(Form1 formPrincipal)
        {
            InitializeComponent();
            _formPrincipal = formPrincipal;
            InitializeList();
        }

        public void RefreshLogsList()
        {
            RefreshPage();
        }

        private void RefreshPage()
        {
            RefreshTable();
            RefreshData();
        }

        private void RefreshTable()
        {
            dgvLogsList.Rows.Clear();
            foreach (var log in _logLogic.GetAll().ToList())
                dgvLogsList.Rows.Add(
                    log.Client.Name,
                    log.RenderingTimeInSeconds,
                    log.RenderDate,
                    log.RenderWindow,
                    log.SceneName,
                    log.NumberOfModels);
        }

        private void RefreshData()
        {
            lblAvgTime.Text = _logLogic.GetAverageRenderTime().ToString();
            lblMostRenderUser.Text = _logLogic.GetClientWithMaxRenderTime().Client.Name;
            lblClientTime.Text = _logLogic.GetClientWithMaxRenderTime().AccumulatedRenderTime.ToString();
            lblTotalTime.Text = _logLogic.GetTotalRenderTimeInMinutes().ToString();
        }

        private void InitializeList()
        {
            AddColumns();
            SetColumnsWidth();
        }

        private void AddColumns()
        {
            dgvLogsList.Columns.Add("Username", "User name");
            dgvLogsList.Columns.Add("Render time", "Render time");
            dgvLogsList.Columns.Add("Date", "Date");
            dgvLogsList.Columns.Add("Window time", "Window time");
            dgvLogsList.Columns.Add("Scenename", "Object Name");
            dgvLogsList.Columns.Add("Objects", "Objects");
        }

        private void SetColumnsWidth()
        {
            //dgvLogsList.Columns["Objects"].Width = 30;
            dgvLogsList.Columns["Date"].Width = 155;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            _formPrincipal.GoBackToWelcome();
        }
    }
}