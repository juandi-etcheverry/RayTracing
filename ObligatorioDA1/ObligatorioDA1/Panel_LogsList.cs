using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObligatorioDA1
{
    public partial class Panel_LogsList : UserControl
    {
        private readonly Form1 _formPrincipal;
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
            //RefreshTable();
            //RefreshData();
        }
        private void InitializeList()
        {
            AddColumns();
            //SetWidthColumns();
        }
        private void AddColumns()
        {
            dgvLogsList.Columns.Add("Username", "Username");
            dgvLogsList.Columns.Add("Render time", "Render time");
            dgvLogsList.Columns.Add("Date", "Date");
            dgvLogsList.Columns.Add("Time", "Time");
            dgvLogsList.Columns.Add("Scenename", "Scenename");
            dgvLogsList.Columns.Add("Objects", "Objects");
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            _formPrincipal.GoBackToWelcome();
        }
    }
}
