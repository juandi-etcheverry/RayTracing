using ObligatorioDA1.Properties;
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
    
    public partial class Panel_ShapeList : UserControl
    {
        private Panel_General _panelGeneral;
        List<String> _shapeList = new List<String>();
        Bitmap imgTrash = new Bitmap(Application.StartupPath + @"\Images\trash.ico");
        public Panel_ShapeList(Panel_General userControl)
        {
            _panelGeneral = userControl;
            InitializeComponent();
            
            _shapeList.Add("Nicolas");
            _shapeList.Add("Mateo");
            _shapeList.Add("Juan Diego");
            _shapeList.Add("Martin");
            _shapeList.Add("Tomas");

            dgvShapeList.Columns.Add("name", "Name");
            dgvShapeList.Columns.Add("radius", "Radius");
            dgvShapeList.Columns["name"].DisplayIndex = 0;
            dgvShapeList.Columns["radius"].DisplayIndex = 1;
            dgvShapeList.Columns["Rename"].DisplayIndex = 2;
            dgvShapeList.Columns["Delete"].DisplayIndex = 3;
            refreshShapeList();
        }

        private void btnAddShape_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToAddNewShape();
        }
        private void refreshShapeList()
        {
            dgvShapeList.Rows.Clear();

            //DataGridViewButtonColumn btnclmRename = new DataGridViewButtonColumn();
            //DataGridViewButtonColumn btnclmDelete = new DataGridViewButtonColumn();
            //btnclmRename.Name = "Rename";
            //btnclmDelete.Name = "Delete";

            //dgvShapeList.Columns.Add(btnclmRename);
            //dgvShapeList.Columns.Add(btnclmDelete);
            foreach (String x in _shapeList)
            {
                dgvShapeList.Rows.Add(null, null, x, 3);
            }
        }

        private void dgvShapeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvShapeList.Columns[e.ColumnIndex].Name == "Delete" )
            {
                //Delete that figure from list
                //dgvShapeList.CurrentRow.Cells[0].Value.ToString();
                dgvShapeList.Rows.Remove(dgvShapeList.CurrentRow);
            }
            if(this.dgvShapeList.Columns[e.ColumnIndex].Name == "Rename")
            {
                _panelGeneral.goToShapeRename(this.dgvShapeList.CurrentRow.Cells[0].ToString());
            }
        }

        private void dgvShapeList_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {

            if (e.ColumnIndex>=0 
                && e.RowIndex>=0
                && (this.dgvShapeList.Columns[e.ColumnIndex].Name == "Delete" 
                || this.dgvShapeList.Columns[e.ColumnIndex].Name == "Rename"))
            {
                
                this.dgvShapeList.Rows[e.RowIndex].Height = 50;
                this.dgvShapeList.Columns[e.ColumnIndex].Width = 70;
            }
        }
    }
}
