using BusinessLogic;
using Domain;
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
        private Client _client;
        ShapeLogic shapeLogic = new ShapeLogic(); 
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
            refreshShapeList(_client);
        }

        private void btnAddShape_Click(object sender, EventArgs e)
        {
            _panelGeneral.goToAddNewShape();
        }
        public void refreshShapeList(Client _client)
        {
            dgvShapeList.Rows.Clear();

            //DataGridViewButtonColumn btnclmRename = new DataGridViewButtonColumn();
            //DataGridViewButtonColumn btnclmDelete = new DataGridViewButtonColumn();
            //btnclmRename.Name = "Rename";
            //btnclmDelete.Name = "Delete";

            //dgvShapeList.Columns.Add(btnclmRename);
            //dgvShapeList.Columns.Add(btnclmDelete);
            foreach (Sphere shape in shapeLogic.GetShapes().ToList())
            {
                if (shape.OwnerName == _client.Name)
                {
                    dgvShapeList.Rows.Add(null, null, shape.Name, shape.Radius);
                }
            }
        }

        private void dgvShapeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String shapeName = dgvShapeList.CurrentRow.Cells[2].Value.ToString();
            Shape shape = shapeLogic.GetShape(shapeName);
            if (this.dgvShapeList.Columns[e.ColumnIndex].Name == "Delete" )
            {
                shapeLogic.RemoveShape(shape);
                dgvShapeList.Rows.Remove(dgvShapeList.CurrentRow);
            }
            if(this.dgvShapeList.Columns[e.ColumnIndex].Name == "Rename")
            {
                _panelGeneral.goToShapeRename(shape);
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
